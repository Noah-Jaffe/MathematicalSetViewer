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
        }
      

        private void ViewResume_Click(object sender, EventArgs e)
        {

        }
    }
}
