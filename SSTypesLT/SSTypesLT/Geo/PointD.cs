/**********************************************************************************

Simple Smart Types Lite
https://github.com/dgakh/SSTypes
-----------------------

The MIT License (MIT)

Copyright (c) 2016 Dmitriy Gakh ( dmgakh@gmail.com ).

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.

**********************************************************************************/

namespace SSTypes
{

    /// <summary>
    /// Point with double coordinates optimized for rapid operations.
    /// Can be considered as a expanded supplement for System.Drawing.PointF but differ from it.
    /// </summary>
    [System.Serializable]
    [System.Runtime.InteropServices.ComVisible(true)]
    public struct PointD : System.IEquatable<PointD>
    {
        /// <summary>
        /// X coordinate of the Point.
        /// </summary>
        public System.Double X;

        /// <summary>
        /// Y coordinate of the Point.
        /// </summary>
        public System.Double Y;

        /// <summary>
        /// Bad value represented absent data, wrong data, e.t.c.
        /// </summary>
        public static PointD BadValue = new PointD(SmartDouble.BadValue, SmartDouble.BadValue);

        /// <summary>
        /// Constructs point by X,Y coordinates.
        /// </summary>
        public PointD(double X, double Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Constructs point by X,Y coordinates.
        /// </summary>
        public PointD(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Constructs point by X,Y coordinates.
        /// </summary>
        public PointD(SmartDouble X, SmartDouble Y)
        {
            this.X = X;
            this.Y = Y;
        }

        /// <summary>
        /// Returns true if value is bad.
        /// </summary>
        public bool isBad()
        {
            return (((SmartDouble)X).isBad()) || (((SmartDouble)Y).isBad());
        }

        /// <summary>
        /// Returns true if point is 0,0.
        /// </summary>
        [System.ComponentModel.Browsable(false)]
        public bool IsEmpty
        {
            get
            {
                return (X == 0) && (Y == 0);
            }
        }

        public static PointD operator +(PointD p1, PointD p2)
        {
            return new PointD(p1.X + p2.X, p1.Y + p2.Y);
        }

        public static PointD operator -(PointD p1, PointD p2)
        {
            return new PointD(p1.X - p2.X, p1.Y - p2.Y);
        }

        public static PointD operator *(PointD p1, PointD p2)
        {
            return new PointD(p1.X * p2.X, p1.Y * p2.Y);
        }

        public static PointD operator /(PointD p1, PointD p2)
        {
            return new PointD(p1.X / p2.X, p1.Y / p2.Y);
        }



        public static PointD operator +(PointD p, int i)
        {
            return new PointD(p.X + i, p.Y + i);
        }

        public static PointD operator -(PointD p, int i)
        {
            return new PointD(p.X - i, p.Y - i);
        }

        public static PointD operator *(PointD p, int i)
        {
            return new PointD(p.X * i, p.Y * i);
        }

        public static PointD operator /(PointD p, int i)
        {
            return new PointD(p.X / i, p.Y / i);
        }

        public static PointD operator +(PointD p, double d)
        {
            return new PointD(p.X + d, p.Y + d);
        }

        public static PointD operator -(PointD p, double d)
        {
            return new PointD(p.X - d, p.Y - d);
        }

        public static PointD operator *(PointD p, double d)
        {
            return new PointD(p.X * d, p.Y * d);
        }

        public static PointD operator /(PointD p, double d)
        {
            return new PointD(p.X / d, p.Y / d);
        }

        /// <summary>
        /// Returns distance to p.
        /// </summary>
        public SmartDouble DistancePythagorean(PointD p)
        {
            return PointDGeometry.DistancePythagorean(this, p);
        }

        /// <summary>
        /// Returns distance to point x,y
        /// </summary>
        public SmartDouble DistancePythagorean(double x, double y)
        {
            return PointDGeometry.DistancePythagorean(X, Y, x, y);
        }

        /// <summary>
        /// Returns distance to point x,y
        /// </summary>
        public SmartDouble DistancePythagorean(SmartDouble x, SmartDouble y)
        {
            return PointDGeometry.DistancePythagorean(X, Y, x, y);
        }

        /// <summary>
        /// Returns square of distance to p.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceSq(PointD p)
        {
            return PointDGeometry.DistanceSq(this, p);
        }

        /// <summary>
        /// Returns square of distance to point x,y.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceSq(double x, double y)
        {
            return PointDGeometry.DistanceSq(X, Y, x, y);
        }

        /// <summary>
        /// Returns square of distance to point x,y.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceSq(int x, int y)
        {
            return PointDGeometry.DistanceSq(X, Y, x, y);
        }

        /// <summary>
        /// Returns square of distance to point x,y.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceSq(SmartDouble x, SmartDouble y)
        {
            return PointDGeometry.DistanceSq(X, Y, x, y);
        }

        /// <summary>
        /// Returns Manhattan distance to p.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceManhattan(PointD p)
        {
            return PointDGeometry.DistanceManhattan(this, p);
        }

        /// <summary>
        /// Returns Manhattan distance to point x,y.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceManhattan(double x, double y)
        {
            return PointDGeometry.DistanceManhattan(X, Y, x, y);
        }

        /// <summary>
        /// Returns Manhattan distance to point x,y.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public SmartDouble DistanceManhattan(SmartDouble x, SmartDouble y)
        {
            return PointDGeometry.DistanceManhattan(X, Y, x, y);
        }

        public override string ToString()
        {
            return "(" + X.ToString() + "," + Y.ToString() + ")";
        }

        public bool Equals(PointD other)
        {
            return this == other;
        }

        public static bool operator !=(PointD a, PointD b)
        {
            return (a.X != b.X) || (a.Y != b.Y);
        }

        public static bool operator ==(PointD a, PointD b)
        {
            return (a.X == b.X) && (a.Y == b.Y);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is PointD)) return false;
            PointD p = (PointD)obj;
            return
            (p.X == this.X) &&
            (p.Y == this.Y) &&
            (p.GetType().Equals(this.GetType()));
        }

