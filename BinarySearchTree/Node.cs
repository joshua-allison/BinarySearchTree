using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTreeClasses
{
    /// <summary>
    /// Models a node of a binary tree.
    /// </summary>
    /// <accreditation> The structure of this class is from "Binary Trees" by Jim Bailey. </accreditation>
    /// <typeparam name="T"> The data type to be stored within each node of the tree</typeparam>
    class Node <T>
    {
        private T Value; // the datum stored within each node of the tree
        private Node<T> Left; // the left-hand child node of this node
        private Node<T> Right; // the right-hand child node of this node 
        private Node<T> Parent; // the parent of this node

        public Node (T value)
        {
            Left = Right = Parent = null;
            Value = value;
        }

        // setters
        public void SetLeft(Node<T> left) => Left = left;
        public void SetRight(Node<T> right) => Right = right;
        public void SetParent(Node<T> parent) => Parent = parent;
        public void SetValue(T value) => Value = value;

        // getters
        public Node<T> GetLeft() => Left;
        public Node<T> GetRight() => Right;
        public Node<T> GetParent() => Parent;
        public T GetValue() => Value;

    }
}
