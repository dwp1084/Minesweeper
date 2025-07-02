using System;
using System.Drawing;
using System.Windows.Forms;

namespace Minesweeper_Clone {
    public enum GameDifficulty {
        Beginner,
        Intermediate,
        Expert,
        Custom
    }

    public partial class Menus : Form {
        private GameDifficulty difficulty;
        private const int MaxVisualHeight = 32;

        public Menus() {
            InitializeComponent();
            difficulty = GameDifficulty.Beginner;
        }

        private void UpdateMaxBombs() {
            int maxBombs = Minesweeper.Board.MaxBombs;
            int rowsAndCols = rowBar.Value * colBar.Value;
            bombsBar.Maximum = (rowsAndCols > maxBombs) ? maxBombs : rowsAndCols;
            UpdateBarText(bombsShow, bombsBar.Value);
        }

        private static void UpdateBarText(Label label, int value) {
            label.Text = $"{value}";
        }

        private void StartGame(int rows, int cols, int bombs) {
            MineGUI newForm = new(rows, cols, bombs);
            newForm.FormClosed += (s, args) => Close();
            newForm.Show();
            Hide();
        }

        private void Menus_Load(object sender, EventArgs e) {
            Point newLocation = new(0, 0);
            difficultyContainer.Location = newLocation;
            Size newSize = new(487, 261);
            beginnerOption.Checked = true;
            difficultyContainer.Size = newSize;
            difficultyContainer.Visible = true;
            rowBar.Minimum = Minesweeper.Board.MinSize;
            rowBar.Maximum = (Minesweeper.Board.MaxSize < MaxVisualHeight) ? Minesweeper.Board.MaxSize : MaxVisualHeight;
            colBar.Minimum = Minesweeper.Board.MinSize;
            colBar.Maximum = Minesweeper.Board.MaxSize;
            bombsBar.Minimum = Minesweeper.Board.MinBombs;
            UpdateMaxBombs();
            UpdateBarText(rowShow, rowBar.Value);
            UpdateBarText(colShow, colBar.Value);
        }

        private void beginnerOption_CheckedChanged(object sender, EventArgs e) {
            if (beginnerOption.Checked) {
                difficulty = GameDifficulty.Beginner;
            }
        }

        private void intermediateOption_CheckedChanged(object sender, EventArgs e) {
            if (intermediateOption.Checked) {
                difficulty = GameDifficulty.Intermediate;
            }
        }

        private void expertOption_CheckedChanged(object sender, EventArgs e) {
            if (expertOption.Checked) {
                difficulty = GameDifficulty.Expert;
            }
        }

        private void customOption_CheckedChanged(object sender, EventArgs e) {
            if (customOption.Checked) {
                difficulty = GameDifficulty.Custom;
            }
        }

        private void playButton_Click(object sender, EventArgs e) {
            difficultyContainer.Visible = false;
            switch (difficulty) {
                case GameDifficulty.Beginner:
                    StartGame(8, 8, 10);
                    break;
                case GameDifficulty.Intermediate:
                    StartGame(16, 16, 40);
                    break;
                case GameDifficulty.Expert:
                    StartGame(16, 30, 99);
                    break;
                case GameDifficulty.Custom:
                    customSizeMenu.Visible = true;
                    AcceptButton = enterButton;
                    break;
            }
        }

        private void rowBar_Scroll(object sender, EventArgs e) {
            UpdateBarText(rowShow, rowBar.Value);
            UpdateMaxBombs();
        }

        private void colBar_Scroll(object sender, EventArgs e) {
            UpdateBarText(colShow, colBar.Value);
            UpdateMaxBombs();
        }

        private void bombsBar_Scroll(object sender, EventArgs e) {
            UpdateBarText(bombsShow, bombsBar.Value);
        }

        private void enterButton_Click(object sender, EventArgs e) {
            StartGame(rowBar.Value, colBar.Value, bombsBar.Value);
        }
    }
}
