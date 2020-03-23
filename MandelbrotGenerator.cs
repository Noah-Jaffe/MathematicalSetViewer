using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace MathematicalSetViewer
{
    class MandelbrotGenerator : MathematicalSet
    {

        // starting scale for x: ( -2.5 , 1 )
        // starting scale for y: (  -1  , 1 )
        public override XY DefaultBotLeft
        {
            get
            {
                return new XY
                {
                    X = -2.5M,
                    Y = -1M
                };
            }
        }

       
        public override XY DefaultTopRight
        {
            get
            {
                return new XY
                {
                    X = 1M,
                    Y = 1M
                };
            }
        }


        public override object CalculateRange(XY botLeft, XY topRight)
        {
           
            XY XYRatio = GetXYRatio(botLeft.X, topRight.X, botLeft.Y, topRight.Y);
            XY XYMidpoints = GetXYMidpoints(botLeft.X, topRight.X, botLeft.Y, topRight.Y);

            // The midpoint + (# of ratios on this side relative to 0)
            Debug.WriteLine($"RATIOS: x {XYRatio.X}, y {XYRatio.Y}\n" +
                $"MIDPOINTS: x {XYMidpoints.X}, y {XYMidpoints.Y}\n");
            int PxMax = Convert.ToInt32(ScreenDimentions.X);
            int PyMax = Convert.ToInt32(ScreenDimentions.Y);


            // TODO: FIND A BETTER NUMBER FOR maxIteration - maybe something like how its scaled to pixle ratio?
            int maxIteration = 50;

            // The number to multiply the iteration by to get the correct color.
            double colorPickerOffset = ColorPalette.Length / (double)(maxIteration);

            // the bitmap image to be displayed
            Bitmap bitmap = new Bitmap((int)ScreenDimentions.X, (int)ScreenDimentions.Y, PixelFormat.Format24bppRgb);

            Debug.Print("Generating image of size [ x:{0} y:{1} ]\n" +
                "Mapping: x < {2}, {3} >, y < {4}, {5} >\n" +
                "Center: [ x:{4} y:{5} ] ",
                bitmap.Width, bitmap.Height,
                XYMidpoints.X - ((Convert.ToDecimal(PxMax) - (ScreenDimentions.X / 2M)) * XYRatio.X),
                XYMidpoints.X - ((Convert.ToDecimal(0) - (ScreenDimentions.X / 2M)) * XYRatio.X),
                XYMidpoints.Y - ((Convert.ToDecimal(0) - (ScreenDimentions.Y / 2M)) * XYRatio.Y),
                XYMidpoints.Y - ((Convert.ToDecimal(PyMax) - (ScreenDimentions.Y / 2M)) * XYRatio.Y),
                XYMidpoints.X, XYMidpoints.Y);

            for (int Px = PxMax - 1; Px >= 0; --Px)
            {
                //Debug.WriteLine(Px / (double)PxMax * 100);
                // x0 = scaled x coordinate of pixel(scaled to lie in the Mandelbrot X scale(-2.5, 1))
                Decimal x0 = XYMidpoints.X - ((Convert.ToDecimal(Px) - (ScreenDimentions.X / 2M)) * XYRatio.X);
                for (int Py = PyMax - 1; Py >= 0; --Py)
                {
                    // y0 = scaled y coordinate of pixel(scaled to lie in the Mandelbrot Y scale (-1, 1))
                    Decimal y0 = XYMidpoints.Y - ((Convert.ToDecimal(Py) - (ScreenDimentions.Y / 2M)) * XYRatio.Y);
                    // Debug.WriteLine($"{x0},{y0}");
                    Decimal X = 0.0M;
                    Decimal Y = 0.0M;
                    int iteration = 0;


                    while (X * X + Y * Y <= 4 && iteration < maxIteration)
                    {
                        Decimal Xtemp = X * X - Y * Y + x0;
                        Y = 2 * X * Y + y0;
                        X = Xtemp;
                        ++iteration;
                    }

                    // color_value is the range of the rainbow scaled to maxIterations
                    /*
                     * Colors as hex value: 0xFF FF FF FF
                     *                         α  R  G  B
                     */
                    // TODO find a way to make a smooth color transitions in O(1)
                    Color colorValue = ColorPalette[(int)(iteration * colorPickerOffset) - 1];
                    //Debug.WriteLine("x: {0,3} y: {1,3} i: {2,3} c: {3}", Px, Py, iteration, colorValue.ToString());

                    bitmap.SetPixel(Px, Py, colorValue);//plot(Px, Py, color)
                }
            }
            Debug.WriteLine("Completed image");
            return bitmap;
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
        private XY GetXYMidpoints(Decimal xLower, Decimal xUpper, Decimal yLower, Decimal yUpper)
        {
            return new XY
            {
                X = ((xUpper - xLower) / 2M) + xLower,
                Y = ((yUpper - yLower) / 2M) + yLower //(yLower - yUpper) / 2M
            };
        }

        /// <summary>
        /// Returns the XY ratio(aka. step amount).
        /// </summary>
        /// <remarks>
        /// Uses ScreenDim for calculations.
        /// </remarks>
        /// <param name="xLower">The lower X bound of the graph.</param>
        /// <param name="xUpper">The upper X bound of the graph.</param>
        /// <param name="yLower">The lower Y bound of the graph.</param>
        /// <param name="yUpper">The upper Y bound of the graph.</param>
        /// <returns><c>XY</c>with the Decimal parts filled with the ratio values</returns>
        private XY GetXYRatio(Decimal xLower, Decimal xUpper, Decimal yLower, Decimal yUpper)
        {
            // TODO: see if making all these `new` calls is detrimental
            return new XY
            {
                X = Math.Abs(xLower - xUpper) / ScreenDimentions.X,
                Y = Math.Abs(yLower - yUpper) / ScreenDimentions.Y
            };
        }
    }


    
}
