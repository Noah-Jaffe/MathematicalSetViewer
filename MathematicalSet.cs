using System;
using System.Drawing;


namespace MathematicalSetViewer
{
    abstract class MathematicalSet
    {
        /// <summary>
        /// The active Color Palette to use when rendering an image
        /// </summary>
        public Color[] ColorPalette { get; set; }

        /// <summary>
        /// Uses the Decimal form of the XY structure to hold the screen resolution
        /// </summary>
        public XY ScreenDimentions { get; set; }

        /// <summary>
        /// Calculates the given range scaled to the current screen dimentions
        /// TODO: might change to scale to a given range of pixles instead
        /// </summary>
        /// <param name="lowerLeft">the lower left coordinates of the needed range to be calculated</param>
        /// <param name="topRight">the top right coordinate of the needed range to be calculated</param>
        /// <returns>TODO: figure out what format I am returning (if any?)</returns>
        public abstract Object CalculateRange(XY lowerLeft, XY topRight);

    }
}

