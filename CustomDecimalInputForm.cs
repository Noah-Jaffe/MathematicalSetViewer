using System;
using System.Windows.Forms;

namespace MathematicalSetViewer
{
    public partial class CustomDecimalInputForm : Form
    {
        private Decimal StartingVal { get; set; }
        private Decimal[] Range { get; set; }
        private String Message { get; set; }
        public Decimal Result { get; private set; }
        /// <summary>
        /// Have a comlpeted variable in case we try to access data early for a future design...
        /// </summary>
        public bool Completed { get; private set; }


        public CustomDecimalInputForm(String title, String message, Decimal startingVal = 0M, Decimal[] range = null)
        {
            this.Completed = false;
            this.StartingVal = startingVal;
            this.Range = range;
            this.Text = title;
            this.Message = message;
            InitializeComponent();
        }

        /// <summary>
        /// Close the form and return the value in the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CDIF_Send(object sender, EventArgs e)
        {
            Result = this.numericUpDown.Value;
            this.Completed = true;
            this.Close();
        }

        /// <summary>
        /// Close the form and return the original value from the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CDIF_Cancel(object sender, EventArgs e)
        {
            Result = StartingVal;
            this.Completed = true;
            this.Close();
        }

        private void CDIF_Load(object sender, EventArgs e)
        {
            this.numericUpDown.Value = this.StartingVal;
            try
            {
                // Attempt to set the min
                this.numericUpDown.Minimum = this.Range[0];
                // Attempt to set the max
                this.numericUpDown.Maximum = this.Range[1];
            } finally { }; // Do nothing if it fails.

            this.messageArea.Text = this.Message;
        }
    }
}
