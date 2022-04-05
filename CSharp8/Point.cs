using System;

namespace CSharp8
{
    // Readonly members
    public struct Point
    {
        public Point(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; set; }

        public double Y { get; set; }

        public readonly double Distance => Math.Sqrt(X * X + Y * Y);

        public readonly override string ToString() => Distance.ToString();
    }
}