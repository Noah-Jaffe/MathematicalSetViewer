using System;

using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace MathematicalSetViewer
{

    public partial class MainForm : Form
    {
        // TODO: complete a proper calculations thread
        Thread CalculationsThread { get; set; }
        Thread ZoomThread { get; set; }

        public MainForm()
        {
            InitializeComponent();
            // This gets the working area (will not include space hidden by taskbar)
            UpdateMSVDataMainFormLocation();
            //StartBackgroundThreads();
            //MathematicalSetGenerator = new MathematicalSetTester();

        }
        /*
        private void StartBackgroundThreads()
        {
            if (CalculationsThread == null || !CalculationsThread.IsAlive)
            {
                // create a new thread
                CalculationsThread = new Thread(delegate ()
                {
                    CalculationsThread(this, MathematicalSetGenerator);
                })
                {
                    IsBackground = true,
                    Name = "CalculationsThread",
                    //Priority = maybe?
                }.Start();
            }
        } 
      

        private static void CalculationsThread(MainForm mainForm, MathematicalSet mathematicalSetGenerator)
        {
            // TODO: improve how the calculations are done. 
            /*
             * right now it is done by center or mouse location (idk how accurate the mouse locatior is going to be)
             * but it should be that a thread runs and generates images 
             * the images are generated and stiched together and then shown?
             * /
            while (true)
            {
                ImageLocation img = (ImageLocation) mathematicalSetGenerator.CalculateRange();
                MSVData.ImageDB.Add(img);
            }
        }
        */
        /*private static void RunZoomThread(Form mainform, MathematicalSet MathematicalSetGenerator)
      {
          Decimal i = 0M;
          while (MSVData.CalculationsEnabled && MSVData.ZoomSpeed != 0)
          {
              Debug.WriteLine(i++);
              Object map = MathematicalSetGenerator.CalculateRange();
              if (mainform.BackgroundImage != null)
                  mainform.BackgroundImage.Dispose();
              mainform.BackgroundImage = (Bitmap)map;
              Debug.WriteLine("Sleeping before updating again");
              Thread.Sleep(50);
              XY[] t = getZoomed(lowerLeft, upperRight);
              lowerLeft = t[0];
              upperRight = t[1];
          }
      }
      */

        // TODO: update to use mouse if needed


        void SetNewBitmap(Bitmap image)
        {
            if (BackgroundImage != null)
                BackgroundImage.Dispose();
            BackgroundImage = image;
        }

        /// <summary>
        /// Temp function to keep track of whats to do
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void TODO(object sender, EventArgs e)
        {
            Debug.WriteLine($"TODO: {sender.ToString()}");
        }

        
        /// <summary>
        /// Toggles the visibility for the menu bar, and all the minimize/exit buttons.
        /// TODO: should i change to UpdateAllGUIVisibility?
        /// </summary>
        /// <param name="isVisible">False to hide, true to show</param>
        public void UpdateMenuBarVisibility(bool isVisible)
        {
            MSVData.MenuVisible = isVisible;
            MainFormMainMenuStrip.Visible = isVisible;
            MinimizeButton.Visible = isVisible;
            ExitButton.Visible = isVisible;
        }

        /// <summary>
        /// A toggle for the display movement. 
        /// </summary>
        /// <param name="isEnabled">False to disable display movement, true to enable display movement</param>
        private void UpdateCalculationEnabled(bool isEnabled)
        {
            MSVData.RenderEnabled = isEnabled;
            MSVData.CalculationsEnabled = isEnabled;
            this.ControlsPause.Checked = isEnabled;
        }

        /// <summary>
        /// Exits the application.
        /// TODO: saves data?
        /// </summary>
        private void CloseApplication()
        {
            MSVData.Destroy();
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
        }

        /// <summary>
        /// Sets the zoom speed to 0 to stop the zooming. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZoomSpeedNone_Click(object sender, EventArgs e)
        {
            //MSVData.clearSmoothAccelerationData("ZoomDelta");
            MSVData.ZoomSpeed = 0;
        }

        /// <summary>
        /// Pauses display.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PauseResume_CheckedChanged(object sender, EventArgs e)
        {
            UpdateCalculationEnabled(((ToolStripMenuItem)sender).Checked);
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
            using (CustomDecimalInputForm customDecimalInput = new CustomDecimalInputForm(formTitle, formMessage, MSVData.ZoomSpeed, new Decimal[] { -128M, 128M }))
            {
                customDecimalInput.ShowDialog();
                Decimal result = MSVData.ZoomSpeed;
                if (customDecimalInput.Completed)
                {
                    //MSVData.clearSmoothAccelerationData("ZoomDelta");
                    MSVData.ZoomSpeed = result;
                }
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
            var parent = ((ToolStripMenuItem)sender).GetCurrentParent();
            string name = ((ToolStripMenuItem)sender).Text;
            short reset = 0;
            // Keep the sender checked, and set the other ones to unchecked
            foreach (ToolStripMenuItem I in parent.Items)
            {
                if (name == I.Text)
                {
                    if (!I.Checked)
                    {
                        DialogResult dr = MessageBox.Show($"Reset {name}?",
                            $"Are you sure you want to reset the current calculated {name} render?", MessageBoxButtons.YesNo);
                        _ = dr == DialogResult.Yes ? reset++ : reset--;
                    }
                }
                I.Checked = name == I.Text;
            }
            if (reset == 0)
            {
                if (MSVData.MathematicalSets.TryGetValue(name, out Type temp))
                {
                    MSVData.MathematicalSetGenerator = (MathematicalSet)Activator.CreateInstance(temp);
                }
                else
                {
                    Debug.Fail($"Err not found: \nName: {name}\nType: {temp}\nPress 'Ignore' to continue");
                }
            } else if (reset == 1)
            {
                Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod() + " ==> \nhow to reset the current mathematical set generator without losing data? set it to the default zoom?");
            } 
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
            // TODO:
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
            UpdateCalculationEnabled(true);
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
                    UpdateCalculationEnabled(!MSVData.RenderEnabled);
                    break;
                case '\u001b':
                    // TODO: unhide menu on escape                    
                    UpdateMenuBarVisibility(!MSVData.MenuVisible);
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
                MSVData.ZoomSpeed += 1;
            }
            else
            {
                // Mouse wheel down
                MSVData.ZoomSpeed -= 1;
            }

            updateText();
        }

        private void UpdateMSVDataMainFormLocation()
        {
            // TODO: look into optimization for something like this
            // asmV1: (Point P var) put p on stack, access stack each P.?
            // asmV2: (this.PointToClient each .? call) put p in register, access register each P.?
            Point P = PointToClient(System.Windows.Forms.Cursor.Position);
            MSVData.MainFormLocationPoint = new XY
            {
                X = P.X,
                Y = P.Y
            };
        }
        private void updateText()
        {
            Point p = PointToClient(System.Windows.Forms.Cursor.Position);
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

        // TODO: figure out how im changing colors n whatnot
        private void ControlsColorSettingChanged(object sender, EventArgs e)
        {
            Debug.Print($"Updating color palette... {ColorSettingOptions.SelectedItem}");


            Debug.Print(ColorSettingOptions.SelectedItem.ToString());
        }

        // TODO if sender is ToolStripComboBox vs ToolStripMenuItem

        private void UpdateColorPalette(object sender, EventArgs e)
        {
            // TODO if sender is ToolStripComboBox vs ToolStripMenuItem
            switch (ColorSettingOptions.SelectedItem)
            {
                case 0:
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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Load the mathematical sets into the menu
            var keys = MSVData.MathematicalSets.Keys;
            var I = 0;
            foreach (var i in keys)
            {
                ToolStripMenuItem temp = new ToolStripMenuItem()
                {
                    Name = i,
                    AutoSize = true,
                    Text = i,
                    CheckOnClick = true
                };
                temp.Click += new System.EventHandler(this.MathematicalSet_UpdateSet);
                this.MathematicalSetMenuItems[I++] = temp;
            };
            this.MathematicalSetMenuTSMI.DropDownItems.AddRange(this.MathematicalSetMenuItems);

        }
    }

}
