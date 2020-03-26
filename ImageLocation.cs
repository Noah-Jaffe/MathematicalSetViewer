using System.Drawing;

namespace MathematicalSetViewer
{
    public class ImageLocation
    {
        public Bitmap image { get; set; }
        public XY BotLeft { get; set; }
        public XY TopRight { get; set; }

        public ImageLocation(/*XY bl, XY tr, */Bitmap img)
        {
            //this.BotLeft = bl;
            //this.TopRight = tr;
            image = img;
        }

    }
}