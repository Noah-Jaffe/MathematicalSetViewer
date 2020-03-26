using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace MathematicalSetViewer
{
    class MandelbrotGenerator : MathematicalSet
    {
        protected override string _Name => "Mandlebrot set";


        // starting scale for x: ( -2.5 , 1 )
        // starting scale for y: (  -1  , 1 )
        protected override XY DefaultBotLeft
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

        protected override XY DefaultTopRight
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

        public override object CalculateRange()
        {

            XY XYRatio = GetXYRatio();
            XY XYMidpoints = GetCenterXYPoint();
            int PxMax = MSVData.PictureSize.Xi;
            int PyMax = MSVData.PictureSize.Yi;

            // The midpoint + (# of ratios on this side relative to 0)
            Debug.WriteLine($"RATIOS: x {XYRatio.X}, y {XYRatio.Y}\n" +
                $"MIDPOINTS: x {XYMidpoints.X}, y {XYMidpoints.Y}\n");


            // TODO: FIND A BETTER NUMBER FOR maxIteration - maybe something like how its scaled to pixle ratio?
            int maxIteration = 50;

            // The number to multiply the iteration by to get the correct color.
            double colorPickerOffset = ColorPalette.Length / (double)(maxIteration);

            // the bitmap image to be displayed
            Bitmap bitmap = new Bitmap(MSVData.PictureSize.Xi, MSVData.PictureSize.Yi, PixelFormat.Format24bppRgb);

            Debug.Print("Generating image of size [ x:{0} y:{1} ]\n" +
                "Mapping: x < {2}, {3} >, y < {4}, {5} >\n" +
                "Center: [ x:{4} y:{5} ] ",
                bitmap.Width, bitmap.Height,
                XYMidpoints.X - ((Convert.ToDecimal(PxMax) - (MSVData.PictureSize.Xi / 2M)) * XYRatio.X),
                XYMidpoints.X - ((Convert.ToDecimal(0) - (MSVData.PictureSize.Xi / 2M)) * XYRatio.X),
                XYMidpoints.Y - ((Convert.ToDecimal(0) - (MSVData.PictureSize.Yi / 2M)) * XYRatio.Y),
                XYMidpoints.Y - ((Convert.ToDecimal(PyMax) - (MSVData.PictureSize.Yi / 2M)) * XYRatio.Y),
                XYMidpoints.X, XYMidpoints.Y);

            for (int Px = PxMax - 1; Px >= 0; --Px)
            {
                //Debug.WriteLine(Px / (double)PxMax * 100);
                // x0 = scaled x coordinate of pixel(scaled to lie in the Mandelbrot X scale(-2.5, 1))
                Decimal x0 = XYMidpoints.X - ((Convert.ToDecimal(Px) - (MSVData.PictureSize.Xi / 2M)) * XYRatio.X);
                for (int Py = PyMax - 1; Py >= 0; --Py)
                {
                    // y0 = scaled y coordinate of pixel(scaled to lie in the Mandelbrot Y scale (-1, 1))
                    Decimal y0 = XYMidpoints.Y - ((Convert.ToDecimal(Py) - (MSVData.PictureSize.Yi / 2M)) * XYRatio.Y);
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

        public override void Destroy()
        {
            // Nothing to do yet.
        }
    }



}
