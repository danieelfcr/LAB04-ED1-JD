using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Node<T>
    {
        public T Data { get; set; }
        public Node<T> Parent { get; set; }
        public Node<T> Left { get; set; }
        public Node<T> Right { get; set; }

        public Node(T Data)
        {
            this.Data = Data;
            Left = Right = null;
        }

    }
}
