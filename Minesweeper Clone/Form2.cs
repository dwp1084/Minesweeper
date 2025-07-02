using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using Minesweeper;

namespace Minesweeper_Clone {
    public partial class MineGUI : Form {
        private const int maxSecondsDisplay = 9999;
        private const int defaultDpi = 96;
        private const int squareSize = 20;
        private const int menuHeight = 50;
        private const int minWidth = 234;
        private Stopwatch gameWatch;

        private delegate void SafeCallDelegate(string text);
        private Board game;
        private readonly Thread timerThread;
        private Dictionary<Label, Tile> flaggedLabels;
        private bool started;
        private bool exiting;
        private bool gameRunning;

        public MineGUI(int rows, int cols, int bombs) {
            InitializeComponent();
            exiting = false;
            started = false;
            game = new(rows, cols, bombs);
            gameWatch = new();
            timerThread = new(new ThreadStart(SetTimeText));
            timerThread.IsBackground = true;
            gameRunning = true;
            flaggedLabels = new();
        }

        private void MineGUI_Load(object sender, EventArgs e) {
            Size gameSize = CalculateGameSize();
            SetNumberOfBombsLabelText();

            // Setting the size of the panel based on size of game board
            int panelHeight = game.Rows * squareSize + 1;
            int panelWidth = game.Cols * squareSize + 2;
            boardPanel.Size = new(panelWidth, panelHeight);

            using (Graphics g = CreateGraphics()) {
                // Calculate the minimum width for the current DPI scale
                int scaledMinWidth = (int)(minWidth * (g.DpiX / defaultDpi));
                topMenu.Width = (panelWidth < scaledMinWidth) ? scaledMinWidth : panelWidth;
                if (topMenu.Width == scaledMinWidth) {
                    Size = new(scaledMinWidth + 40, gameSize.Height);

                    // Set the location of the game board to be centered on the screen
                    Point originalLocation = boardPanel.Location;
                    int currentWidth = Width;
                    int newXPosition = (Width - panelWidth) / 2;
                    boardPanel.Location = new(newXPosition, originalLocation.Y);

                } else {
                    Size = new(gameSize.Width + 27, gameSize.Height);
                }
            }

            // Setting the visuals and mouse logic for the reset button
            resetButton.Image = Images.Smile;
            resetButton.MouseDown += (s, meArgs) => {
                if (meArgs.Button == MouseButtons.Left || meArgs.Button == MouseButtons.Middle) {
                    resetButton.Image = Images.SmilePressed;
                }
            };

            resetButton.MouseUp += (s, meArgs) => {
                if (meArgs.Button == MouseButtons.Left || meArgs.Button == MouseButtons.Middle) {
                    Menus menuForm = new();
                    menuForm.FormClosed += (s, args) => Application.Exit();
                    menuForm.Show();
                    Hide();
                    game = null;
                    flaggedLabels = null;
                    exiting = true;
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    Dispose();
                }
            };

            // Creating the tiles
            for (int row = 0; row < game.Rows; row++) {
                for (int col = 0; col < game.Cols; col++) {
                    Label square = new() {
                        Text = "",
                        Size = new(squareSize, squareSize),
                        Margin = new(0),
                        Padding = new(0),
                        BackgroundImage = Images.Armed,
                        Location = new(col * squareSize, row * squareSize),
                    };

                    int currentRow = row;
                    int currentCol = col;

                    Tile thisTile = game.GetTileAtPosition(currentRow, currentCol);

                    // Registers an observer for each tile corresponding to its visual
                    thisTile.Register((sq) => {
                        switch (thisTile.State) {
                            case TileState.Armed:
                                square.BackgroundImage = Images.Armed;
                                if (flaggedLabels.ContainsKey(square)) {
                                    flaggedLabels.Remove(square);
                                }
                                break;
                            case TileState.Activated:
                                if (thisTile.IsBomb) {
                                    square.BackgroundImage = Images.Bomb;
                                } else {
                                    square.BackgroundImage = Images.NumberOfBombs[thisTile.AdjacentBombs];
                                }

                                flaggedLabels.Remove(square);
                                break;
                            case TileState.Flagged:
                                square.BackgroundImage = Images.Flag;
                                flaggedLabels.Add(square, thisTile);
                                break;
                        }
                    });

                    // Adds the visual to the panel and sets the logic for the visual
                    boardPanel.Controls.Add(square);
                    square.MouseDown += (s, meArgs) => {
                        if (gameRunning) {
                            if (meArgs.Button == MouseButtons.Left && thisTile.State == TileState.Armed) {
                                square.BackgroundImage = Images.NumberOfBombs[0];
                            }

                            if (meArgs.Button == MouseButtons.Left || meArgs.Button == MouseButtons.Middle) {
                                resetButton.Image = Images.Suspense;
                            }
                        }
                    };

                    square.MouseUp += (s, meArgs) => {
                        if (!started) {
                            gameWatch.Start();
                            timerThread.Start();
                            started = true;
                        }

                        if (gameRunning) {
                            resetButton.Image = Images.Smile;
                            bool bombActivated = false;
                            bool won = false;
                            switch (meArgs.Button) {
                                case MouseButtons.Left:
                                    if (thisTile.State == TileState.Armed) {
                                        bombActivated = game.ActivateAtPosition(currentCol, currentRow);
                                    }
                                    break;
                                case MouseButtons.Right:
                                    if (thisTile.State != TileState.Activated) {
                                        game.FlagAtPosition(currentCol, currentRow);
                                        SetNumberOfBombsLabelText();
                                    }
                                    break;
                                case MouseButtons.Middle:
                                    if (thisTile.State == TileState.Activated) {
                                        bombActivated = game.ActivateAtPosition(currentCol, currentRow);
                                    }
                                    break;
                            }

                            won = game.CheckForWin();
                            if (won) {
                                timerThread.Interrupt();
                                gameRunning = false;
                                resetButton.Image = Images.Winner;
                            }

                            if (bombActivated) {
                                timerThread.Interrupt();
                                resetButton.Image = Images.Dead;
                                gameRunning = false;
                                game.ActivateAll();
                                if (thisTile.State == TileState.Activated && thisTile.IsBomb) {
                                    square.BackgroundImage = Images.Exploded;
                                }
                                foreach (Label flag in flaggedLabels.Keys) {
                                    Tile tile = flaggedLabels[flag];
                                    if (!tile.IsBomb) {
                                        flag.BackgroundImage = Images.FalseFlag;
                                    }
                                }
                            }
                        }
                    };
                }
            }
        }

