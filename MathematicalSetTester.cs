using System;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;

namespace MathematicalSetViewer
{
    class MathematicalSetTester : MathematicalSet
    {
        protected override string _Name => "Testing Set";

        // starting scale for x: ( -2.5 , 1 )
        // starting scale for y: (  -1  , 1 )
        protected override XY DefaultBotLeft
        {
            get
            {
                return new XY
                {
                    X = 0M,
                    Y = 0M
                };
            }
        }

        protected override XY DefaultTopRight
        {
            get
            {
                return new XY
                {
                    X = 1530M, // the length of MSVData.ColorPalette when using full color spectrum color list
                    Y = 100M
                };
            }
        }

        // TODO: remove debug line
        private static int initCount = 0;

        public MathematicalSetTester()
        {
            ActiveBotLeft = DefaultBotLeft;
            ActiveTopRight = DefaultTopRight;
            Debug.WriteLine($"MathematicalSetTester initCount: {++initCount}");
        }

        public override object CalculateRange()
        {
            XY XYRatio = GetXYRatio();
            XY XYMidpoints = GetCenterXYPoint();
            int PxMax = MSVData.PictureSize.Xi;
            int PyMax = MSVData.PictureSize.Yi;

            // the bitmap image to be displayed
            Bitmap bitmap = new Bitmap(MSVData.PictureSize.Xi, MSVData.PictureSize.Yi, PixelFormat.Format24bppRgb);

            Debug.Print("Generating image of size [ x:{0} y:{1} ]\n" +
                "Mapping: x < {2}, {3} >, y < {4}, {5} >\n" +
                "Center: [ x:{6} y:{7} ]\n" +
                "Ratios: x < {8} >, y < {9} >",
                bitmap.Width, bitmap.Height,
                ActiveBotLeft.X, ActiveTopRight.X,
                ActiveBotLeft.Y, ActiveTopRight.Y,
                XYMidpoints.X, XYMidpoints.Y,
                XYRatio.X, XYRatio.Y);

            // this tester will be generating an image of a color spectrum that ends with black. 
            int colors = MSVData.ColorPalette.Length;
            Color colorValue = Color.Black;
            // scale the number of colors to our screen 
            for (int Px = 0; Px < PxMax; ++Px)
            {
                // x0 = scaled x coordinate of pixel(scaled to lie in the default scale)
                Decimal x0 = ((Px * XYRatio.X) + ActiveBotLeft.X);
                for (int Py = 0; Py < PyMax; ++Py)
                {
                    if (x0 < MSVData.ColorPalette.Length && x0 >= 0)
                    {
                        //colorValue = x0 < MSVData.ColorPalette.Length && x0 >= 0 ? MSVData.ColorPalette[(int)x0] : Color.Black;
                        colorValue = Convert.ToInt32(x0.ToString()[x0.ToString().Length - 1]) % 2 == 0 ? Color.White : Color.Black;
                        bitmap.SetPixel(Px, Py, colorValue);
                    }
                }
            }
            Debug.WriteLine("Completed image");
            return bitmap;
            //return new ImageLocation(ActiveBotLeft, ActiveTopRight, bitmap);
        }

        public override void Destroy()
        {
            // nothing to do yet
        }
    }



}
