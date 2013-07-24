using Microsoft.VisualStudio.TestTools.UnitTesting;
using TickTackToe;

namespace TicTacToeTestingUnit
{
    /// <summary>
    ///     This class will test the game manager class, and the tic tac toe form
    /// </summary>
    [TestClass]
    public class UnitTest1
    {
        #region Private Members

        /// <summary>
        ///     Tic tac toe game manager
        /// </summary>
        private GameManager gameManager;

        #endregion Private Members

        #region GameManager Tests

        /// <summary>
        ///     Test UserPickedTile(int tileNumber),
        ///     Should mark tile as 'x' for chosen tile.
        /// </summary>
        [TestMethod]
        public void TestSingleTileUserPick()
        {
            gameManager = new GameManager();
            gameManager.UserPickedTile(1);

            string val = gameManager.GetTileValue(1);
            Assert.AreEqual(val, "x");
        }

        /// <summary>
        ///     Test UserPickedTile() returned value,
        ///     Should return false if tile chosen is not a valid tile.
        /// </summary>
        [TestMethod]
        public void TestUnvalidTileUserPick()
        {
            gameManager = new GameManager();
            Assert.IsTrue(gameManager.UserPickedTile(1));

            string val = gameManager.GetTileValue(1);
            Assert.AreEqual(val, "x");

            Assert.IsFalse(gameManager.UserPickedTile(1));

            // 11 is not in tile number range
            Assert.IsFalse(gameManager.UserPickedTile(11));

            // -1 is not in tile number range
            Assert.IsFalse(gameManager.UserPickedTile(-1));
        }

        /// <summary>
        ///     Test UserPickedTile(int tileNumber),
        ///     Should mark tile as 'x' each time.
        /// </summary>
        [TestMethod]
        public void TestAllTilesUserPick()
        {
            gameManager = new GameManager();

            for (int i = 0; i < 9; i++)
            {
                gameManager.UserPickedTile(i);

                string val = gameManager.GetTileValue(i);
                Assert.AreEqual(val, "x");
            }
        }

        /// <summary>
        ///     Test PreformComputerMove(),
        ///     Should mark one tile as "y".
        /// </summary>
        [TestMethod]
        public void TestSingleTileComputerPick()
        {
            gameManager = new GameManager();
            gameManager.PreformComputerMove();

            int tileCounter = 0;

            for (int i = 0; i < 9; i++)
            {
                string val = gameManager.GetTileValue(i);
                if (val.Equals("y"))
                {
                    tileCounter++;
                }
            }

            //  Only one tile was marked as 'y'.
            Assert.AreEqual(tileCounter, 1);
        }

        /// <summary>
        ///     Test the IsThereNoMovesLeft(), 
        ///     Should return true only if all 9 tiles are full.
        /// </summary>
        [TestMethod]
        public void TestIsBoardFull()
        {
            gameManager = new GameManager();

            //  Fill 8 tiles, and check the board is not full at each point
            for (int i = 0; i < 8; i++)
            {
                gameManager.PreformComputerMove();
                Assert.IsFalse(gameManager.IsThereNoMovesLeft());
            }

            //  Fill the last tile and check that the board is now full
            gameManager.PreformComputerMove();
            Assert.IsTrue(gameManager.IsThereNoMovesLeft());
        }

