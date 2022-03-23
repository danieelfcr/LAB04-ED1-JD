using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    class PriorityQueue<T> : IPriorityQueue<T>
    {
        public Node<T> Root;
        public Queue<Node<T>> NodesToVisit = new Queue<Node<T>>();
        public Func<T, T, int> PriorityComparer;
        public Action<Node<T>, Node<T>> swapNodes;
        
        public PriorityQueue(Func<T, T, int> comparer, Action<Node<T>, Node<T>> swapNodes)
        {
            PriorityComparer = comparer;
            this.swapNodes = swapNodes;
        }

        public bool IsEmpty()
        {
            return Root == null;
        }

        public Node<T> Add(Node<T> root, Node<T> node)
        {
            if (root == null)
            {
                root = node;
                NodesToVisit.Enqueue(root);
            }
            else
            {
                var aux = NodesToVisit.Peek();
                if (aux.Left == null)
                {
                    aux.Left = Add(aux.Left, node);
                    aux.Left.Parent = aux;

                    if (PriorityComparer(aux.Data, aux.Left.Data) == -1)
                    {
                        var auxLeft = aux.Left;
                        Swap(ref aux, ref auxLeft);
                    }
                    else if (PriorityComparer(aux.Data, aux.Left.Data) == 0)
                    {

                    }
                }
                else if (aux.Right == null)
                {
                    aux.Right = Add(aux.Right, node);
                    aux.Right.Parent = aux;

                    if (PriorityComparer(aux.Data, aux.Right.Data) == -1)
                    {
                        var auxRight = aux.Right;
                        Swap(ref aux, ref auxRight);
                    }
                    else if (PriorityComparer(aux.Data, aux.Right.Data) == 0)
                    {

                    }
                }

                if (aux.Right != null && aux.Left != null)
                    NodesToVisit.Dequeue();
            }

            return root;
        }

        public void Swap(ref Node<T> parent, ref Node<T> node)
        {

            if (parent != null)
            {
                swapNodes(parent, node);
                var parentAux = parent.Parent;
                var nodeParentAux = node.Parent;
                Swap(ref parentAux, ref nodeParentAux);
            }

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
