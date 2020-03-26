using System;
using System.Collections;
using System.Collections.Generic;


namespace MathematicalSetViewer.SafeQuadTree
{
    /// <summary>
    /// A safe quad tree node. 
    /// Stores the point, bounding box, and point value
    /// </summary>
    // TODO: should this implement IEnumerable<SQTNode> ?
    public unsafe class SQTNode<N, D> : IEnumerable<D>{
        private BBox<N> Bounds { get; set; }
        private SQTPoint<N> point { get; set; }
        D data { get; set; }

        public SQTNode()
        {

        }
        ~SQTNode()
        {

        }

        /// <summary>
        /// Adds, or changes a point in the SQTree
        /// </summary>
        /// <param name="pt">A point to add</param>
        /// <param name="data">The data to set</param>
        public SQTPoint<N> Update(SQTPoint<N> pt, D data)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Removes a node from the SQTree
        /// </summary>
        /// <param name="pt">The point to remove</param>
        /// <returns>The node beloning to the point, or null if not found</returns>
        public SQTPoint<N> Remove(SQTPoint<N> pt)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Determines if a point exists in the SQTree
        /// </summary>
        /// <param name="pt">The point to find</param>
        /// <param name="data">The expected data of the point</param>
        /// <returns>True if found, otherwise false</returns>
        public bool find(SQTPoint<N> pt, D data)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<D> GetEnumerator()
        {
            // TODO: Crawl the nodes
            /*
            foreach (N item in my datastruct)
            {
                yield return item;
            }
            */
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        
    }
}
