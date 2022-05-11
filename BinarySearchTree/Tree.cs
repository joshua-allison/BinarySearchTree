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

        /// <summary>
        /// Find and remove the node that contains the passed in value.
        /// </summary>
        /// <param name="root"> The root of This binary tree. </param>
        /// <param name="value"> The value to find, and remove if found. </param>
        /// <returns> True if the value is found and removed, false otherwise. </returns>
        /// <accreditation> The algorithm for this function is based heavily on "Deletion from BST (Binary Search Tree)" by Techie Delight: https://www.techiedelight.com/deletion-from-bst/ </accreditation>
        private bool RecursiveDeleteNode(Node<int> root, int value)
        {
            //
            bool valueFound = false;

            // pointer to store the parent of the current node
            Node<int> parent = null;

            // start with the root node
            Node<int> node = root;

            // search key in the BST and set its parent pointer
            SearchValue(ref node, value, ref parent);

            // return if the key is not found in the tree
            if (node == null) valueFound = false;
            else
            {
                // Case 1: node to be deleted has no children, i.e., it is a leaf node
                if (node.GetLeft() is null && node.GetRight() is null)
                {
                    // if the node to be deleted is not a root node, then set its
                    // parent left/right child to null
                    if (node != root)
                    {
                        if (parent.GetLeft() == node)
                            parent.SetLeft(null);
                        else parent.SetRight(null);
                    }
                    // if the tree has only a root node, set it to null
                    else
                    {
                        root = null;
                    }
                }

                // Case 2: node to be deleted has two children
                else if (node.GetLeft() is not null && node.GetRight() is not null)
                {
                    // find its inorder successor node
                    Node<int> successor = GetMinimumKeyNode(node.GetRight());

                    // store successor value
                    int val = successor.GetValue();

                    // recursively delete the successor. Note that the successor
                    // will have at most one child (right child)
                    RecursiveDeleteNode(root, successor.GetValue());

                    // copy value of the successor to the current node
                    node.SetValue(val);
                }

                // Case 3: node to be deleted has only one child
                else
                {
                    // choose a child node
                    Node<int> child = (node.GetLeft() is not null) ? node.GetLeft() : node.GetRight();

                    // if the node to be deleted is not a root node, set its parent
                    // to its child
                    if (node != root)
                    {
                        if (node == parent.GetLeft()) parent.SetLeft(child);
                        else parent.SetRight(child);
                    }

                    // if the node to be deleted is a root node, then set the root to the child
                    else root = child;
                }
                valueFound = true;
            }
            return valueFound;
        }

        /// <summary>
        /// "Iterative function to search in the subtree rooted at `node` and set its parent."
        /// "Note that `node` and `parent` is passed by reference to the function."
        /// </summary>
        /// <accreditation> The algorithm for this function is from "Deletion from BST (Binary Search Tree)" by Techie Delight: https://www.techiedelight.com/deletion-from-bst/ </accreditation>
        private static void SearchValue(ref Node<int> node, int value, ref Node<int> parent)
        {
            // traverse the tree and search for the key
            while (node is not null && node.GetValue() != value)
            {
                // update the parent to the current node
                parent = node;

                // if the given key is less than the current node, go to the left subtree;
                // otherwise, go to the right subtree
                node = node.GetValue() > value ? node.GetLeft() : node.GetRight(); 
            }
        }

        /// <summary>
        /// "Helper function to find minimum value node in the subtree rooted at `node`"
        /// </summary>
        /// <param name="node"> The node to start the recursive function from. </param>
        /// <returns> The node in the binary tree that contains the smallest value. </returns>
        /// <accreditation> The algorithm for this function is based heavily on "Deletion from BST (Binary Search Tree)" by Techie Delight: https://www.techiedelight.com/deletion-from-bst/ </accreditation>
        private Node<int> GetMinimumKeyNode(Node<int> node) => node.GetLeft() is null ? node : GetMinimumKeyNode(node.GetLeft()); 



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
        /// Calls RecursiveDeleteNode to find and remove the node conatiaining the value, and then recursively reorders the binary tree (rather than just marking it as deleted.)
        /// </summary>
        /// <param name="value"> The value to search for, and subsequently removed, if found. </param>
        /// <returns> True if the value is found and removed, false otherwise. </returns>
        public bool RemoveValue(int value) => RecursiveDeleteNode(Root, value);

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
