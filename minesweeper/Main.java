package minesweeper;

import java.time.Duration;
import java.time.Instant;
import java.util.Scanner;

public class Main {
    private static final Scanner SCANNER = new Scanner(System.in);
    private static Instant start;

    private static int scanInt(String prompt) throws NumberFormatException {
        System.out.print(prompt);
        String input = SCANNER.nextLine();
        int number = Integer.parseInt(input);
        return number;
    }

    public static void printGame(Board board) {
        Instant current = Instant.now();
        Duration elapsed = Duration.between(start, current);
        System.out.println("\nTime: " + String.format("%02d", elapsed.toMinutes()) + ":" + String.format("%02d", elapsed.toSecondsPart()));
        System.out.println("Bombs: " + String.format("%03d", board.getNumberOfBombs() - board.getFlags()));
        System.out.println("\n" + board);
    }

    public static void helpCommand() {
        System.out.println("Here is a list of commands:\nh: Shows this message\na <x> <y>: Activates the square at (x, y)\n" +
            "f <x> <y>: Flags the square at (x, y), or unflags it if it is already flagged\nr: Resets the game\nq: Quits the game");
    }

    public static boolean playGame(int rows, int cols, int bombs) {
        Board board = new Board(rows, cols, bombs);
        board.fillBoard();
        start = Instant.now();
        
        boolean running = true;
        while (running) {
            printGame(board);
            System.out.print("Enter a move (type 'h' for a list of commands): ");
            String command = SCANNER.nextLine();
            String[] tokens = command.split(" ");
            switch (tokens[0]) {
                case "h":
                    helpCommand();
                    break;
                case "a":
                    if (tokens.length < 3) {
                        System.out.println("\nNot enough arguments!");
                        continue;
                    }

                    try {
                        char x = tokens[1].charAt(0);
                        int y = Integer.parseInt(tokens[2]);
                        boolean bombActivated = board.activateAtPostion(board.convertX(x), board.convertY(y));
                        if (bombActivated) {
                            running = false;
                            System.out.println("\nBomb activated from (" + x + ", " + y + ")!");
                            board.activateAll();
                        }
                    } catch (NumberFormatException nfe) {
                        System.out.println("\nFormat: a <x> <y>");
                    } catch (IllegalArgumentException ile) {
                        System.out.println("\n" + ile.getMessage());
                    } catch (UnsupportedOperationException uoe) {
                        System.out.println("\n" + uoe.getMessage());
                    }

                    break;

                case "f":
                    if (tokens.length < 3) {
                        System.out.println("\nNot enough arguments!");
                        continue;
                    }

                    try {
                        char x = tokens[1].charAt(0);
                        int y = Integer.parseInt(tokens[2]);
                        board.flagPosition(board.convertX(x), board.convertY(y));
                    } catch (NumberFormatException nfe) {
                        System.out.println("\nFormat: f <x> <y>");
                    } catch (IllegalArgumentException ile) {
                        System.out.println("\n" + ile.getMessage());
                    } catch (UnsupportedOperationException uoe) {
                        System.out.println("\n" + uoe.getMessage());
                    }

                    break;
                case "r":
                    System.out.println("\nResetting...\n");
                    return true;
                case "q":
                    System.out.println("\nGoodbye!\n");
                    return false;
                default:
                    System.out.println("\nInvalid command.");
                    continue;
            }

            if (board.checkWin()) {
                running = false;
            }
        }

        if (board.checkWin()) {
            System.out.println("\nYou win!");
        }

        printGame(board);

        while (true) {
            System.out.print("Do you want to play again? (y/n): ");
            String input = SCANNER.nextLine();
            switch (input.toLowerCase().charAt(0)) {
                case 'y':
                    System.out.println();
                    return true;
                case 'n':
                    System.out.println("Goodbye!");
                    return false;
                default:
                    System.out.println("Invalid input.");
            }
        }
    }
    
    public static void main(String[] args) {
        boolean playing = true;
        while (playing) {
            try {
                int rows = scanInt("Enter the number of rows on the board: ");
                int cols = scanInt("Enter the number of columns on the board: ");
                int bombs = scanInt("Enter the number of bombs on the board: ");

                if (rows < 1 || cols < 1 || cols > 52 || rows > 99) {
                    System.out.println("\nError: Cannot make a board of size " + rows + "x" + cols + "\n");
                    continue;
                }

                if (bombs < 1) {
                    System.out.println("\nError: Not enough bombs on the board.\n");
                    continue;
                }

                if (bombs > rows * cols) {
                    System.out.println("\nError: Too many bombs on the board!\n");
                    continue;
                }

                playing = playGame(rows, cols, bombs);
            } catch (NumberFormatException nfe) {
                System.out.println("\nError: Must enter an integer.\n");
                continue;
            }
        }

        SCANNER.close();
    }
}