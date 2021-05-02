package minesweeper;

// import java.time.Duration;
// import java.time.Instant;
import java.util.HashSet;
import java.util.Random;

public class Board {

    private class LocationTuple {
        private int x;
        private int y;

        public LocationTuple(int x, int y) {
            this.x = x;
            this.y = y;
        }

        @Override
        public boolean equals(Object o) {
            if (o instanceof LocationTuple) {
                LocationTuple other = (LocationTuple) o;
                return this.x == other.x && this.y == other.y;
            }
            return false;
        }

        @Override
        public int hashCode() {
            double code = x + y;
            return (int) code;
        }
    }

    private static final Random RNG = new Random();
    private final int rows;
    private final int cols;
    private final int numberOfBombs;
    private final boolean debug;
    private int flags;
    private Square[][] squares;

    public Board(int rows, int cols, int numberOfBombs) {
        this(rows, cols, numberOfBombs, false);
    }

    public Board(int rows, int cols, int numberOfBombs, boolean debug) {
        this.rows = rows;
        this.cols = cols;
        this.numberOfBombs = numberOfBombs;
        this.squares = new Square[rows][cols];
        this.flags = 0;
        this.debug = debug;
    }

    public int getFlags() {
        return flags;
    }
    
    public int getNumberOfBombs() {
        return numberOfBombs;
    }

    public int convertX(char x) throws IllegalArgumentException {
        int pos = (int)x;
        if (pos < 65 || (pos > 90 && pos < 97) || pos > 122)
            throw new IllegalArgumentException("Invalid character.");

        return pos < 97 ? pos-65 : pos-71;
    }

    public int convertY(int y) {
        return rows - y;
    }

    public void fillBoard() {
        // Filling the board with squares
        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++)
                squares[row][col] = new Square();

        // Generating random unique locations for the bombs to be located
        HashSet<LocationTuple> bombLocations = new HashSet<>();
        while (bombLocations.size() < numberOfBombs) {
            int x = RNG.nextInt(cols);
            int y = RNG.nextInt(rows);
            LocationTuple tuple = this.new LocationTuple(x, y);
            if (!bombLocations.contains(tuple))
                bombLocations.add(tuple);
        }

        // Toggling the bombs at each specified location
        for (LocationTuple location : bombLocations) {
            int col = location.x;
            int row = location.y;
            squares[row][col].setBomb();
        }

