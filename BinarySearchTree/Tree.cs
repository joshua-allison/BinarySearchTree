using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeClasses
{
    class Tree
    {
        private Node<int> Root { get; set; }

        /// <returns> Returns a pre-order notation string of the tree, by assembling recursively. </returns>
        /// <accreditation> The algorithm for this function is from "Binary Tree Traversals" by Jim Bailey. </accreditation>
        private string RecursivePreOrder(Node<int> node)
        {
            string buffer = "";

            // if done with branch, return empty
            if (node == null) return buffer;

            // build buffer in proper order
            buffer += node.GetValue().ToString() + " ";
            buffer += RecursivePreOrder(node.GetLeft());
            buffer += RecursivePreOrder(node.GetRight());

            return buffer;
        }

        /// <returns> Returns an in-order notation string of the tree, by assembling recursively. </returns>
        /// <accreditation> The algorithm for this function is from "Binary Tree Traversals" by Jim Bailey. </accreditation>
        private string RecursiveInOrder(Node<int> node)
        {
            string buffer = "";

            // if done with branch, return empty
            if (node == null) return buffer;

            // build buffer in proper order
            buffer += RecursiveInOrder(node.GetLeft());
            buffer += node.GetValue().ToString() + " ";
            buffer += RecursiveInOrder(node.GetRight());


            return buffer;
        }

        /// <returns> Returns a post-order notation string of the tree, by assembling recursively. </returns>
        /// <accreditation> The algorithm for this function is from "Binary Tree Traversals" by Jim Bailey. </accreditation>
        private string RecursivePostOrder(Node<int> node)
        {
            string buffer = "";

            // if done with branch, return empty
            if (node == null) return buffer;

            // build buffer in proper order
            buffer += RecursivePostOrder(node.GetLeft());
            buffer += RecursivePostOrder(node.GetRight()); 
            buffer += node.GetValue().ToString() + " ";

            return buffer;
        }

        ///<summary> "Follow down the tree until we find a leaf and add either to its left or right, depending on the relation between the value being added and the value of the leaf" </summary>
        /// <accreditation> The algorithm for this function is from "Binary Search Trees" by Jim Bailey. </accreditation>
        private void RecursiveAddValue(int value, Node<int> node)
        {
            if (value < node.GetValue())
            {
                if (node.GetLeft() == null)
                {
                    Node<int> temp = new(value);
                    node.SetLeft(temp);
                }
                else RecursiveAddValue(value, node.GetLeft());
            }
            else
            {
                if (node.GetRight() == null)
                {
                    Node<int> temp = new(value);
                    node.SetRight(temp);
                }
                else RecursiveAddValue(value, node.GetRight());
            }
        }

        /// <summary>
        /// "For each node encountered, first check for equality and return true since we have found the value being searched for."
        /// "Then, if we do not have equality, we go to either the left or right subtree depending on the relationship between the value being searched for and the value in the node."
        /// </summary>
        /// <param name="value"> The value to search the tree for. </param>
        /// <param name="node"> The node to start the search from. </param>
        /// <returns> True if the value is found, false otherwise. </returns>
        /// <accreditation> The algorithm for this function is from "Binary Search Trees" by Jim Bailey. </accreditation>
        private bool RecursiveFindValue(int value, Node<int> node)
        {
            if (node is null) return false;
            if (node.GetValue() == value) return true;
            return node.GetValue() > value ? RecursiveFindValue(value, node.GetLeft()) : RecursiveFindValue(value, node.GetRight());
        }



        // overloaded constructor
        public Tree() { }

        // overloaded constructor
        public Tree(int value) => Root = new(value);


        /// <summary>
        /// If the tee is empty, the value being inserted will be the Root. Otherwise, call RecursiveAddValue, passing in the Root and the Value passed in to InsertValue
        /// </summary>
        /// <param name="value"> The int to be added to the Binary Search Tree. </param>
        /// <accreditation> The algorithm for this function is from "Binary Search Trees" by Jim Bailey. </accreditation>
        public void InsertValue(int value)
        {
            if (Root == null)
            {
                Node<int> temp = new(value);
                Root = temp;
                return;
            }
            else RecursiveAddValue(value, Root);
        }

        /// <summary>
        /// "Start at the root and continue until we find the value or reach a nullptr. (...) Choose to go either right or left depending on a comparison of the value being sarched for and the value in the node"
        /// This is the iterative version.
        /// </summary>
        /// <param name="value"> The value to search the tree for. </param>
        /// <returns> True if the value is found, false otherwise</returns>
        /// <accreditation> The algorithm for this function is from "Binary Search Trees" by Jim Bailey. </accreditation>
        //public bool FindValue(int value)
        //{
        //    Node<int> node = Root;
        //    while (node != null)
        //    {
        //        if (node.GetValue() == value) return true;
        //        node = node.GetValue() > value ? node.GetLeft() : node.GetRight();
        //    }
        //    return false;
        //}

        public bool FindValue(int value) => RecursiveFindValue(value, Root);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public bool RemoveValue(int value)
        {
            throw new NotImplementedException();
        }

        /// <returns> Returns a string containing a prefix version of the ParseTree. </returns>
        public string PreOrder() => RecursivePreOrder(Root);

        /// <returns> Returns a string containing a infix version of the ParseTree. </returns>
        public string InOrder() => RecursiveInOrder(Root);

        /// <returns> Returns a string containing a postfix version of the ParseTree. </returns>
        public string PostOrder() => RecursivePostOrder(Root);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int FindLarger(int value)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int RemoveLarger(int value)
        {
            throw new NotImplementedException();
        }
    }
}
