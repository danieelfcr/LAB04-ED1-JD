using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    interface IPriorityQueue<T>
    {
        
        bool IsEmpty();
        Node<T> Add(Node<T> root, Node<T> node);
        void Swap(ref Node<T> parent, ref Node<T> node);
        void Remove(Node<T> root);

        Node<T> Peek(Node<T> root);
    }
}
