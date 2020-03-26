using System;
using System.Diagnostics;
using System.Drawing;

namespace MathematicalSetViewer
{
    /// <summary>
    /// The base class for the Mathematical Sets or whatever is being calculated.
    /// </summary>
    public abstract class MathematicalSet
    {
        protected abstract string _Name { get; }
        public string Name
        {
            get
            {
                return _Name;
            }
        }
        /// <summary>
        /// The default plotting range for the first iteration of calculations
        /// </summary>
        protected abstract XY DefaultBotLeft { get; }
        protected abstract XY DefaultTopRight { get; }

        /// <summary>
        /// The active plotting range to be plotted.
        /// TODO: check for threadding access issues
        /// </summary>
        public XY ActiveBotLeft { get; set; }
        public XY ActiveTopRight { get; set; }

        /// <summary>
        /// The active Color Palette to use when rendering an image
        /// </summary>
        protected Color[] ColorPalette
        {
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
        /// If this is true, no threads should be running. 
        /// All threads should be paused to enable the hardware to be used by something else.
        /// </summary>

        /// <summary>
        /// Calculates the given range scaled to the current screen dimentions
        /// </summary>
        /// <returns>TODO: figure out what format I am returning (if any?)</returns>
        public abstract Object CalculateRange();

        /// <summary>
        /// Destroys anything that needs to be destroyed.
        /// </summary>
        public abstract void Destroy();
        /// <summary>
        /// Gets the center point of the area to render. 
        /// </summary>
        /// <returns>
        /// If user input is enabled, uses the mouse coordinates plot point.
        /// Otherwise, it will get the center of the current plotting range
        /// </returns>
        protected XY GetCenterXYPoint()
        {
            if (MSVData.InputEnabled)
            {
                return MSVData.MouseLocation;
            }
            else
            {
                return new XY
                {
                    X = ((DefaultTopRight.X - DefaultBotLeft.X) / 2M) + DefaultBotLeft.X,
                    Y = ((DefaultTopRight.Y - DefaultBotLeft.Y) / 2M) + DefaultBotLeft.Y
                };
            }
        }
        /// <summary>
        /// Returns the XY midpoints. 
        /// </summary>
        /// <remarks>
        /// Uses ScreenDim for calculations.
        /// </remarks>
        /// <param name="xLower">The lower X bound of the graph.</param>
        /// <param name="xUpper">The upper X bound of the graph.</param>
        /// <param name="yLower">The lower Y bound of the graph.</param>
        /// <param name="yUpper">The upper Y bound of the graph.</param>
        /// <returns><c>XY</c>with the Decimal parts filled with the midpoint values</returns>
        protected virtual XY GetXYMidpoints(Decimal xLower, Decimal xUpper, Decimal yLower, Decimal yUpper)
        {
            return new XY
            {
                // TODO: Possible speedup? bitshift instead of devide? the addition?
                X = ((xUpper - xLower) / 2M) + xLower,
                Y = ((yUpper - yLower) / 2M) + yLower //(yLower - yUpper) / 2M
            };
        }
        /// <summary>
        /// Returns the XY ratio(aka. step amount).
        /// </summary>
        /// <remarks>
        /// Uses input for calculations.
        /// </remarks>
        /// <param name="xLower">The lower X bound of the graph.</param>
        /// <param name="xUpper">The upper X bound of the graph.</param>
        /// <param name="yLower">The lower Y bound of the graph.</param>
        /// <param name="yUpper">The upper Y bound of the graph.</param>
        /// <returns><c>XY</c>with the Decimal parts filled with the ratio values</returns>
        protected XY GetXYRatio(Decimal xLower, Decimal xUpper, Decimal yLower, Decimal yUpper)
        {
            return new XY
            {
                X = Math.Abs(xLower - xUpper) / MSVData.PictureSize.X,
                Y = Math.Abs(yLower - yUpper) / MSVData.PictureSize.Y
            };
        }
        /// <summary>
        /// Returns the XY ratio(aka. step amount).
        /// </summary>
        /// <remarks>
        /// Uses the active range for calculations
        /// </remarks>
        /// <returns>
        /// <c>XY</c>with the Decimal parts filled with the ratio values
        /// </returns>
        protected virtual XY GetXYRatio()
        {
            return new XY
            {
                X = Math.Abs(ActiveBotLeft.X - ActiveTopRight.X) / MSVData.PictureSize.X,
                Y = Math.Abs(ActiveBotLeft.Y - ActiveTopRight.Y) / MSVData.PictureSize.Y
            };
        }

        public XY getZoomRatio()
        {
            return new XY
            {
                X = (ActiveTopRight.X - ActiveBotLeft.X) / (MSVData.ZoomSpeed > 0 ? 4M : 0.25M),
                Y = (ActiveTopRight.Y - ActiveBotLeft.Y) / (MSVData.ZoomSpeed > 0 ? 4M : 0.25M)
            };
        }
        public void UpdateActiveRange()
        {
            Debug.Print($"START:  < {ActiveBotLeft.X} , {ActiveBotLeft.Y} > < {ActiveTopRight.X} , {ActiveTopRight.Y} >");
            XY ZoomRatio = getZoomRatio();
            XY CenterPoint = GetCenterXYPoint();
            ActiveBotLeft = new XY
            {
                X = CenterPoint.X - ZoomRatio.X,
                Y = CenterPoint.Y - ZoomRatio.Y
            };
            ActiveTopRight = new XY
            {
                X = CenterPoint.X + ZoomRatio.X,
                Y = CenterPoint.Y + ZoomRatio.Y
            };
            Debug.Print($"FINISH: < {ActiveBotLeft.X} , {ActiveBotLeft.Y} > < {ActiveTopRight.X} , {ActiveTopRight.Y} >");

        }
    }
}

