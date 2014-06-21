/*
 * Copyright (c) 2011 Stephen A. Pratt
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
using System;
using org.critterai.nav.rcn;
using org.critterai.interop;

namespace org.critterai.nav
{
    /// <summary>
    /// Represents proximity data generated by a  <see cref="CrowdManager"/> object during 
    /// its update method.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Objects of this type can only be obtained from a <see cref="CrowdManager"/> object.
    /// </para>
    /// <code>
    /// // Example: Iterating the proximity data.
    /// 
    /// // Where 'grid' is a CrowdProximityGrid object.
    /// 
    /// int[] bounds = new int[4];
    /// grid.GetBounds(bounds);
	///	float cs = grid.GetCellSize();
    ///	
	///	for (int y = bounds[1]; y &lt;= bounds[3]; ++y)
	///	{
    ///	    // y-bounds of the cell in world units.
    ///	    float minY = y * cs;
    ///	    float maxY = y * cs + cs;
    ///		for (int x = bounds[0]; x &lt;= bounds[2]; ++x)
	///		{
	///			int count = grid->getItemCountAt(x, y); 
    ///			// x-bounds of the cell in world units.
    ///			float minX = x * cs;
    ///			float maxX = x * cs + cs;
	///		}
	///	}
    /// </code>
    /// <para>
    /// Behavior is undefined if used after disposal.
    /// </para>
    /// </remarks>
    public sealed class CrowdProximityGrid
    {
        private IntPtr root;
        private bool mIsDisposed = false;

        internal CrowdProximityGrid(IntPtr grid)
        {
            root = grid;
        }

        /// <summary>
        /// Destructor
        /// </summary>
        ~CrowdProximityGrid()
        {
            Dispose();
        }

        internal void Dispose()
        {
            root = IntPtr.Zero;
            mIsDisposed = true;
        }

        /// <summary>
        /// True if the object has been disposed.
        /// </summary>
        public bool IsDisposed
        {
            get { return mIsDisposed; }
        }

        /// <summary>
        /// The item count at the specified grid location.
        /// </summary>
        /// <param name="x">
        /// The x-value of the grid location. [Limits: bounds[0] &lt;= value &lt;= bounds[2]]
        /// </param>
        /// <param name="y">
        /// The y-value of the grid location. [Limits: bounds[1] &lt;= value &lt;= bounds[3]]
        /// </param>
        /// <returns>The item count at the specified grid location.</returns>
        public int GetItemCountAt(int x, int y)
        {
            if (IsDisposed)
                return -1;
            return CrowdProximityGridEx.dtpgGetItemCountAt(root, x, y);
        }

        /// <summary>
        /// The cell size of the grid.
        /// </summary>
        /// <remarks>
        /// <para>
        /// Used for converting from grid units to world units.
        /// </para>
        /// </remarks>
        /// <returns>The cell size of the grid.</returns>
        public float GetCellSize()
        {
            if (IsDisposed)
                return -1;
            return CrowdProximityGridEx.dtpgGetCellSize(root);
        }

        /// <summary>
        /// Gets the bounds of the grid. [(minX, minY, maxX, maxY)]
        /// </summary>
        /// <remarks>
        /// To convert from grid units to world units, multipy by the grid's cell size.
        /// </remarks>
        /// <returns>The bounds of the grid.</returns>
        public int[] GetBounds()
        {
            if (IsDisposed)
                return null;
            int[] bounds = new int[4];
            CrowdProximityGridEx.dtpgGetBounds(root, bounds);
            return bounds;
        }
    }
}
