using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class PriorityQueue<T> : IPriorityQueue<T>
    {
        public Node<T> Root;
        public bool IsEmpty(Node<T> root)
        {
            if (root == null)
            {
                return true;
            }
            return false;
        }

        public void Add(Node<T> root)
        {

        }

        public void Remove(Node<T> root)
        {

        }

        public Node<T> Peek(Node<T> root)
        {
            throw new NotImplementedException();
        }
    }
}