        private void SetNumberOfBombsLabelText() {
            int numberOfBombs = game.NumberOfBombs - game.Flags;
            if (numberOfBombs > -1) {
                numberOfBombsLabel.Text = $"{numberOfBombs:D3}";
            } else {
                numberOfBombsLabel.Text = $"{numberOfBombs:D2}";
            }
        }

        private Size CalculateGameSize() {
            int height = menuHeight + 20 + (game.Rows * squareSize);
            int width = 20 + (game.Cols * squareSize);
            return new(width, height);
        }

        private void SafeSetTimeText(string text) {
            if (watch.InvokeRequired) {
                var d = new SafeCallDelegate(SafeSetTimeText);
                watch.Invoke(d, new object[] { text });
            } else {
                watch.Text = text;
            }
        }

        private void SetTimeText() {
            try {
                bool maxReached = false;
                do {
                    Thread.Sleep(1000);
                    TimeSpan ts = gameWatch.Elapsed;
                    int secondsDisplay = (ts.TotalSeconds < maxSecondsDisplay) ? (int)ts.TotalSeconds : maxSecondsDisplay;
                    if (secondsDisplay == maxSecondsDisplay) {
                        maxReached = true;
                    }
                    SafeSetTimeText($"{secondsDisplay:D4}");
                } while (!exiting && !maxReached);
            } catch (ThreadInterruptedException) { } finally {
                gameWatch = null;
            }
        }

        private void MineGUI_FormClosing(object sender, FormClosingEventArgs e) {
            exiting = true;
        }
    }

    public class Images {
        public static readonly Image Armed = Properties.Resources.Armed;
        public static readonly Image Flag = Properties.Resources.Flag;
        public static readonly Image Bomb = Properties.Resources.Bomb;
        public static readonly Image Exploded = Properties.Resources.Exploded;
        public static readonly Image FalseFlag = Properties.Resources.FalseFlag;
        public static readonly Image Smile = Properties.Resources.Smile;
        public static readonly Image SmilePressed = Properties.Resources.SmilePressed;
        public static readonly Image Suspense = Properties.Resources.Suspense;
        public static readonly Image Dead = Properties.Resources.Dead;
        public static readonly Image Winner = Properties.Resources.Winner;
        public static readonly Image[] NumberOfBombs = new Image[9];

        static Images() {
            NumberOfBombs[0] = Properties.Resources._0;
            NumberOfBombs[1] = Properties.Resources._1;
            NumberOfBombs[2] = Properties.Resources._2;
            NumberOfBombs[3] = Properties.Resources._3;
            NumberOfBombs[4] = Properties.Resources._4;
            NumberOfBombs[5] = Properties.Resources._5;
            NumberOfBombs[6] = Properties.Resources._6;
            NumberOfBombs[7] = Properties.Resources._7;
            NumberOfBombs[8] = Properties.Resources._8;
        }
    }
}
