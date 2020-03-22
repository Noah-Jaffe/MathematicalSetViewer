using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using Microsoft.CSharp;
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
        public static XY DrawResolution { get; set; }

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

        /// <summary> Used to determine if the menu bar is displayed or not. </summary>
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

        /// <summary> True when we want to use smooth acceleration for movement. </summary>
        public static bool SmoothAccelerationEnabled { get; set; }

        internal static void clearSmoothAccelerationData(string v)
        {
            switch(v)
            {
                case "ZoomSpeed":
                    _ZoomSpeed = _ZoomDeltas.PopAll();
                    break;
            }
        }

        /// <summary> A Decimal value to determine the zoom speed. </summary>
        /// <summary>
        /// When ZoomSpeed > 0 := Zooming in
        /// When ZoomSpeed = 0 := No Zoom
        /// When ZoomSpeed < 0 := Zoom out
        /// </summary>
        /// <remarks>
        /// This property is effected by <c>SmoothAccelerationEnabled</c>
        /// </remarks>
        public static Decimal _ZoomSpeed { get; set; }
        private static LinkedList _ZoomDeltas = new LinkedList(new[] { 0M });
        public static Decimal ZoomSpeed
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
        public static Object[,] InitStartingData() 
        {
            Dictionary<string, object> DefaultVals = new Dictionary<string, object>()
            {
                { "ZoomSpeed", 0 },
                { "SmoothAccelerationEnabled", false },
                { "MenuVisible", true },
                { "RenderEnabled", false },
                { "CalculationsEnabled", false },
                { "ColorPalette", null }, // TODO: change from null? 



            };
            Type clas = typeof(MSVData);
            var x = clas.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            Object[,] DataInfo = new Object[x.Length, 3];
            for (int i = 0; i < x.Length; ++i)
            {
                DataInfo[i, 0] = x[i].Name;
                DataInfo[i, 1] = x[i].PropertyType;
                //DataInfo[i, 2] = x[i].GetValue;
            }
            return DataInfo;
            /*Boolean CalculationsEnabled
    MathematicalSetViewer.XY DrawResolution
    Boolean RenderEnabled
    Boolean MenuVisible
    Boolean MovementDown
    Boolean MovementLeft
    Boolean MovementRight
    Boolean MovementUp
    Boolean SmoothAccelerationEnabled
    System.Decimal _ZoomSpeed
    System.Decimal ZoomSpeed*/
        }



    }

}
