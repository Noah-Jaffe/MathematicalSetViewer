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
            Completed = false;
            StartingVal = startingVal;
            Range = range;
            Text = title;
            Message = message;
            InitializeComponent();
        }

        /// <summary>
        /// Close the form and return the value in the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CDIF_Send(object sender, EventArgs e)
        {
            Result = numericUpDown.Value;
            Completed = true;
            Close();
        }

        /// <summary>
        /// Close the form and return the original value from the input.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CDIF_Cancel(object sender, EventArgs e)
        {
            Result = StartingVal;
            Completed = true;
            Close();
        }

        private void CDIF_Load(object sender, EventArgs e)
        {
            numericUpDown.Value = StartingVal;
            try
            {
                // Attempt to set the min
                numericUpDown.Minimum = Range[0];
                // Attempt to set the max
                numericUpDown.Maximum = Range[1];
            }
            finally { }; // Do nothing if it fails.

            messageArea.Text = Message;
        }
    }
}
