using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchTreeClasses
{
    class Tree
    {
        private const string OPERATORS = "()^*%/+-";

        private Node<int> Root { get; set; }

        /// <returns> Returns a pre-order notation string of the tree, by assembling recursively. </returns>
        /// <accreditation> The algorithm for this function is from "Binary Tree Traversals" by Jim Bailey. </accreditation>
        private string RecursivePreOrder(Node<int> node)
        {
            string buffer = "";

            // if done with branch, return empty
            if (node == null) return buffer;

            // build buffer in proper order
            buffer += node.GetValue().ToString();
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
            buffer += node.GetValue().ToString();
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
            buffer += node.GetValue().ToString();

            return buffer;
        }



        // overloaded constructor
        public Tree() => Root = null;

        // overloaded constructor
        public Tree(int value) => Root = new(value);



        public void insertValue(int value)
        {
            throw new NotImplementedException();
        }


        public bool findValue(int value)
        {
            throw new NotImplementedException();
        }

        public bool removeValue(int value)
        {
            throw new NotImplementedException();
        }

        /// <returns> Returns a string containing a prefix version of the ParseTree. </returns>
        public string PreOrder() => RecursivePreOrder(Root);

        /// <returns> Returns a string containing a infix version of the ParseTree. </returns>
        public string InOrder() => RecursiveInOrder(Root);

        /// <returns> Returns a string containing a postfix version of the ParseTree. </returns>
        public string PostOrder() => RecursivePostOrder(Root);

        public int findLarger(int value)
        {
            throw new NotImplementedException();
        }


        public int removeLarger(int value)
        {
            throw new NotImplementedException();
        }
    }
}
