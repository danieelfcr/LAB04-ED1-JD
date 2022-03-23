using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    interface IPriorityQueue<T>
    {
        
        bool IsEmpty(Node<T> root);
        void Add(Node<T> root);
        void Remove(Node<T> root);

        Node<T> Peek(Node<T> root);
    }
}
