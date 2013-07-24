using System;
using System.Windows.Forms;

namespace TickTackToe
{
    /// <summary>
    ///     This class will show game pop ups to update user of the game status.
    /// </summary>
    public partial class PopUpForm : Form
    {
        #region Public Methods

        public PopUpForm()
        {
            InitializeComponent();
        }

        /// <summary>
        ///     Set user massage text
        /// </summary>
        /// <param name="p"></param>
        public void SetText(string p)
        {
            richTextBox1.Text = p;
        }

        /// <summary>
        ///     Gets user massage text.
        /// </summary>
        /// <returns></returns>
        public string GetText()
        {
            return richTextBox1.Text;
        }

        /// <summary>
        ///     Close the form.
        /// </summary>
        public void CloseForm()
        {
            this.Close();
        }

        #endregion Public Methods

        #region Private Methods

        /// <summary>
        ///     Handle button clicked event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion Private Methods
    }
}
