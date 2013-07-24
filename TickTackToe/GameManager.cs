using System;
using System.Collections.Generic;
using System.Linq;

namespace TickTackToe
{
    /// <summary>
    ///     This class will handle the game logic.
    /// </summary>
    public class GameManager
    {
        #region Private Members

        /// <summary>
        ///     Tic Tac Toe board
        /// </summary>
        private TicTacToeBoard board;

        #endregion Private Members

        #region Public Methods

        /// <summary>
        ///     Class builder
        /// </summary>
        public GameManager()
        {
            board = new TicTacToeBoard();
        }

        /// <summary>
        ///     Return true if there is a winner in the game.
        /// </summary>
        /// <returns></returns>
        public bool IsThereAWinner()
        {
            return board.IsWinner('x') || board.IsWinner('y');
        }

        /// <summary>
        ///     Returns true if the game board is full.
        /// </summary>
        /// <returns></returns>
        public bool IsThereNoMovesLeft()
        {
            return board.IsBoardFull();
        }

        /// <summary>
        ///     Mark tile with user value ('x'), and return true if successful.
        /// </summary>
        /// <param name="pointNumber"></param>
        /// <returns></returns>
        public bool UserPickedTile(int pointNumber)
        {
            return board.MarkTile(pointNumber / 3, pointNumber % 3, 'x');
        }

        /// <summary>
        ///     Preform a single computer tile pick, at a random tile,
        ///     And return true if successful.
        /// </summary>
        public bool PreformComputerMove()
        {
            // Check if board is not full
            if (!board.IsBoardFull())
            {
                List<int> emptyTilesList = board.GetAllEmptyTiles();

                // Pick random index
                Random rand = new Random();
                int indexRandom = rand.Next(0, emptyTilesList.Count - 1);

                int tileNumber = emptyTilesList.ElementAt(indexRandom);
                board.MarkTile(tileNumber / 3, tileNumber % 3, 'y');
                return true;
            }
            return false;
        }

        /// <summary>
        ///     Get Value of tile.
        /// </summary>
        /// <param name="tileNumber"></param>
        /// <returns></returns>
        public string GetTileValue(int tileNumber)
        {
            char c = board.GetTileValue(tileNumber / 3, tileNumber % 3);
            return c.Equals('x') || c.Equals('y') ? c.ToString() : "";
        }

        /// <summary>
        ///     Cleans the board, and start new game.
        /// </summary>
        public void StartNewGame()
        {
            board = new TicTacToeBoard();
        }

        #endregion Public Methods
    }
}
