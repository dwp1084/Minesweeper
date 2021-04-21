package minesweeper;

public class Square {
    private int numberOfBombs;
    private boolean bomb;
    private boolean activated;
    private boolean flagged;

    public Square() {
        this.numberOfBombs = 0;
        this.bomb = false;
        this.activated = false;
        this.flagged = false;
    }

    // Getters

    public int getNumberOfBombs() {
        return numberOfBombs;
    }
    
    public boolean isBomb() {
        return bomb;
    }

    public boolean isActivated() {
        return activated;
    }
    
    public boolean isFlagged() {
        return flagged;
    }

    // Setters / toggles
    
    public void setBomb() {
        bomb = true;
    }

    public void activate() {
        if (!flagged) {
            activated = true;
        }
    }

    public void flag() {
        if (!activated) {
            flagged = !flagged;
        }
    }

    public void incrementBombs() {
        numberOfBombs++;
    }

    public void reveal() {
        flagged = true;
        activated = true;
    }

    @Override
    public String toString() {
        if (flagged && activated && !bomb) {
            return "X";
        }

        if (flagged) {
            return ":";
        }

        if (!activated) {
            return "-";
        }

        if (bomb) {
            return "*";
        }

        return numberOfBombs == 0 ? " " : numberOfBombs + "";
    }
}
