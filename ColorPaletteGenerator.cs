using System;
using System.Diagnostics;
using System.Drawing;

namespace MathematicalSetViewer
{
    public static class ColorPaletteGenerator
    {
   
        /// <summary>
        /// Generates a list of RGB values in rainbow order ending in black.
        /// </summary>
        /// <param name="maxR">The maximum red component. Valid values are 0 through 255. Must be greater or equal to minR.</param>
        /// <param name="maxG">The maximum green component. Valid values are 0 through 255. Must be greater or equal to minG.</param>
        /// <param name="maxB">The maximum blue component. Valid values are 0 through 255. Must be greater or equal to minB.</param>
        /// <param name="minR">The minimum red component. Valid values are 0 through 255. Must be less than or equal to maxR.</param>
        /// <param name="minG">The minimum green component. Valid values are 0 through 255. Must be less than or equal to maxG.</param>
        /// <param name="minB">The minimum blue component. Valid values are 0 through 255. Must be less than or equal to maxB.</param>
        /// <returns>An array of <c>Color</c>'s in rainbow order.</returns>
        public static Color[] GenerateIterationColors(Int32 maxR = 255, Int32 maxG = 255, Int32 maxB = 255, Int32 minR = 0, Int32 minG = 0, Int32 minB = 0)
        {
            Debug.Print($"Generating colors R <{minR},{maxR}> G<{minG},{maxG}> B<{minB},{maxB}>");
            DateTime startTime = DateTime.Now;
            startTime = DateTime.Now;
            // [rainbow_id,rgb_index]
            Color[] colors = new Color[(maxR + maxG + maxB - minR - minG - minB) * 2];
            int index = 0;
            // r,0,b^
            for (int i = minB; i < maxB; ++i, ++index)
            {
                colors[index] = Color.FromArgb(maxR, minG, i);
            }

            // r_,0,b
            for (int i = maxR; i > minR; --i, ++index)
            {
                colors[index] = Color.FromArgb(i, minG, maxB);
            }

            // 0,g^,b
            for (int i = minG; i < maxG; ++i, ++index)
            {
                colors[index] = Color.FromArgb(minR, i, maxB);
            }

            // 0,g,b_
            for (int i = maxB; i > minB; --i, ++index)
            {
                colors[index] = Color.FromArgb(minR, maxG, i);
            }

            // r^,g,0
            for (int i = minR; i < maxR; ++i, ++index)
            {
                colors[index] = Color.FromArgb(i, maxG, minB);
            }

            // r,g/2 _,0
            int x = maxG;
            while (x > (double)(1 + maxG - minG) / 2.0)
            {
                colors[index] = Color.FromArgb(maxR, x, minB);
                --x;
                ++index;
            }

            // down to black
            int expectedLen = colors.Length;
            int remainingVals = expectedLen - minB - index;
            if (remainingVals == 0)
            {
                return colors;
            }
            double rateR = Math.Abs((double)maxR / (double)remainingVals);
            double rateG = Math.Abs((double)(maxG - minG) / (double)(2.0 * remainingVals));

            for (int i = 1; i <= remainingVals; ++i, ++index)
            {
                colors[index] = Color.FromArgb((int)(maxR - (i * rateR)), (int)(x - (i * rateG)), minB);
            }
            return colors;
        }

    }
}