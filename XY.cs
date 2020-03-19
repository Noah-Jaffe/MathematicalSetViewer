using System;
using System.Runtime.InteropServices;

namespace MathematicalSetViewer
{

    /// <summary>
    /// A struct to hold 2 numbers
    /// TYPE    >Bytes=> Variable Names 
    /// bytes   >   1 => b1, b2
    /// short   >   2 => s1, s2
    /// int     >   4 => i1, i2
    /// double  >   8 => d1, d2
    /// long    >   8 => l1, l2
    /// Decimal >  16 => D1, D2
    /// </summary>
    [StructLayout(LayoutKind.Explicit)]
    public struct XY
    {
        [FieldOffset(0)]
        public byte Xb;
        [FieldOffset(sizeof(Decimal))]
        public byte Yb;
        [FieldOffset(0)]
        public short Xs;
        [FieldOffset(sizeof(Decimal))]
        public short Ys;
        [FieldOffset(0)]
        public int Xi;
        [FieldOffset(sizeof(Decimal))]
        public int Yi;
        [FieldOffset(0)]
        public double Xd;
        [FieldOffset(sizeof(Decimal))]
        public double Yd;
        [FieldOffset(0)]
        public long Xl;
        [FieldOffset(sizeof(Decimal))]
        public long Yl;
        [FieldOffset(0)]
        public Decimal X;
        [FieldOffset(sizeof(Decimal))]
        public Decimal Y;
    }
}
