using System;
using System.Text;
using System.Collections.Generic;

namespace Minesweeper {
    public delegate void TileObserver(Tile tile);

    /// <include file='minesweeper.xml' path='minesweeper/members[@name="tilestate"]/TileState'/>
    public enum TileState {
        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tilestate"]/Armed'/>
        Armed,

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tilestate"]/Flagged'/>
        Flagged,

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tilestate"]/Activated'/>
        Activated
    }

    //-------------------------------------------------------------------------------------------------

    /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/Tile'/>
    public class Tile {

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/IsBomb'/>
        public bool IsBomb { get; }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/State'/>
        public TileState State { get; private set; }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/AdjacentBombs'/>
        public int AdjacentBombs { get; private set; }

        private readonly HashSet<TileObserver> observers;

        /// <summary>
        /// Constructor for the tile.
        /// </summary>
	    /// <param name = "isBomb">Boolean indicating whether the tile contains a bomb or not.</param>
        public Tile(bool isBomb) {
            IsBomb = isBomb;
            State = TileState.Armed;
            AdjacentBombs = 0;
            observers = new();
        }

        public void Register(TileObserver observer) {
            observers.Add(observer);
        }

        public void Deregister(TileObserver observer) {
            observers.Remove(observer);
        }

        private void NotifyObservers() {
            foreach (TileObserver observer in observers) {
                observer(this);
            }
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/Flag'/>
        public void Flag() {
            switch (State) {
                case TileState.Armed:
                    State = TileState.Flagged;
                    break;
                case TileState.Flagged:
                    State = TileState.Armed;
                    break;
            }
            NotifyObservers();
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/Activate'/>
        public void Activate() {
            if (State == TileState.Armed) {
                State = TileState.Activated;
                NotifyObservers();
            }
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="tile"]/IncrementBombs'/>
        public void IncrementBombs() {
            AdjacentBombs++;
        }

        public override string ToString() {
            return State switch {
                TileState.Armed => "-",
                TileState.Flagged => ":",
                _ => IsBomb ? "*" : (AdjacentBombs != 0 ? AdjacentBombs.ToString() : " "),
            };
        }
    }

    //-------------------------------------------------------------------------------------------------

    internal class LocationTuple {
        public int X { get; private set; }
        public int Y { get; private set; }

        public LocationTuple(int x, int y) {
            X = x;
            Y = y;
        }

        public override int GetHashCode() {
            return (int) Math.Pow(X, Y);
        }

        public override bool Equals(object obj) {
            if (obj != null && this.GetType().Equals(obj.GetType())) {
                LocationTuple other = (LocationTuple) obj;
                return this.X == other.X && this.Y == other.Y;
            }
            return false;
        }
    }


    //-------------------------------------------------------------------------------------------------

    /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/Board'/>
    public class Board {
        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/MinBombs'/>
        public const int MinBombs = 1;

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/MaxBombs'/>
        public const int MaxBombs = 999;

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/MinSize'/>
        public const int MinSize = 1;

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/MaxSize'/>
        public const int MaxSize = 52;


        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/gameEnd'/>
        private bool gameEnd;

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/board'/>
        private readonly Tile[,] board;

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/Rows'/>
        public int Rows { get; }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/Cols'/>
        public int Cols { get; }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/NumberOfBombs'/>
        public int NumberOfBombs { get; }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/Flags'/>
        public int Flags { get; private set; }

        /// <summary>
        /// Constructor for the board.
        /// </summary>
        /// <param name="rows">The number of rows the board will contain.</param>
        /// <param name="cols">The number of columns the board will contain.</param>
        /// <param name="numberOfBombs">The number of bombs the board will contain.</param>
        /// <exception cref="ArgumentOutOfRangeException">
        /// If the inputs for <paramref name="rows"/>, <paramref name="cols"/>, or <paramref name="numberOfBombs"/>
        /// are out of bounds.
        /// </exception>
        public Board(int rows, int cols, int numberOfBombs) {
            if (numberOfBombs < MinBombs || numberOfBombs > rows * cols || numberOfBombs > MaxBombs) {
                throw new ArgumentOutOfRangeException(nameof(numberOfBombs), "Invalid number of bombs");
            }

            if (rows < MinSize || rows > MaxSize) {
                throw new ArgumentOutOfRangeException(nameof(rows), "Invalid number of rows.");
            }

            if (cols < MinSize || cols > MaxSize) {
                throw new ArgumentOutOfRangeException(nameof(cols), "Invalid number of columns.");
            }

            this.Rows = rows;
            this.Cols = cols;
            board = new Tile[rows, cols];
            gameEnd = false;
            NumberOfBombs = numberOfBombs;
            Flags = 0;
            FillBoard();
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/FillBoard'/>
        private void FillBoard() {
            // Generating random locations for the bombs
            Random rand = new();
            HashSet<LocationTuple> bombLocations = new();
            while (bombLocations.Count < NumberOfBombs) {
                int x = rand.Next(Rows);
                int y = rand.Next(Cols);
                LocationTuple location = new(x, y);
                if (!bombLocations.Contains(location)) {
                    bombLocations.Add(location);
                }
            }

            // Setting bombs in each of those locations
            foreach (LocationTuple bomb in bombLocations) {
                board[bomb.X, bomb.Y] = new Tile(true);
            }

            // Setting all remaining squares as non-bomb squares
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {
                    if (board[i, j] == null) {
                        board[i, j] = new Tile(false);
                    }
                }
            }

            // Calculating the number of adjacent bombs to each square
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Cols; col++) {
                    Tile current = board[row, col];
                    int[,] neighbors = {{row-1, col-1}, {row-1, col}, {row-1, col+1}, {row, col-1}, 
                    {row, col+1}, {row+1, col-1}, {row+1, col}, {row+1, col+1}};

                    for (int i = 0; i < 8; i++) {
                        if (neighbors[i, 0] > -1 && neighbors[i, 0] < Rows
                            && neighbors[i, 1] > -1 && neighbors[i, 1] < Cols) {
                                Tile neighbor = board[neighbors[i, 0], neighbors[i, 1]];
                                if (neighbor.IsBomb) {
                                    current.IncrementBombs();
                                }
                            }
                    }
                }
            }
        }

