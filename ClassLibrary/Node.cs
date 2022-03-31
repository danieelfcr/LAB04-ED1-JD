using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    [Serializable]
    public class Node<T>
    {
        public int IsNull { get; set; }
        public T Record { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public void DeleteSuccesor(int id)
        {
            if (id == 0)
                Left = null;
            else
                Right = null;
        }

        public Node<T> GetHigherSuccesor(Node<T> parent, Func<T, T, int> PriorityComparer)
        {
            if (parent.Left != null && parent.Right == null)
                return parent.Left;
            else if (parent.Left == null && parent.Right != null)
                return parent.Right;
            else
            {
                if (PriorityComparer(parent.Left.Record, parent.Right.Record) == 1)
                    return parent.Left;
                else
                    return parent.Right;
            }
        }


        public Node(T Record)
        {
            this.Record = Record;
            Left = Right = null;
        }

    }
}
