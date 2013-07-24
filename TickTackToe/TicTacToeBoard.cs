using System.Collections.Generic;

namespace TickTackToe
{
    /// <summary>
    ///     This class is a tic tac toe playing board
    /// </summary>
    public class TicTacToeBoard
    {
        #region Private Members

        /// <summary>
        ///     Array of chars, represnting the playing board.
        /// </summary>
        private char[,] board;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        ///     Class builder
        /// </summary>
        public TicTacToeBoard()
        {
            board = new char[3, 3];
        }

        /// <summary>
        ///     Mark tile with enterd value.
        ///     return true if successful.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool MarkTile(int row, int column, char value)
        {
            if ((value.Equals('x') || value.Equals('y'))
                && row >= 0 && row <= 2 && column >= 0 && column <= 2
                && IsTileAvailble(row, column))
            {
                board[row, column] = value;
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Gets tile value.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public char GetTileValue(int row, int column)
        {
            if (row >= 0 && row <= 2 && column >= 0 && column <= 2)
            {
                return board[row, column];
            }
            return ' ';
        }

        /// <summary>
        ///     Returns a list of all un-marked tiles
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllEmptyTiles()
        {
            List<int> emptyTilesList = new List<int>();

            // Go over board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    // Check if the tile un marked
                    if (board[i, j] != 'x' && board[i, j] != 'y')
                        emptyTilesList.Add(i * 3 + j);
                }
            }
            return emptyTilesList;
        }

        /// <summary>
        ///     Return true if the value enterd is the winner
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool IsWinner(char value)
        {
            // Check all 3 rows
            if (board[0, 0] == value && board[0, 1] == value && board[0, 2] == value)
            {
                return true;
            }
            if (board[1, 0] == value && board[1, 1] == value && board[1, 2] == value)
            {
                return true;
            }
            if (board[2, 0] == value && board[2, 1] == value && board[2, 2] == value)
            {
                return true;
            }

            // Check all 3 columns
            if (board[0, 0] == value && board[1, 0] == value && board[2, 0] == value)
            {
                return true;
            }
            if (board[0, 1] == value && board[1, 1] == value && board[2, 1] == value)
            {
                return true;
            } if (board[0, 2] == value && board[1, 2] == value && board[2, 2] == value)
            {
                return true;
            }

            //  Check 2 diagonals
            if (board[0, 0] == value && board[1, 1] == value && board[2, 2] == value)
            {
                return true;
            }
            if (board[0, 2] == value && board[1, 1] == value && board[2, 0] == value)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        ///     Returns true if all the board tiles are marked
        /// </summary>
        /// <returns></returns>
        public bool IsBoardFull()
        {
            return GetAllEmptyTiles().Count == 0;
        }

        /// <summary>
        ///     Return true if input tile is un-marked.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="column"></param>
        /// <returns></returns>
        public bool IsTileAvailble(int row, int column)
        {
            char tileVal = GetTileValue(row, column);
            return !tileVal.Equals('x') && !tileVal.Equals('y');
        }

        /// <summary>
        ///     Return a string representation of the board
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("{0} , {1} , {2} \n {3} , {4} , {5} \n {6} , {7} , {8} \n",
                board[0, 0], board[0, 1], board[0, 1],
                board[1, 0], board[1, 1], board[1, 2],
                board[2, 0], board[2, 1], board[2, 2]);
        }

        #endregion Public Methods
    }
}
