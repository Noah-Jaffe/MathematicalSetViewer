using System;
using System.Diagnostics;
// TODO: REMOVE THE private static int xyzCTOR's and their print statements
namespace MathematicalSetViewer.SafeQuadTree
{
    public unsafe class BBoxPt<N>
    {
        private XY* BotLeft;
        private N Length { get; set; }

//        [System.Diagnostics.CodeAnalysis.SuppressMessage("CodeQuality", "IDE0051:Remove unused private members", Justification = "Its to be used in other files 4head")]
        private N LengthX { get { return Length; } set { Length = value; } }
        private N LengthY { get; set; }

        private static int emptyctor = 0;
        private static int itemctor = 0;
        private static int cpyctor = 0;

        public BBoxPt()
        {
            Debug.Print($"Empty Constructor use #: {++emptyctor}!");
            BotLeft = null;
        }


        public BBoxPt(XY* xy, N Length1, N Length2 = default)
        {
            Debug.Print($"Itemized Constructor use #: {++itemctor}!");
            BotLeft = xy;
            Length = Length1;
            LengthY = Length2.Equals(default(N)) ? Length1 : Length2;
        }

        
        public BBoxPt(ref BBoxPt<N> other)
        {
            Debug.Print($"Copy Constructor use #: {++cpyctor}!");
            // Deep copy
            this.BotLeft = other.BotLeft;
            this.Length = other.Length;
            this.LengthY = other.LengthY;
        }


    }
}