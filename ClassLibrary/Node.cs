using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Node<T>
    {
        public T Record { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T Record)
        {
            this.Record = Record;
            Left = Right = null;
        }

    }
}
