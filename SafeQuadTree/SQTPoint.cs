namespace MathematicalSetViewer.SafeQuadTree
{
    /// <summary>
    /// A point for the SQT
    /// </summary>
    /// <typeparam name="N">The numerical data type</typeparam>
    public class SQTPoint<N> : System.IEquatable<SQTPoint<N>>
    {
        public N X { get; set; }
        public N Y { get; set; }

        
        public bool Equals(SQTPoint<N> other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }

    }
}