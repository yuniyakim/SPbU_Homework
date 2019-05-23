using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _8._2
{
    /// <summary>
    /// Generic tree
    /// </summary>
    public class GenericTree<T> : ISet<T> where T : IComparable
    {
        private Node head = null;
        public int Count { get; private set; }

        /// <summary>
        /// Node of the tree
        /// </summary>
        private class Node
        {
            public T Value { get; set; } 
            public Node Right { get; set; }
            public Node Left { get; set; }

            /// <summary>
            /// Node's constructor
            /// </summary>
            /// <param name="value">Given value</param>
            public Node(T value)
            {
                Value = value;
                Right = null;
                Left = null;
            }
        }

        /// <summary>
        /// Checks if the tree is read-only
        /// </summary>
        /// <returns>False</returns>
        public bool IsReadOnly => false;

        /// <summary>
        /// Adds the value into the tree
        /// </summary>
        /// <param name="value">Given value</param>
        /// <returns>True if succeeded, false otherwise</returns>
        public bool Add(T value)
        {
            if (Contains(value))
            {
                return false;
            }

            if (Count == 0)
            {
                head = new Node(value);
            }
            else
            {
                AddNode(head, value);
            }
            ++Count;
            return true;
        }

        /// <summary>
        /// Adds the value into the subtree
        /// </summary>
        /// <param name="head">Subtree's head</param>
        /// <param name="value">Given value</param>
        private void AddNode(Node head, T value)
        {
            if (value.CompareTo(head.Value) < 0 && head.Left != null)
            {
                AddNode(head.Left, value);
            }
            else if (value.CompareTo(head.Value) > 0 && head.Right != null)
            {
                AddNode(head.Right, value);
            }
            else
            {
                if (value.CompareTo(head.Value) < 0)
                {
                    head.Left = new Node(value);
                }
                else
                {
                    head.Right = new Node(value);
                }
            }
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
            if (head == null)
            {
                return false;
            }

            var temp = head;
            while (true)
            {
                if (value.CompareTo(temp.Value) == 0)
                {
                    return true;
                }
                else if (value.CompareTo(temp.Value) < 0)
                {
                    if (temp.Left == null)
                    {
                        return false;
                    }
                    temp = temp.Left;
                }
                else
                {
                    if (temp.Right == null)
                    {
                        return false;
                    }
                    temp = temp.Right;
                }
            }
        }

        /// <summary>
        /// Copies tree's elements to the specified array, starting at a particular array's position
        /// </summary>
        /// <param name="array">Specified array</param>
        /// <param name="position">Starting position</param>
        public void CopyTo(T[] array, int position)
        {
            var index = position;
            foreach (var node in this)
            {
                array[index] = node;
                ++index;
            }
        }

        /// <summary>
        /// Removes all elements in the specified collection from the current set
        /// </summary>
        /// <param name="collection">Specified collection</param>
        public void ExceptWith(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                Remove(element);
            }
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are also in a specified collection
        /// </summary>
        /// <param name="collection">Specified collection</param>
        public void IntersectWith(IEnumerable<T> collection)
        {
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    Remove(element);
                }
            }
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) subset of a specified collection
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns>True if it's a proper subset, false otherwise</returns>
        public bool IsProperSubsetOf(IEnumerable<T> collection)
        {
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether the current set is a proper (strict) superset of a specified collection
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns>True if it's a proper superset, false otherwise</returns>
        public bool IsProperSupersetOf(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Determines whether a set is a subset of a specified collection
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns>True if it's a subset, false otherwise</returns>
        public bool IsSubsetOf(IEnumerable<T> collection)
        {
            foreach (var element in this)
            {
                if (!collection.Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the current set is a superset of a specified collection
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns>True if it's a superset, false otherwise</returns>
        public bool IsSupersetOf(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (!Contains(element))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Determines whether the current set overlaps with the specified collection.
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns>True if the current set and specified collection share at least one common element, false otherwise</returns>
        public bool Overlaps(IEnumerable<T> collection)
        {
            foreach (var element in collection)
            {
                if (Contains(element))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Removes the element with the specific value
        /// </summary>
        /// <param name="value">Specific value</param>
        /// <returns>True if succeeded, false otherwise</returns>
        public bool Remove(T value)
        {
            if (!Contains(value))
            {
                return false;
            }
            head = RemoveNode(head, value);
            --Count;
            return true;
        }

        /// <summary>
        /// Removes a node with spicific value
        /// </summary>
        /// <param name="head">Subtree's head</param>
        /// <param name="value">Spicific value</param>
        private Node RemoveNode(Node head, T value)
        {
            if (head.Value.CompareTo(value) > 0)
            {
                head.Left = RemoveNode(head.Left, value);
            }
            else if (head.Value.CompareTo(value) < 0)
            {
                head.Right = RemoveNode(head.Right, value);
            }
            else
            {
                if (head.Left == null && head.Right == null)
                {
                    return null;
                }
                else if (head.Left == null && head.Right != null)
                {
                    return head.Right;
                }
                else if (head.Left != null && head.Right == null)
                {
                    return  head.Left;
                }
                else
                {
                    head.Value = Maximum(head.Left);
                    head.Left = RemoveNode(head.Left, head.Value);
                }
            }
            return head;
        }

        /// <summary>
        /// Searches for the maximum value
        /// </summary>
        /// <param name="head">Subtree's head</param>
        /// <returns>Subtree's maximum value</returns>
        private T Maximum(Node head)
        {
            var temp = head;
            while (temp.Right != null)
            {
                temp = temp.Right;
            }
            return temp.Value;
        }

        /// <summary>
        /// Determines whether the current set and the specified collection contain the same elements
        /// </summary>
        /// <param name="collection">Specified collection</param>
        /// <returns></returns>
        public bool SetEquals(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the current set so that it contains only elements that are present either in the current set or in the specified collection, but not both
        /// </summary>
        /// <param name="collection">Specified collection</param>
        public void SymmetricExceptWith(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Modifies the current set so that it contains all elements that are present in the current set, in the specified collection, or in both
        /// </summary>
        /// <param name="collection">Specified collection</param>
        public void UnionWith(IEnumerable<T> collection)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        void ICollection<T>.Add(T item)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets enumerator
        /// </summary>
        /// <returns>Tree enumerator</returns>
        public IEnumerator<T> GetEnumerator() => Traverse(head);

        /// <summary>
        /// Traverses the subtree
        /// </summary>
        /// <param name="head">Subtree's head</param>
        private IEnumerator<T> Traverse(Node head)
        {
            if (head == null)
            {
                yield break;
            }

            yield return head.Value;
            if (head.Left != null)
            {
                Traverse(head.Left);
            }
            if (head.Right != null)
            {
                Traverse(head.Right);
            }
        }

        /*public IEnumerator<T> Preorder()
        {
            if (head == null)
            {
                yield break;
            }
            var stack = new Stack<Node>();
            stack.Push(head);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node.Value;
                if (node.Right != null)
                {
                    stack.Push(node.Right);
                }
                if (node.Left != null)
                {
                    stack.Push(node.Left);
                }
            }
        }*/

        /// <summary>
        /// Gets object-enumerator
        /// </summary>
        /// <returns>Object-enumerator</returns>
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
