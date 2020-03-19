using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MathematicalSetViewer
{
    public partial class MainForm : Form
    {

        // TODO: REMOVE TEMPORARY SOLUTIONS
        public int TempZoomSpeed { get; private set; }

        public bool TempMovementUp { get; private set; }

        public bool TempMovementDown { get; private set; }

        public bool TempMovementLeft { get; private set; }

        public bool TempMovementRight { get; private set; }

        public bool TempPause { get; private set; }

        private bool _MenuVisible = true;
        /// <summary>
        /// The MenuVisibility variable. When the value is set, it will update the MainMenu visibility.
        /// </summary>
        public bool TempMenuVisible
        {
            get { return _MenuVisible; }
            set
            {
                // TODO: is checking to ensure the value has changed before attempting visibility change worthwhile?
                _MenuVisible = value;
                try
                {
                    this.MainMenuStrip.Visible = _MenuVisible;
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    Debug.WriteLine("ERROR CAUGHT WHEN UPDATING MENU VISIBILITY?");
                }
            }
        }



        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Toggles the visibility for the menu bar, and the minimize/exit buttons.
        /// </summary>
        /// <param name="isVisible">False to hide, true to show</param>
        private void MenuBarVisibility(bool isVisible)
        {
            TempMenuVisible = isVisible;
            this.MainFormMainMenuStrip.Visible = isVisible;
            this.MinimizeButton.Visible = isVisible;
            this.ExitButton.Visible = isVisible;
        }

        /// <summary>
        /// A toggle for the display movement. 
        /// </summary>
        /// <param name="isMovement">False to disable display movement, true to enable display movement</param>
        private void DisplayMovement(bool isMovement)
        {
            TempPause = isMovement;
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Exits the application.
        /// TODO: saves data?
        /// </summary>
        private void CloseApplication()
        {
            Debug.Print("Exiting application @ {0}", DateTime.Now.ToString());
            Application.Exit();
        }

        /// <summary>
        /// Toggle enable/disable keyboard input. if disabled it will just use 
        /// a reccomended value to focus on
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlsInput_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Toggle to enable/disable smooth acceleration. Having this enabled 
        /// will iteratively change the value for pan movements.
        /// (think of csgo movement, where it slowly moves to direction A, and
        /// tapping in the alternate direction will stop it, but if no tap and 
        /// they stop pressing A it will make a smooth stop).
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlsSmoothAcceleration_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Sets the zoom speed to 0 to stop the zooming. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSpeedNone_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Pauses display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlsPause_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Open window to set custom zoom speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSpeedCustom_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Sets the active color pallet to the full range of colors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSettingsFullColor_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Sets the active color pallet an 8-bit set of colors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSettings8Bit_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Opens a window for the user to create their own list of colors.
        /// Updates the active color pallet to the user defined list.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSettingsCustom_Click(object sender, EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Menu exit button is clicked, double check before calling exiting procedure.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewExit_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Exit application?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                CloseApplication();
            }
        }

        /// <summary>
        /// Minimizes the window, pauses zoom?, but does not pause rendering
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MinimizeButton_Click(object sender, System.EventArgs e)
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Calls the exit application handler without confirming if user wants to exit.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {
            CloseApplication();
        }


        /// <summary>
        /// Hides the menu bar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewHideMenu_Click(object sender, EventArgs e)
        {
            MenuBarVisibility(false);
            updateText();
        }

        /// <summary>
        /// Hides menu bar and resumes display. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewHideMenuAndResume_Click(object sender, EventArgs e)
        {
            MenuBarVisibility(false);
            DisplayMovement(true);
            updateText();
        }


        /// <summary>
        /// Handles key presses such as directional panning 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case ' ':
                    // TODO: pause on space
                    DisplayMovement(!TempPause);
                    break;
                case '\u001b':
                    // TODO: unhide menu on escape                    
                    if (TempMenuVisible)
                    {
                        MenuBarVisibility(false);
                    } else
                    {
                        MenuBarVisibility(true);
                    }
                    break;

            }
            updateText();


        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    TempMovementUp = true;
                    break;

                case Keys.Down:
                case Keys.S:
                    TempMovementDown = true;
                    break;

                case Keys.Left:
                case Keys.A:
                    TempMovementLeft = true;
                    break;

                case Keys.Right:
                case Keys.D:
                    TempMovementRight = true;
                    break;
            }
            updateText();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                case Keys.W:
                    TempMovementUp = false;
                    break;

                case Keys.Down:
                case Keys.S:
                    TempMovementDown = false;
                    break;

                case Keys.Left:
                case Keys.A:
                    TempMovementLeft = false;
                    break;

                case Keys.Right:
                case Keys.D:
                    TempMovementRight = false;
                    break;
            }
            updateText();
        }

        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Mouse wheel up
                ++TempZoomSpeed;
            }
            else
            {
                // Mouse wheel down
                --TempZoomSpeed;
            }
            updateText();
        }

        private void updateText()
        {
            Point p = this.PointToClient(System.Windows.Forms.Cursor.Position);
            Point c = Cursor.Position;
            Debug.Print(string.Format("<{0,4},{1,4}>|<{2,4},{3,4}> {4}{5}{6}{7} {8}{9} {10,3}",
                p.X.ToString(), p.Y.ToString(),
                c.X.ToString(), c.Y.ToString(),
                (TempMovementUp ? "↑" : " "),
                (TempMovementDown ? "↓" : " "),
                (TempMovementLeft ? "←" : " "),
                (TempMovementRight ? "→" : " "),
                (TempPause ? "P" : " "),
                (TempMenuVisible ? "M" : " "),
                TempZoomSpeed.ToString()));

        }
    }
}
