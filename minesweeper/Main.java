package minesweeper;

import java.time.Duration;
import java.time.Instant;
import java.util.Scanner;

public class Main {
    private static final Scanner SCANNER = new Scanner(System.in);
    private static Instant start;

    private static void clear() {
        try {
            new ProcessBuilder("cmd", "/c", "cls").inheritIO().start().waitFor();
            System.out.flush();
        } catch (Exception e) {}
    }

    private static void enterToContinue(String text) {
        System.out.println(text);
        System.out.print("Press enter to continue... ");
        SCANNER.nextLine();
    }

    private static int scanInt(String prompt) throws NumberFormatException {
        System.out.print(prompt);
        String input = SCANNER.nextLine();
        int number = Integer.parseInt(input);
        return number;
    }

    public static void printGame(Board board) {
        Instant current = Instant.now();
        Duration elapsed = Duration.between(start, current);
        System.out.println("Time: " + String.format("%02d", elapsed.toMinutes()) + ":" + String.format("%02d", elapsed.toSecondsPart()));
        System.out.println("Bombs: " + String.format("%03d", board.getNumberOfBombs() - board.getFlags()));
        System.out.println("\n" + board);
    }

    public static void helpCommand() {
        clear();
        enterToContinue("Here is a list of commands:\nh: Shows this message\na <x> <y>: Activates the square at (x, y)\n" +
            "f <x> <y>: Flags the square at (x, y), or unflags it if it is already flagged\nr: Resets the game\nq: Quits the game\n");
    }

    public static boolean playGame(int rows, int cols, int bombs) {
        Board board = new Board(rows, cols, bombs);
        board.fillBoard();
        start = Instant.now();
        
        boolean running = true;
        while (running) {
            clear();
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
                        enterToContinue("\nNot enough arguments!");
                        continue;
                    }

                    try {
                        char x = tokens[1].charAt(0);
                        int y = Integer.parseInt(tokens[2]);
                        boolean bombActivated = board.activateAtPostion(board.convertX(x), board.convertY(y));
                        if (bombActivated) {
                            running = false;
                            clear();
                            System.out.println("Bomb activated from (" + x + ", " + y + ")!\n");
                            board.activateAll();
                        }
                    } catch (NumberFormatException nfe) {
                        enterToContinue("\nFormat: f <x> <y>");
                    } catch (IllegalArgumentException ile) {
                        enterToContinue("\n" + ile.getMessage());
                    } catch (UnsupportedOperationException uoe) {
                        enterToContinue("\n" + uoe.getMessage());
                    }

                    break;

                case "f":
                    if (tokens.length < 3) {
                        enterToContinue("\nNot enough arguments!");
                        continue;
                    }

                    try {
                        char x = tokens[1].charAt(0);
                        int y = Integer.parseInt(tokens[2]);
                        board.flagPosition(board.convertX(x), board.convertY(y));
                    } catch (NumberFormatException nfe) {
                        enterToContinue("\nFormat: f <x> <y>");
                    } catch (IllegalArgumentException ile) {
                        enterToContinue("\n" + ile.getMessage());
                    } catch (UnsupportedOperationException uoe) {
                        enterToContinue("\n" + uoe.getMessage());
                    }

                    break;
                case "r":
                    enterToContinue("\nResetting...\n");
                    return true;
                case "q":
                    System.out.println("\nGoodbye!\n");
                    return false;
                default:
                    enterToContinue("\nInvalid command.");
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
                clear();
                int rows = scanInt("Enter the number of rows on the board (Max 99): ");
                int cols = scanInt("Enter the number of columns on the board (Max 52): ");
                int bombs = scanInt("Enter the number of bombs on the board: ");

                if (rows < 1 || cols < 1 || cols > 52 || rows > 99) {
                    enterToContinue("\nError: Cannot make a board of size " + rows + "x" + cols + "\n");
                    continue;
                }

                if (bombs < 1) {
                    enterToContinue("\nError: Not enough bombs on the board.\n");
                    continue;
                }

                if (bombs > rows * cols) {
                    enterToContinue("\nError: Too many bombs on the board!\n");
                    continue;
                }

                playing = playGame(rows, cols, bombs);
            } catch (NumberFormatException nfe) {
                enterToContinue("\nError: Must enter an integer.\n");
                continue;
            }
        }

        SCANNER.close();
    }
}