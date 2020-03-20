using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        // TODO: see if byte array for movement is better?
        //public static byte ActiveMovement { get; set; }

        /// <summary>
        /// Used to store the integer resolution of the drawing area in pixles. 
        /// Uses XY.Xi, and XY.Yi
        /// </summary>
        public static XY DrawResolution { get; set; }

        /// <summary> Used to determine if the display is allowed to be changed. </summary>
        /// <value>
        /// True := unpaused, display is free to change.
        /// False := paused, display is locked.
        /// </value>
        public static bool RenderEnabled { get; set; }

        /// <summary> Used to determine if the menu bar is displayed or not. </summary>
        // TODO: see if i want to make these setters fire an event?
        public static bool MenuVisible { get; set; }

        /// <summary> True when we want to pan downwards (-Y direction), false otherwise. </summary>
        public static bool MovementDown { get; set; }

        /// <summary> True when we want to pan left (-X direction), false otherwise. </summary>
        public static bool MovementLeft { get; set; }

        /// <summary> True when we want to pan right (+X direction), false otherwise. </summary>
        public static bool MovementRight { get; set; }

        /// <summary> True when we want to pan upwards (+Y direction), false otherwise. </summary>
        public static bool MovementUp { get; set; }

        /// <summary> True when we want to use smooth acceleration for movement. </summary>
        public static bool SmoothAccelerationEnabled { get; set; }

        /// <summary> A Decimal value to determine the zoom speed. </summary>
        /// <summary>
        /// When ZoomSpeed > 0 := Zooming in
        /// When ZoomSpeed = 0 := No Zoom
        /// When ZoomSpeed < 0 := Zoom out
        /// </summary>
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



    }

}
