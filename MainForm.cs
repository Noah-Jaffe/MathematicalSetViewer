using System;

using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MathematicalSetViewer
{

    public partial class MainForm : Form
    {
        private MathematicalSet MathematicalSetGenerator { get; set; }

        public MainForm()
        {
            InitializeComponent();

            MathematicalSetGenerator = new MandelbrotGenerator();
            XY ScreenDim = new XY
            {
                X = Convert.ToDecimal(Screen.FromControl(this).Bounds.Width), //10M
                Y = Convert.ToDecimal(Screen.FromControl(this).Bounds.Height)//10M
            };
            MSVData.ColorPalette = ColorPaletteGenerator.GenerateIterationColors();
            MathematicalSetGenerator.ScreenDimentions = ScreenDim;
            Object map = MathematicalSetGenerator.CalculateRange(MathematicalSetGenerator.DefaultBotLeft, MathematicalSetGenerator.DefaultTopRight);
            
            SetNewBitmap((Bitmap)map);
        }

        void SetNewBitmap(Bitmap image)
        {
            if (this.BackgroundImage != null)
                this.BackgroundImage.Dispose();
            this.BackgroundImage = image;
        }




        /// <summary>
        /// Toggles the visibility for the menu bar, and all the minimize/exit buttons.
        /// TODO: should i change to UpdateAllGUIVisibility?
        /// </summary>
        /// <param name="isVisible">False to hide, true to show</param>
        public void UpdateMenuBarVisibility(bool isVisible)
        {
            MSVData.MenuVisible = isVisible;
            this.MainFormMainMenuStrip.Visible = isVisible;
            this.MinimizeButton.Visible = isVisible;
            this.ExitButton.Visible = isVisible;
        }

        /// <summary>
        /// A toggle for the display movement. 
        /// </summary>
        /// <param name="isEnabled">False to disable display movement, true to enable display movement</param>
        private void UpdateRenderEnabled(bool isEnabled)
        {
            MSVData.RenderEnabled = isEnabled;
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
        private void ControlsInput_CheckedChanged(object sender, EventArgs e)
        {
            MSVData.RenderEnabled = ((ToolStripMenuItem)sender).Checked;
            updateText();
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
        private void ControlsSmoothAcceleration_CheckedChanged(object sender, EventArgs e)
        {
            MSVData.SmoothAccelerationEnabled = ((ToolStripMenuItem)sender).Checked; 
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Sets the zoom speed to 0 to stop the zooming. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSpeedNone_Click(object sender, EventArgs e)
        {
            MSVData.clearSmoothAccelerationData("ZoomSpeed");
            MSVData.ZoomSpeed = 0;
        }

        /// <summary>
        /// Pauses display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ControlsPause_CheckedChanged(object sender, EventArgs e)
        {
            MSVData.RenderEnabled = ((ToolStripMenuItem)sender).Checked;
        }

        /// <summary>
        /// Open window to set custom zoom speed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSpeedCustom_Click(object sender, EventArgs e)
        {
            String formTitle = "Custom Zoom Speed";
            String formMessage = "Set the zoom speed.\n>0 := Zoom In\n=0 := No Zoom\n< 0 := Zoom out";
            using (CustomDecimalInputForm customDecimalInput = new CustomDecimalInputForm(formTitle, formMessage, MSVData._ZoomSpeed, new Decimal[] { -128M, 128M}))
            {
                customDecimalInput.ShowDialog();
                Decimal result = MSVData._ZoomSpeed;
                if (customDecimalInput.Completed)
                {
                    MSVData.clearSmoothAccelerationData("ZoomSpeed");
                    MSVData.ZoomSpeed = result;
                }

                // do what ever with result...
            }
        }

        /// <summary>
        /// Sets the active Color Palette to the full range of colors.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ColorSettings_CheckedChanged(object sender, EventArgs e)
        {
            // set the sender to checked, and set the other ones to unchecked
            
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /// <summary>
        /// Updates the mathematical set to be used, acts like a radio button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MathematicalSet_UpdateSet(object sender, EventArgs e)
        {
            var item = sender as ToolStripMenuItem;
            // TODO: figure out how to toggle all but the sender in this group
            foreach (var I in item.DropDownItems.OfType<ToolStripMenuItem>().ToList())
            {
                Debug.Print(I.Name);
            }
            // set the sender to checked, and set the other ones to unchecked
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
            if (this.ViewPauseWhenMinimized.Checked)
            {
                MSVData.RenderEnabled = false;
            }
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
            UpdateMenuBarVisibility(false);
            updateText();
        }

        /// <summary>
        /// Hides menu bar and resumes display. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ViewHideMenuAndResume_Click(object sender, EventArgs e)
        {
            UpdateMenuBarVisibility(false);
            UpdateRenderEnabled(true);
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
                    UpdateRenderEnabled(!MSVData.RenderEnabled);
                    break;
                case '\u001b':
                    // TODO: unhide menu on escape                    
                    if (MSVData.MenuVisible)
                    {
                        UpdateMenuBarVisibility(false);
                    } else
                    {
                        UpdateMenuBarVisibility(true);
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
                    MSVData.MovementUp = true;
                    break;

                case Keys.Down:
                case Keys.S:
                    MSVData.MovementDown = true;
                    break;

                case Keys.Left:
                case Keys.A:
                    MSVData.MovementLeft = true;
                    break;

                case Keys.Right:
                case Keys.D:
                    MSVData.MovementRight = true;
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
                    MSVData.MovementUp = false;
                    break;

                case Keys.Down:
                case Keys.S:
                    MSVData.MovementDown = false;
                    break;

                case Keys.Left:
                case Keys.A:
                    MSVData.MovementLeft = false;
                    break;

                case Keys.Right:
                case Keys.D:
                    MSVData.MovementRight = false;
                    break;
            }
            updateText();
        }
        
        /// <summary>
        /// Handles the zoom controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0)
            {
                // Mouse wheel up
                MSVData.ZoomSpeed = 1;
            }
            else
            {
                // Mouse wheel down
                MSVData.ZoomSpeed = -1;
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
                (MSVData.MovementUp ? "↑" : " "),
                (MSVData.MovementDown ? "↓" : " "),
                (MSVData.MovementLeft ? "←" : " "),
                (MSVData.MovementRight ? "→" : " "),
                (MSVData.RenderEnabled ? "P" : " "),
                (MSVData.MenuVisible ? "M" : " "),
                MSVData.ZoomSpeed.ToString()));

        }

        private void ControlsColorSettingChanged(object sender, EventArgs e)
        {
            switch(this.ColorSettingOptions.SelectedIndex)
            {
                case 0:
                    Debug.Print("Generating full colors...");
                    MSVData.ColorPalette = ColorPaletteGenerator.GenerateIterationColors();
                    break;
                case 1:
                    Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod() + " ==> case 1");
                    break;
                case 2:
                    Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod() + " ==> case 2");
                    break;
                default:
                    throw new NotImplementedException();
            }
            Debug.Print(this.ColorSettingOptions.SelectedItem.ToString());
        }


 
    }

}
