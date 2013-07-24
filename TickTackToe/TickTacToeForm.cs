using System;
using System.Windows.Forms;

namespace TickTackToe
{
    /// <summary>
    ///     This is a Tic Tac Toe win form, 
    ///     Handling all UI input and output for the Tic Tac Toe game.
    /// </summary>
    public partial class TickTacToeForm : Form
    {
        #region Private Mambers

        /// <summary>
        ///     Tic Tac Toe game manager.
        /// </summary>
        private GameManager gameManager;

        /// <summary>
        ///     Pop up Form
        /// </summary>
        private PopUpForm popUpForm;

        #endregion Private Mambers

        #region Event Handlers

        /// <summary>
        ///     Handle any button click event from user.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Click(object sender, EventArgs e)
        {
            int point = GetTileNumberBySender(sender);
            PreformASingleGameIteration(point);
        }

        #endregion Event Handlers

        #region Public Methods

        public TickTacToeForm()
        {
            InitializeComponent();
            gameManager = new GameManager();
            popUpForm = new PopUpForm();
        }

        /// <summary>
        ///     Preform a single game iteration,
        ///     Mark the input tile from user, check for winner.
        ///     Preform a computer tile pick and check for winner again.
        ///     Check that the board is not full.
        /// </summary>
        /// <param name="TileNumber"></param>
        public void PreformASingleGameIteration(int TileNumber)
        {
            //  Try to place 'x' on tile
            bool tileValid = gameManager.UserPickedTile(TileNumber);

            // Check if the tile is valid
            if (!tileValid)
            {
                PopUpPointNotValid();
                return;
            }

            RefreshBoard();

            //  Check if the user tile pick concluded in victory
            if (gameManager.IsThereAWinner())
            {
                PopUpWinner(true);
                StartNewGame();
            }
            else
            {
                // Computer makes a tile pick
                PreformComputerMove();
            }
            // Check if the board is full
            if (gameManager.IsThereNoMovesLeft())
            {
                PopUpEndOfGame();
            }
        }

        /// <summary>
        ///     Preform a computer move, check if won, and refresh board.
        /// </summary>
        public void PreformComputerMove()
        {
            // Check if the board is full
            if (gameManager.IsThereNoMovesLeft())
            {
                PopUpEndOfGame();
            }
            else
            {
                // Computer picks tile
                gameManager.PreformComputerMove();

                RefreshBoard();

                // Check if the computer tile pick concluded in victory
                if (gameManager.IsThereAWinner())
                {
                    PopUpWinner(false);
                    StartNewGame();
                }
            }
        }

        /// <summary>
        ///     Return the Tile number (0 to 8), of the pressed tile.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static int GetTileNumberBySender(object sender)
        {
            Button b = (Button)sender;
            string name = b.Name;
            string pointNumber = name.Substring(name.Length - 1);
            int point = Convert.ToInt16(pointNumber);
            return point;
        }

        /// <summary>
        ///     Refresh the board text, acording to the game manager.
        /// </summary>
        public void RefreshBoard()
        {
            button0.Text = gameManager.GetTileValue(0);
            button1.Text = gameManager.GetTileValue(1);
            button2.Text = gameManager.GetTileValue(2);
            button3.Text = gameManager.GetTileValue(3);
            button4.Text = gameManager.GetTileValue(4);
            button5.Text = gameManager.GetTileValue(5);
            button6.Text = gameManager.GetTileValue(6);
            button7.Text = gameManager.GetTileValue(7);
            button8.Text = gameManager.GetTileValue(8);
        }

        /// <summary>
        ///     Start a new Game.
        /// </summary>
        public void StartNewGame()
        {
            gameManager.StartNewGame();
            RefreshBoard();
        }

        #region PopUp

        /// <summary>
        ///     End game, and alert the user.
        /// </summary>
        public void PopUpEndOfGame()
        {
            popUpForm = new PopUpForm();
            popUpForm.SetText("No one won, please try again.");
            popUpForm.Show();
            StartNewGame();
        }

        /// <summary>
        ///     Alert the user of the winner.
        /// </summary>
        /// <param name="userIsTheWinner">
        ///     True if user won, False otherwise.
        /// </param>
        public void PopUpWinner(bool userIsTheWinner)
        {
            popUpForm = new PopUpForm();
            if (userIsTheWinner) popUpForm.SetText("You are the winner!");
            else popUpForm.SetText("You Lost");            
            popUpForm.Show();
        }

        /// <summary>
        ///     Alert the user for un valid tile pick.
        /// </summary>
        public void PopUpPointNotValid()
        {
            popUpForm = new PopUpForm();
            popUpForm.SetText("Please chose a valid tile.");
            popUpForm.Show();
        }

        #endregion PopUp

        /// <summary>
        ///     Return the form game manager
        /// </summary>
        /// <returns></returns>
        public GameManager GetFormGameManager()
        {
            return gameManager;
        }

        /// <summary>
        ///     Return the form pop up form
        /// </summary>
        /// <returns></returns>
        public PopUpForm GetPopUpForm()
        {
            return popUpForm;
        }

        #endregion Public Methods
    }
}
