using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace MathematicalSetViewer
{
    /// <summary>
    /// A static class to allow access and communication between the Form data and the calculations to be made.
    /// </summary>
    public static class MSVData
    {

        public static List<ImageLocation> ImageDB = new List<ImageLocation>();

        public static Dictionary<string, Type> MathematicalSets { get; private set; }

        public static string[] ColorPresetNames
        {
            // todo: use reflection to get names?
            get
            {
                return new string[] { "Full Color", "8-bit", "Custom" };
            }
        }
        private static MathematicalSet _MathematicalSetGenerator { get; set; }
        public static MathematicalSet MathematicalSetGenerator { 
            get 
            {
                return _MathematicalSetGenerator;
            }
            set 
            {
                if (_MathematicalSetGenerator != null) {
                    DestroyMathematicalSet();
                }
                _MathematicalSetGenerator = value;
            }
        }

        /// <summary>
        /// Destroys anything that needs to be destroyed such as running background threads and whatnot.
        /// </summary>
        private static void DestroyMathematicalSet()
        {
            // todo nothing yet
        }

        public static XY MouseLocation
        {
            get
            {
                // TODO: to make this relative to the image we are over
                Point c = Cursor.Position;
                return new XY
                {
                    X = c.X - MainFormLocationPoint.X,
                    Y = c.Y - MainFormLocationPoint.Y
                };
            }
        }
        /// <summary>
        /// The top left corner of the main form window
        /// </summary>
        public static XY MainFormLocationPoint { get; set; }
        /// <summary> Used to determine if new calculations are enabled. </summary>
        /// <value>
        /// True := unpaused, free to calculate at any time.
        /// False := paused, no new calculations allowed.
        /// </value>
        public static bool CalculationsEnabled { get; set; }

        /// <summary>
        /// The colors we should be using to display the mathematical set.
        /// </summary>
        /// <remarks>
        /// The last value in the array will be the (non iteration) color by default.
        /// </remarks>
        public static Color[] ColorPalette { get; set; }

        /// <summary>
        /// Used to store the integer resolution of the drawing area in pixles. 
        /// Uses XY.Xi, and XY.Yi
        /// </summary>
        public static XY DrawSize { get; set; }

        /// <summary>
        /// If user input is actively being used to determine movement.
        /// </summary>
        public static bool InputEnabled { get; set; }

        /// <summary> Used to determine if the display is allowed to be changed. </summary>
        /// <value>
        /// True := unpaused, display is free to change.
        /// False := paused, display is locked.
        /// </value>
        public static bool RenderEnabled { get; set; }

        /// <summary> 
        /// Used to determine if the menu bar is displayed or not. </summary>
        public static bool MenuVisible { get; set; }

        /// <summary> 
        /// True when we want to pan downwards (-Y direction), false otherwise. </summary>
        public static bool MovementDown { get; set; }

        /// <summary> 
        /// True when we want to pan left (-X direction), false otherwise. </summary>
        public static bool MovementLeft { get; set; }

        /// <summary> 
        /// True when we want to pan right (+X direction), false otherwise. </summary>
        public static bool MovementRight { get; set; }

        /// <summary> 
        /// True when we want to pan upwards (+Y direction), false otherwise. </summary>
        public static bool MovementUp { get; set; }

        /// <summary>
        /// The plot amount for which we pan over an image/graph area per each tick.
        /// </summary>
        /// <remarks>
        /// This property is effected by <c>SmoothAccelerationEnabled</c>
        /// </remarks>
        public static Decimal PanSpeed { get; set; }

        /// <summary>
        /// The size of the expected generated images. 
        /// Uses XY.Xi, and XY.Yi
        /// </summary>
        public static XY PictureSize { get; set; }
        /// <summary> 
        /// True when we want to use smooth acceleration for movement. </summary>
        public static bool SmoothAccelerationEnabled { get; set; }

        /// <summary> A Decimal value to determine the zoom speed. </summary>
        /// <summary>
        /// When ZoomSpeed > 0 := Zooming in
        /// When ZoomSpeed = 0 := No Zoom
        /// When ZoomSpeed < 0 := Zoom out
        /// </summary>
        /// <remarks>
        /// This property is effected by <c>SmoothAccelerationEnabled</c>
        /// </remarks>
        public static Decimal ZoomSpeed { get; set; }

        /// <summary>
        /// This function retuns a list of values for the deltas per each tick to visualize smooth acceleration
        /// </summary>
        /// <param name="total"></param>
        /// <returns></returns>
        static Decimal[] GetSmoothedList(Decimal total)
        {
            Decimal[] SmoothVals = new Decimal[5];
            Decimal increment = (total / SmoothVals.Length);
            for (int i = 0; i < SmoothVals.Length; ++i)
            {
                // Linearly?
                SmoothVals[i] = increment;
            }
            return SmoothVals;
        }

        /// <summary>
        /// This method will overwrite all saved data and initalize all the values to their 
        /// hardcoded defaults 
        /// </summary>
        public static void InitDefaultValues()
        {
            // The working area is the desktop area of the display, excluding 
            // taskbars, docked windows, and docked tool bars.
            Rectangle ScreenWorkingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            // The bounds are for the entire screen (think fullscreen mode)
            // Rectangle ScreenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;

            MSVData.CalculationsEnabled = true;
            MSVData.ColorPalette = ColorPaletteGenerator.GenerateIterationColors();
            MSVData.DrawSize = new XY
            {
                X = (Decimal)(ScreenWorkingArea.Width - ScreenWorkingArea.X),
                Y = (Decimal)(ScreenWorkingArea.Height - ScreenWorkingArea.Y)
            };
            MSVData.InputEnabled = true;
            MSVData.MenuVisible = true;
            MSVData.MovementDown = false;
            MSVData.MovementLeft = false;
            MSVData.MovementRight = false;
            MSVData.MovementUp = false;
            MSVData.PanSpeed = 0;
            MSVData.RenderEnabled = true;
            MSVData.SmoothAccelerationEnabled = false;
            MSVData.ZoomSpeed = 0;
            MSVData.PictureSize = new XY { Xi = 512, Yi = 512 };
            MathematicalSets = new Dictionary<string, Type>();
            var items = typeof(MathematicalSet).Assembly.GetTypes().Where(type => type.IsSubclassOf(typeof(MathematicalSet))).ToArray();
            for (int i = 0; i < items.Length; ++i)
            {
                Type x = items[i];
                MathematicalSet instance = (MathematicalSet)Activator.CreateInstance(x);
                MathematicalSets.Add(instance.Name, x);
                instance.Destroy();
            }
        }
        /// <summary>
        /// TODO: close all running calculation threads
        /// </summary>
        public static void Destroy()
        {
            Debug.Print("TODO: " + MethodBase.GetCurrentMethod().ReflectedType.FullName + " ==> " + MethodBase.GetCurrentMethod());
        }

        /*
         * commented out because I was just playing with the limits of properties 
        LinkedList _ZoomDeltas = new LinkedList(new[] { 0M });
        public static Decimal ZoomDelta
        {
            get
            {
                _ZoomSpeed += SmoothAccelerationEnabled ? _ZoomDeltas.Pop() : _ZoomDeltas.PopAll();
                return _ZoomSpeed;
            }
            set
            {
                _ZoomDeltas.AddLast(SmoothAccelerationEnabled ? GetSmoothedList(value) : new Decimal[] { value });
            }
        }
         */
        /*
        public static Bitmap StitchImage(XY corner, XY size)
        {
            Bitmap map = new Bitmap(size.Xi, size.Yi, PixelFormat.Format24bppRgb);
            foreach (KeyValuePair<XY, Bitmap> entry in ImageDB)
            {
                (x2 >= y1 && x1 <= y2)
                if (entry.Key.Xi)
            }
        }
        */
        /*
        internal static void clearSmoothAccelerationData(string v)
        {
            switch (v)
            {
                case "ZoomDelta":
                    _ZoomSpeed = _ZoomDeltas.PopAll();
                    break;
            }
        }
        */
    }

}