        /// <summary>
        ///     Test IsThereAWinner(),
        ///     Should return true only if there is a winner on board (full row, full colomn or diagnol).
        /// </summary>
        [TestMethod]
        public void TestIsThereAWinner()
        {
            //  Row winner
            gameManager = new GameManager();

            gameManager.UserPickedTile(0);
            gameManager.UserPickedTile(1);

            //  Not full row - no winner.
            Assert.IsFalse(gameManager.IsThereAWinner());

            // Full row - user is the winner.
            gameManager.UserPickedTile(2);
            Assert.IsTrue(gameManager.IsThereAWinner());

            // Colomn winner
            gameManager = new GameManager();

            gameManager.UserPickedTile(1);
            gameManager.UserPickedTile(4);

            //  Not full Colomn - no winner.
            Assert.IsFalse(gameManager.IsThereAWinner());

            // Full Colomn - user is the winner.
            gameManager.UserPickedTile(7);
            Assert.IsTrue(gameManager.IsThereAWinner());

            // Diagnol winner
            gameManager = new GameManager();

            gameManager.UserPickedTile(0);
            gameManager.UserPickedTile(4);

            //  Not full Diagnol - no winner.
            Assert.IsFalse(gameManager.IsThereAWinner());

            // Full Diagnol - user is the winner.
            gameManager.UserPickedTile(8);
            Assert.IsTrue(gameManager.IsThereAWinner());
        }

        /// <summary>
        ///     Test that StartNewGame() cleans the board.
        /// </summary>
        [TestMethod]
        public void TestStartNewGameInGameManager()
        {
            gameManager = new GameManager();

            gameManager.UserPickedTile(5);

            // Tile number 5 is marked as user ("x")
            Assert.AreEqual(gameManager.GetTileValue(5), "x");

            gameManager.StartNewGame();

            // Tile number 5 should now be un-marked as user ("x")
            Assert.AreNotEqual(gameManager.GetTileValue(5), "x");
        }

        #endregion GameManager Tests

        #region TicTacToe Form Tests

        /// <summary>
        ///     We Check a single game iteration.
        ///     User picked tile number 5, and computer picked one tile also.
        /// </summary>
        [TestMethod]
        public void TestFormPreformASingleGameIteration()
        {
            TickTacToeForm form = new TickTacToeForm();
            form.PreformASingleGameIteration(5);

            gameManager = form.GetFormGameManager();

            int tileCounter = 0;

            for (int i = 0; i < 9; i++)
            {
                string val = gameManager.GetTileValue(i);
                if (val.Equals("y"))
                {
                    tileCounter++;
                }
            }

            //  Only one tile was marked as 'y'.
            Assert.AreEqual(tileCounter, 1);
            // Tile number 5 is marked as user ("x")
            Assert.AreEqual(gameManager.GetTileValue(5), "x");
        }

        /// <summary>
        ///     Test PreformComputerMove() in the form,
        ///     Should mark a random tile with "y".
        ///     Check if board is full, and for winner.
        /// </summary>
        [TestMethod]
        public void TestFormPreformComputerMove()
        {
            TickTacToeForm form = new TickTacToeForm();
            form.PreformComputerMove();

            gameManager = form.GetFormGameManager();

            int tileCounter = 0;

            for (int i = 0; i < 9; i++)
            {
                string val = gameManager.GetTileValue(i);
                if (val.Equals("y"))
                {
                    tileCounter++;
                }
            }

            //  Only one tile was marked as 'y'.
            Assert.AreEqual(tileCounter, 1);

            for (int i = 0; i < 5; i++)
            {
                form.PreformComputerMove();
            }

            PopUpForm popUpForm = form.GetPopUpForm();
            string massageText = popUpForm.GetText();
            popUpForm.CloseForm();
            Assert.IsTrue(massageText.Contains("Lost"));

        }

        /// <summary>
        ///     Test that StartNewGame() cleans the board.
        /// </summary>
        [TestMethod]
        public void TestStartNewGameInForm()
        {
            TickTacToeForm form = new TickTacToeForm();
            gameManager = form.GetFormGameManager();

            form.PreformASingleGameIteration(5);

            // Tile number 5 is marked as user ("x")
            Assert.AreEqual(gameManager.GetTileValue(5), "x");

            form.StartNewGame();
            // Tile number 5 should now be un-marked as user ("x")
            Assert.AreNotEqual(gameManager.GetTileValue(5), "x");
        }

        #endregion TicTacToe Form Tests
    }
}
