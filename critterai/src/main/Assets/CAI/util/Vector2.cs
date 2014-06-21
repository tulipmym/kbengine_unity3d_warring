/*
 * Copyright (c) 2012 Stephen A. Pratt
 * 
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 * 
 * The above copyright notice and this permission notice shall be included in
 * all copies or substantial portions of the Software.
 * 
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
 * THE SOFTWARE.
 */
#if NUNITY

using System.Runtime.InteropServices;

namespace org.critterai
{
    /// <summary>
    /// Represents a 2D floating point vector.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Not present in the Unity build.
    /// </para>
    /// <para>
    /// This structure's API kept very simple in order to minimize conflicts with other vector 
    /// implementations.  The <see cref="Vector2Util"/> class provides some standard vector 
    /// operations.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector2
    {
        /// <summary>
        /// The x-value of vector (x, y).
        /// </summary>
        public float x;

        /// <summary>
        /// The y-value of vector (x, y).
        /// </summary>
        public float y;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="x">The x-value of vector (x, y).</param>
        /// <param name="y">The y-value of vector (x, y).</param>
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        /// <summary>
        /// The vector equality operator.
        /// </summary>
        /// <param name="v">A vector.</param>
        /// <param name="u">A vector.</param>
        /// <returns>True if each element of the vectors are equal.</returns>
        public static bool operator ==(Vector2 v, Vector2 u)
        {
            return (v.x == u.x && v.y == u.y);
        }

        /// <summary>
        /// The vector inequality operator.
        /// </summary>
        /// <param name="v">A vector.</param>
        /// <param name="u">A vector.</param>
        /// <returns>True if any equivalent element of the vectors is not equal.</returns>
        public static bool operator !=(Vector2 v, Vector2 u)
        {
            return !(v.x == u.x && v.y == u.y);
        }

        /// <summary>
        /// Vector subtraction operator. (v - u)
        /// </summary>
        /// <param name="v">The l-value vector.</param>
        /// <param name="u">The r-value vector.</param>
        /// <returns>A vector represnting (v - u).</returns>
        public static Vector2 operator -(Vector2 v, Vector2 u)
        {
            return new Vector2(v.x - u.x, v.y - u.y);
        }

        /// <summary>
        /// Vector addition operator. (v + u)
        /// </summary>
        /// <param name="v">A vector.</param>
        /// <param name="u">A vector.</param>
        /// <returns>A vector represnting (v + u).</returns>
        public static Vector2 operator +(Vector2 v, Vector2 u)
        {
            return new Vector2(v.x + u.x, v.y + u.y);
        }

        /// <summary>
        /// The vector hash code.
        /// </summary>
        /// <returns>The vector hash code.</returns>
        public override int GetHashCode()
        {
            int result = 17;
            result = 31 * result + x.GetHashCode();
            result = 31 * result + y.GetHashCode();
            return result;
        }

        /// <summary>
        /// Tests the vector for equality.
        /// </summary>
        /// <param name="obj">The vector to compare.</param>
        /// <returns>True if each element of the vector is equal to this vector.</returns>
        public override bool Equals(object obj)
        {
            if (obj is Vector2)
            {
                Vector2 u = (Vector2)obj;
                return (x == u.x && y == u.y);
            }
            return false;
        }
    }
}

#endif