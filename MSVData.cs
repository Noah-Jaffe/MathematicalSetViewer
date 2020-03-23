using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
namespace MathematicalSetViewer
{
    public static class MSVData
    {
        
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

        // TODO: see if byte array for movement is better?
        //public static byte ActiveMovement { get; set; }

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

        
        /// <summary> Used to determine if the menu bar is displaye.,d or not. </summary>
        /// TODO: see if i want to make these setters fire an event?
        public static bool MenuVisible { get; set; }

        /// <summary> True when we want to pan downwards (-Y direction), false otherwise. </summary>
        public static bool MovementDown { get; set; }

        /// <summary> True when we want to pan left (-X direction), false otherwise. </summary>
        public static bool MovementLeft { get; set; }

        /// <summary> True when we want to pan right (+X direction), false otherwise. </summary>
        public static bool MovementRight { get; set; }

        /// <summary> True when we want to pan upwards (+Y direction), false otherwise. </summary>
        public static bool MovementUp { get; set; }

        /// <summary>
        /// The speed for which we pan over an image/graph area.
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

        /// <summary> True when we want to use smooth acceleration for movement. </summary>
        public static bool SmoothAccelerationEnabled { get; set; }

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
        /// TODO: Fix the hardcoded part?
        /// </summary>
        public static void InitDefaultValues()
        {
            Debug.Print("InitDefaultValues");
            // The working area is the desktop area of the display, excluding 
            // taskbars, docked windows, and docked tool bars.
            Rectangle ScreenWorkingArea = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea;
            // The bounds are for the entire screen (think fullscreen mode)
            Rectangle ScreenBounds = System.Windows.Forms.Screen.PrimaryScreen.Bounds;


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
        }



    }

}
