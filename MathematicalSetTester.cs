using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace MathematicalSetViewer
{
    class MathematicalSetTester : MathematicalSet
    {
        private static int initCount = 0;
        public MathematicalSetTester ()
        {
            Debug.WriteLine($"MathematicalSetTester initCount: {++initCount}");
        }
        // starting scale for x: ( -2.5 , 1 )
        // starting scale for y: (  -1  , 1 )
        public override XY DefaultBotLeft
        {
            get
            {
                return new XY
                {
                    X = -100M,
                    Y = -100M
                };
            }
        }

        public override XY DefaultTopRight
        {
            get
            {
                return new XY
                {
                    X = 1430, // the length of MSVData.ColorPalette when using full color spectrum color list
                    Y = 980
                };
            }
        }

        
        public override object CalculateRange(XY botLeft, XY topRight)
        {
            XY XYRatio = new XY
            {
                X = Math.Abs(botLeft.X - topRight.X) / MSVData.PictureSize.Xi,
                Y = Math.Abs(botLeft.Y - topRight.Y) / MSVData.PictureSize.Yi
            };
            XY XYMidpoints = new XY
            {
                // TODO: Possible speedup? bitshift after the addition
                X = (topRight.X + botLeft.X) / 2M, //((topRight.X - botLeft.X) / 2M) + botLeft.X,
                Y = (topRight.Y + botLeft.Y) / 2M //((topRight.Y - botLeft.Y) / 2M) + botLeft.Y 
            };
            int PxMax = MSVData.PictureSize.Xi;
            int PyMax = MSVData.PictureSize.Yi;

            // the bitmap image to be displayed
            Bitmap bitmap = new Bitmap(MSVData.PictureSize.Xi, MSVData.PictureSize.Yi, PixelFormat.Format24bppRgb);

            /*
            Debug.Print("Generating image of size [ x:{0} y:{1} ]\n" +
                "Mapping: x < {2}, {3} >, y < {4}, {5} >\n" +
                "Center: [ x:{6} y:{7} ]\n" +
                "Ratios: x < {8} >, y < {9} >",
                bitmap.Width, bitmap.Height,
                XYMidpoints.X - ((Convert.ToDecimal(PxMax) - (MSVData.PictureSize.Xi / 2M)) * XYRatio.X),
                XYMidpoints.X - ((Convert.ToDecimal(0) - (MSVData.PictureSize.Xi / 2M)) * XYRatio.X),
                XYMidpoints.Y - ((Convert.ToDecimal(PyMax) - (MSVData.PictureSize.Yi / 2M)) * XYRatio.Y),
                XYMidpoints.Y - ((Convert.ToDecimal(0) - (MSVData.PictureSize.Yi / 2M)) * XYRatio.Y),
                XYMidpoints.X, XYMidpoints.Y, XYRatio.X, XYRatio.Y);
            */
            Debug.Print("Generating image of size [ x:{0} y:{1} ]\n" +
                "Mapping: x < {2}, {3} >, y < {4}, {5} >\n" +
                "Center: [ x:{6} y:{7} ]\n" +
                "Ratios: x < {8} >, y < {9} >",
                bitmap.Width, bitmap.Height,
                botLeft.X, topRight.X,
                botLeft.Y, topRight.Y,
                XYMidpoints.X, XYMidpoints.Y,
                XYRatio.X, XYRatio.Y);

            // this tester will be generating an image of a color spectrum that ends with black. 
            int colors = MSVData.ColorPalette.Length;
            Color colorValue = Color.Black;
            // scale the number of colors to our screen 
            for (int Px = 0; Px < PxMax; ++Px)
            {
                // x0 = scaled x coordinate of pixel(scaled to lie in the default scale)
                int x0 = (int)(Px * XYRatio.X);
                for (int Py = 0; Py < PyMax; ++Py)
                {
                    bitmap.SetPixel(Px, Py, MSVData.ColorPalette[x0]);
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
                X = Math.Abs(xLower - xUpper) / MSVData.PictureSize.X,
                Y = Math.Abs(yLower - yUpper) / MSVData.PictureSize.Y
            };
        }
    }



}