        public Tile GetTileAtPosition(int x, int y) {
            return board[x, y];
        }

        public Tile GetBombActivatedTile() {
            for (int row = 0; row < Rows; row++) {
                for (int col = 0; col < Cols; col++) {
                    if (board[row, col].State == TileState.Activated && board[row, col].IsBomb) {
                        return board[row, col];
                    }
                }
            }

            return null;
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/EndGame'/>
        public void EndGame() {
            gameEnd = true;
            ActivateAll();
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/ActivateAll'/>
        public void ActivateAll() {
            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {
                    board[i, j].Activate();
                }
            }
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/CheckPosition'/>
        private void CheckPosition(int x, int y) {
            if (x < 0 || x > Cols - 1) {
                throw new ArgumentOutOfRangeException(nameof(x), "Invalid board location.");
            }

            if (y < 0 || y > Rows - 1) {
                throw new ArgumentOutOfRangeException(nameof(y), "Invalid board location.");
            }
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/ActivateAtPosition'/>
        public bool ActivateAtPosition(int x, int y) {
            CheckPosition(x, y);

            if (board[y, x].State == TileState.Flagged) {
                throw new ArgumentException("This square is flagged.");
            }

            Tile tile = board[y, x];
            if (tile.State == TileState.Activated) {
                bool bombActivated = ActivateAroundActivated(x, y);
                if (bombActivated) {
                    return true;
                }
            }

            tile.Activate();

            if (tile.IsBomb) {
                return true;
            }

            if (tile.AdjacentBombs == 0) {
                int[,] neighbors = {{x-1, y-1}, {x, y-1}, {x+1, y-1}, {x-1, y}, {x+1, y}, {x-1, y+1}, {x, y+1}, {x+1, y+1}};
                for (int i = 0; i < 8; i++) {
                    for (int j = 0; j < 2; j++) {
                        int[] loc = { neighbors[i, 0], neighbors[i, 1] };
                        if (loc[0] >= 0 && loc[1] >= 0 && loc[0] < Cols && loc[1] < Rows) {
                            Tile neighbor = board[loc[1], loc[0]];
                            if (neighbor.State != TileState.Activated) {
                                ActivateAtPosition(loc[0], loc[1]);
                            }
                        }
                    }
                }
            }

            return false;
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/ActivateAroundActivated'/>
        private bool ActivateAroundActivated(int x, int y) {
            int[,] neighbors = {{x-1, y-1}, {x, y-1}, {x+1, y-1}, {x-1, y}, {x+1, y}, {x-1, y+1}, {x, y+1}, {x+1, y+1}};
            bool activatedBomb = false;

            for (int i = 0; i < 8; i++) {
                int locX = neighbors[i, 0];
                int locY = neighbors[i, 1];
                if (locX > -1 && locY > -1 && locX < Cols && locY < Rows) {
                    Tile neighbor = board[locY, locX];
                    if (neighbor.State == TileState.Armed) {
                        activatedBomb = activatedBomb || ActivateAtPosition(locX, locY);
                    }
                }
            }

            return activatedBomb;
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/FlagAtPosition'/>
        public void FlagAtPosition(int x, int y) {
            CheckPosition(x, y);

            if (board[y, x].State == TileState.Activated) {
                throw new ArgumentException("This square is already activated.");
            }

            board[y, x].Flag();
            if (board[y, x].State == TileState.Flagged) {
                Flags++;
            } else {
                Flags--;
            }
        }

        /// <include file='minesweeper.xml' path='minesweeper/members[@name="board"]/CheckForWin'/>
        public bool CheckForWin() {
            bool won = true;

            for (int i = 0; i < Rows; i++) {
                for (int j = 0; j < Cols; j++) {
                    Tile tile = board[i, j];
                    if (tile.IsBomb) {
                        won = won && tile.State == TileState.Flagged;
                    } else {
                        won = won && tile.State == TileState.Activated;
                    }

                    if (!won) {
                        break;
                    }
                }

                if (!won) {
                    break;
                }
            }

            return won;
        }

        public override string ToString() {
            int rowCounter = Rows;
            int colCounter;

            StringBuilder builder = new((int)(Rows * Cols * 2.5));
            builder.Append("     A");
            for (colCounter = 1; colCounter < Cols && colCounter < 26; colCounter++) {
                char toPrint = (char)(colCounter + 65);
                builder.Append($" {toPrint}");
            }

            for (colCounter = 26; colCounter < Cols && colCounter < 52; colCounter++) {
                char toPrint = (char)(colCounter + 71);
                builder.Append($" {toPrint}");
            }

            builder.Append('\n');

            for (int row = 0; row < Rows; row++) {
                builder.Append($"{rowCounter,3} [");
                rowCounter--;
                for (int col = 0; col < Cols; col++) {
                    Tile square = board[row, col];
                    if (gameEnd && (square.State == TileState.Flagged && !square.IsBomb)) {
                        builder.Append((col == Cols - 1) ? "X" : "X ");
                    } else {
                        builder.Append((col == Cols - 1) ? square.ToString() : square + " ");
                    }
                }
                builder.Append("]\n");
            }

            return builder.ToString();
        }
    }
}