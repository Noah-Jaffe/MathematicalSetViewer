using System;
using System.Drawing;


namespace MathematicalSetViewer
{
    public abstract class MathematicalSet
    {
        public abstract XY DefaultBotLeft { get; }
        public abstract XY DefaultTopRight { get; }
        /// <summary>
        /// The active Color Palette to use when rendering an image
        /// </summary>
        public Color[] ColorPalette { 
            get
            {
                return MSVData.ColorPalette;
            } 
            set
            {
                throw new InvalidOperationException("The mathematical render may not change the color palette");
            }
        }

        /// <summary>
        /// Uses the Decimal form of the XY structure to hold the screen resolution
        /// </summary>
        public XY ScreenDimentions { get; set; }

        /// <summary>
        /// If this is true, no threads should be running. 
        /// All threads should be paused to enable the hardware to be used by something else.
        /// </summary>
        private bool PAUSE_ALL_CALCULATIONS;

        
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

