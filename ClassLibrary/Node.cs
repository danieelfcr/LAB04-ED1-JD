using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class Node<T>
    {
        T Data;
        Node<T> left { get; set; }
        Node<T> right { get; set; }

    }
}
