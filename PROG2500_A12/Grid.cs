using System;

namespace MonoGame_04_2D_TicTacToe
{
    public class Grid
    {
        // This is to represent the possible values in the grid (X, O, Z, dot) ... some clean self proclaimed variables
        public enum gridVal { X = 0, O = 1, Z = 2, dot = 3 };

        // Array to keep track of the players' turns
        private gridVal[] turn = { gridVal.X, gridVal.O, gridVal.Z };
        // another 2D array to represent the game board as a whole
        private gridVal[,] grid;
        //and another 2D array to keep track of selected positions
        private Boolean[,] selection;
        // basic Array to keep track of the current selection position
        private int[] current;
        // Variable to store the winner ... the function getWhoWon below will check who won the game
        private gridVal WhoWon;

        // Time for a constructor to initialize the grid and selection arrays
        public Grid()
        {
            grid = new gridVal[3, 3];
            selection = new Boolean[3, 3];
            current = new int[2];
            WhoWon = gridVal.dot;
            setAllGridPos(gridVal.dot); // Initialize all positions to 'dot' ... down below, the code makes sure dot cant win 
            setAllNotSelected(); // Initialize all selections to false
        }

        // Method to set a specific position in the grid to a specific value
        public void setGridPos(gridVal v, int x, int y)
        {
            grid[x, y] = v;
        }

        // Method to set all positions in the grid to a specific value
        public void setAllGridPos(gridVal v)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    setGridPos(v, i, j);
                }
            }
        }

        // another Method to set all positions in the selection array to false
        public void setAllNotSelected()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    selection[i, j] = false;
                }
            }
        }

     
        public gridVal getWhoWon() //This method is called in the Update method of Game1 to check if there is a winner after each move
        {
            foreach (var player in turn)
            {
                // cycle through and check rows and columns for a win
                for (int i = 0; i < grid.GetLength(0); i++)
                {
                    if ((grid[i, 0] == player) && (grid[i, 1] == player) && (grid[i, 2] == player))
                    {
                        return player;
                    }

                    if ((grid[0, i] == player) && (grid[1, i] == player) && (grid[2, i] == player))
                    {
                        return player;
                    }
                }

                // it is even able to check diagonals for a win !
                if ((grid[0, 0] == player) && (grid[1, 1] == player) && (grid[2, 2] == player))
                {
                    return player;
                }

                if ((grid[2, 0] == player) && (grid[1, 1] == player) && (grid[0, 2] == player))
                {
                    return player;
                }
            }

            // Return 'dot' if no winner is found 'cause dot cant win
            return gridVal.dot;
        }

        // Method to get the current state of the grid
        public gridVal[,] GetGrid()
        {
            return grid;
        }

        // Method to get the current state of the selection array
        public Boolean[,] GetSelection()
        {
            return selection;
        }

        // 1/2 get the current selection position
        public int[] GetCurrent()
        {
            return current;
        }

        // 2/2 set the current selection position
        public void SetCurrent(int x, int y)
        {
            current[0] = x;
            current[1] = y;
        }

        // Method to toggle the selection state of a specific position
        public void ToggleSelection(int x, int y)
        {
            selection[x, y] = !selection[x, y];
        }

        // Method to update the value of a specific position in the grid
        public void UpdateGridValue(int x, int y)
        {
            int eVal = (int)grid[x, y];
            int max_eVal = Enum.GetNames(typeof(gridVal)).Length;
            eVal = (eVal + 1) % max_eVal;
            if (eVal == (int)gridVal.dot) eVal = (eVal + 1) % max_eVal; // Skip the non-winnable shape 'dot' thank you for your service o7
            grid[x, y] = (gridVal)(eVal);
        }
    }
}