        // Calculating the number of bombs next to each square
        for (int row = 0; row < rows; row++)
            for (int col = 0; col < cols; col++) {

                Square current = squares[row][col];
                int[][] neighborLocations = {{row-1, col-1}, {row-1, col}, {row-1, col+1}, {row, col-1}, 
                    {row, col+1}, {row+1, col-1}, {row+1, col}, {row+1, col+1}};

                for (int[] location : neighborLocations)
                    if (location[0] > -1 && location[0] < rows && location[1] > -1 && location[1] < cols) {
                        Square neighbor = squares[location[0]][location[1]];
                        if (neighbor.isBomb())
                            current.incrementBombs();
                    }
            }
    }

    public void activateAll() {
        for (Square[] row : squares)
            for (Square square : row) {
                square.activate();
                if (!square.isBomb() && square.isFlagged()) {
                    square.reveal();
                }
            }
    }

    private boolean activateActivated(int x, int y) {
        int[][] neighbors = {{x-1, y-1}, {x, y-1}, {x+1, y-1}, {x-1, y}, {x+1, y}, {x-1, y+1}, {x, y+1}, {x+1, y+1}};
        boolean activatedBomb = false;

        for (int[] loc : neighbors)
            if (loc[0] >= 0 && loc[1] >= 0 && loc[0] < cols && loc[1] < rows) {
                Square neighbor = squares[loc[1]][loc[0]];
                if (!neighbor.isActivated() && !neighbor.isFlagged()) {
                    activatedBomb = activatedBomb ? true : activateAtPostion(loc[0], loc[1]);
                }
            }

        return activatedBomb;
    }

    public boolean activateAtPostion(int x, int y) throws UnsupportedOperationException {
        // Throws an exception if position is not on the board
        if (x < 0 || y < 0 || x >= cols || y >= rows)
            throw new UnsupportedOperationException("Invalid location.");

        // Throws an exception if the square is flagged
        if (squares[y][x].isFlagged())
            throw new UnsupportedOperationException("That square is currently flagged.");

        // Activates all unactivated and unflagged squares surrounding an already activated square
        if (squares[y][x].isActivated()) {
            boolean bombActivated = activateActivated(x, y);
            if (bombActivated) {
                return true;
            }
        }

        Square square = squares[y][x];

        square.activate();

        // Returns true if a bomb was activated
        if (square.isBomb())
            return true;

        // Recursively activates each square adjacent to the activated square if the square is adjacent to 0 bombs
        if (!square.isBomb() && square.getNumberOfBombs() == 0) {
            int[][] neighbors = {{x-1, y-1}, {x, y-1}, {x+1, y-1}, {x-1, y}, {x+1, y}, {x-1, y+1}, {x, y+1}, {x+1, y+1}};

            for (int[] loc : neighbors)
                if (loc[0] >= 0 && loc[1] >= 0 && loc[0] < cols && loc[1] < rows) {
                    Square neighbor = squares[loc[1]][loc[0]];
                    if (!neighbor.isActivated())
                        activateAtPostion(loc[0], loc[1]);
                }
        }

        // Returns false if the activated square is not a bomb
        return false;
    }

    public void flagPosition(int x, int y) {
        // Throws an exception if position is not on the board
        if (x < 0 || y < 0 || x >= cols || y >= rows)
            throw new UnsupportedOperationException("Invalid Location.");

        // Throws an exception if the square has been previously activated
        if (squares[y][x].isActivated())
            throw new UnsupportedOperationException("That square is already activated.");

        squares[y][x].flag();
        if (squares[y][x].isFlagged())
            flags++;
        else
            flags--;
    }

    public boolean checkWin() {
        boolean won = true;
        for (Square[] row : squares) {
            for (Square square : row) {
                if (square.isBomb())
                    won = !won ? false : square.isFlagged();
                else
                    won = !won ? false : square.isActivated();
                
                if (!won)
                    break;
            }
            if (!won)
                break;
        }

        return won;
    }

    public void solve() throws UnsupportedOperationException {
        if (!debug)
            throw new UnsupportedOperationException("solve() method can only be called in debug mode");

        for (Square[] row : squares)
            for (Square square : row) {
                if (square.isBomb())
                    square.flag();
                else if (!square.isActivated())
                    square.activate();
            }
    }

    @Override
    public String toString() {
        String board = "";
        int rowCounter = rows;
        int colCounter = 0;

        // Printing the top row (A B C D E...)
        board += String.format("%5c", 'A');

        for (colCounter = 1; colCounter < cols && colCounter < 26; colCounter++) {
            char toPrint = (char)(colCounter + 65);
            board += String.format("%2c", toPrint);
        }

        for (colCounter = 26; colCounter < cols && colCounter < 52; colCounter++) {
            char toPrint = (char)(colCounter + 71);
            board += String.format("%2c", toPrint);
        }

        board += "\n";

        // Printing each row (1 [- - 1 : * X ...])
        for (int row = 0; row < rows; row++) {
            board += String.format("%2d [", rowCounter);
            rowCounter--;
            for (int col = 0; col < cols; col++) {
                Square square = squares[row][col];
                board += (col == cols - 1) ? square : square + " ";
            }
            board += "]\n";
        }
        return board;
    }

    @Override
    public int hashCode() {
        return rows * cols;
    }

    // public static void main(String[] args) {
    //     Instant start = Instant.now();
    //     Board board = new Board(50, 50, 2500, true);
    //     board.fillBoard();
    //     // System.out.println(board);
    //     // System.out.println(board.activateAtPostion(board.convertX(4), board.convertY(3)));
    //     System.out.println(board);

    //     board.solve();
    //     System.out.println(board);
    //     System.out.println(board.checkWin());
    //     Instant end = Instant.now();
    //     Duration elapsed = Duration.between(start, end);
        
    //     System.out.println(elapsed.toSeconds() + "." + String.format("%03d", elapsed.toMillis() % 1000));
    //     // board.activateAll();
    //     // System.out.println(board);
    // }
}