        public override int GetHashCode()
        {
            return SSTypes.Helper.CombineHashCodes(X.GetHashCode(), Y.GetHashCode());
        }
    }

    /// <summary>
    /// Provides different geometrical methods.
    /// Can be differ from geographical calculations.
    /// </summary>
    public static class PointDGeometry
    {
        // public static double DefaultCalculationEpsilon = 1e-;

        /// <summary>
        /// Calculates distance using simple distance formula based on Pythagorean theorem.
        /// </summary>
        /// <param name="p1">First Point.</param>
        /// <param name="p2">Second Point.</param>
        public static double DistancePythagorean(PointD p1, PointD p2)
        {
            p1 -= p2;
            p1 *= p1;
            return System.Math.Sqrt(p1.X + p1.Y);
        }

        /// <summary>
        /// Returns distance between points x1,y1 and x2,y2.
        /// </summary>
        public static double DistancePythagorean(double x1, double y1, double x2, double y2)
        {
            double a1 = x1 - x2;
            double a2 = y1 - y2;
            return System.Math.Sqrt(a1 * a1 + a2 * a2);
        }

        /// <summary>
        /// Returns square of distance between p1 and p2.
        /// Is quicker than Distance. Use to compare distancies for example.
        /// </summary>
        public static double DistanceSq(PointD p1, PointD p2)
        {
            double a1 = p1.X - p2.X;
            double a2 = p1.Y - p2.Y;
            return a1 * a1 + a2 * a2;
        }

        /// <summary>
        /// Returns square of distance  between points x1,y1 and x2,y2.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public static double DistanceSq(double x1, double y1, double x2, double y2)
        {
            double a1 = x1 - x2;
            double a2 = y1 - y2;
            return a1 * a1 + a2 * a2;
        }

        /// <summary>
        /// Returns Manhattan distance between p1 and p2.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public static double DistanceManhattan(PointD p1, PointD p2)
        {
            return System.Math.Abs(p1.X - p2.X) + System.Math.Abs(p1.Y - p2.Y);
        }

        /// <summary>
        /// Returns Manhattan distance  between points x1,y1 and x2,y2.
        /// Is quicker than DistanceTo. Use to compare distancies for example.
        /// </summary>
        public static double DistanceManhattan(double x1, double y1, double x2, double y2)
        {
            return System.Math.Abs(x1 - x2) + System.Math.Abs(y1 - y2);
        }

    }

}
