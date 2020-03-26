using System;
using System.Diagnostics;
// TODO: REMOVE THE private static int xyzCTOR's and their print statements
namespace MathematicalSetViewer.SafeQuadTree
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Numerical">Numerical point type</typeparam>
    public unsafe class BBox<Numerical>
    {
        /// <summary>
        /// [0] & [2] = bottom left, 
        /// [1] & [3] = top right, 
        /// [0] = botom X,
        /// [1] = top X,
        /// [2] = botom Y,
        /// [3] = top Y
        /// </summary>
        private Numerical[] corners { get; set; }
        private Numerical LengthX { get { return (dynamic) corners[1] - corners[0]; } }
        private Numerical LengthY { get { return (dynamic)corners[3] - corners[2]; } }

        private static int emptyctor = 0;
        private static int itemctor = 0;
        private static int arrctor = 0;
        private static int cpyctor = 0;

        public BBox()
        {
            Debug.Print($"Empty Constructor use #: {++emptyctor}!");
            corners = new Numerical[4];
        }

        public BBox(Numerical X1, Numerical X2, Numerical Y1, Numerical Y2)
        {
            Debug.Print($"Itemized Constructor use #: {++itemctor}!");
            corners = new Numerical[] { X1, X2, Y1, Y2 };
        }

        public BBox(Numerical[] arr)
        {
            Debug.Print($"Array Constructor use #: {++arrctor}!");
            if (arr.Length != 4)
            {
                throw new NotSupportedException("Only arrays of length 4. Where the first two items should be X, and last two items be the Y's");
            }
            corners = arr;
        }

        public BBox(BBox<Numerical> other)
        {
            Debug.Print($"Copy Constructor use #: {++cpyctor}!");
            // Deep copy
            this.corners = other.corners;
        }

        public bool inBounds(SQTPoint<Numerical> pt)
        {
        return (dynamic) pt.X >= corners[0] &&
               (dynamic) pt.X <= corners[1] &&
               (dynamic) pt.Y >= corners[2] &&
               (dynamic) pt.Y <= corners[3];
        }

        public bool overlaps(ref BBox<Numerical> other)
        {
            
            bool x_overlap = (dynamic) corners[0] <= other.corners[0] ?
              (dynamic) corners[1] > other.corners[0] :
              (dynamic) other.corners[1] > corners[0];
            bool y_overlap = (dynamic) corners[2] <= other.corners[2] ?
                      (dynamic) corners[3] > other.corners[2] :
                      (dynamic) other.corners[3]> corners[2];
            return x_overlap && y_overlap;
            
        }
    }
}