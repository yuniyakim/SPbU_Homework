using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace _8._2
{
    public class GenericBinaryTree<T> : ISet<T>
    {
        private Node head = null;
        public int Count { get; private set; }

        /// <summary>
        /// Node of the tree
        /// </summary>
        private class Node
        {
            public T Value { get; private set; }
            public Node Right { get; private set; } = null;
            public Node Left { get; private set; } = null;
        }

        /// <summary>
        /// Checks if the list is read-only
        /// </summary>
        /// <returns>False</returns>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the value into the tree
        /// </summary>
        /// <param name="value">Given value</param>
        public bool Add(T value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Clears the tree
        /// </summary>
        public void Clear()
        {
            head = null;
            Count = 0;
        }

        /// <summary>
        /// Checks if the specific value is contained in the tree
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>True if contained, false otherwise</returns>
        public bool Contains(T value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Copies tree's elements to the specified array, starting at a particular array's position
        /// </summary>
        /// <param name="array">Specified array</param>
        /// <param name="position">Starting position</param>
        public void CopyTo(T[] array, int position)
        {
            throw new NotImplementedException();
        }

        public void ExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void IntersectWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsProperSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSubsetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool IsSupersetOf(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public bool Overlaps(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }


        /// <summary>
        /// Removes the element with the specific value
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>True if succeeded, false otherwise</returns>
        public bool Remove(T value)
        {
            throw new NotImplementedException();
        }

        public bool SetEquals(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void SymmetricExceptWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        public void UnionWith(IEnumerable<T> other)
        {
            throw new NotImplementedException();
        }

        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>Tree enumerator</returns>
        public IEnumerator<T> GetEnumerator() => new TreeEnumerator(this);

        /// <summary>
        /// Gets object-enumerator
        /// </summary>
        /// <returns>Object-enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        /// <summary>
        /// Tree enumerator
        /// </summary>
        private class TreeEnumerator : IEnumerator<T>
        {
            private GenericBinaryTree<T> tree;
            private Node current = null;

            /// <summary>
            /// List enumerator's constructor
            /// </summary>
            /// <param name="tree">Given tree</param>
            public TreeEnumerator(GenericBinaryTree<T> tree)
            {
                this.tree = tree;
            }

            /// <summary>
            /// Gets the current element
            /// </summary>
            object IEnumerator.Current => current;

            /// <summary>
            /// Gets the value of the current element
            /// </summary>
            public T Current => current.Value;

            /// <summary>
            /// Moves to the next element in the tree
            /// </summary>
            /// <returns>True if succeeded, false otherwise</returns>
            public bool MoveNext()
            {
                if (current == null)
                {
                    if (tree.head == null)
                    {
                        return false;
                    }

                    current = tree.head;
                    return true;
                }

                //if (current.Next == null)
                //{
                    return false;
                //}

                //current = current.Next;
                //return true;
            }

            /// <summary>
            /// Sets enumerator to its initial position
            /// </summary>
            public void Reset() => current = null;

            /// <summary>
            /// Disposes
            /// </summary>
            public void Dispose()
            {
            }
        }
    }
}
