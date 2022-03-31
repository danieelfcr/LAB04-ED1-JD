using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Runtime.Serialization;

namespace ClassLibrary
{
    
    public static class Ext
    {
        public static PriorityQueue<Patient> deepCopy(this PriorityQueue<Patient> obj)
        {
            using (var Stream = new MemoryStream())
            {
                var newFormatter = new BinaryFormatter();
                newFormatter.Serialize(Stream, obj);
                Stream.Position = 0;

                return (PriorityQueue<Patient>)newFormatter.Deserialize(Stream);
            }
        }
    }


    [Serializable]
    public class PriorityQueue<T> : IPriorityQueue<T>
    {
        public Node<T> Root;
        public int NodeCount;
        public Queue<Node<T>> NodesToVisit = new Queue<Node<T>>();
        public List<T> NodeList = new List<T>();
        

        [NonSerialized]
        public Func<T, T, int> PriorityComparer;
        [NonSerialized]
        public Action<Node<T>, Node<T>> swapNodes;

        
        public PriorityQueue(Func<T, T, int> comparer, Action<Node<T>, Node<T>> swapNodes)
        {
            NodeCount = 0;
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
                NodeList.Add(root.Record);
                NodeCount++;
                
            }
            else
            {
                var aux = NodesToVisit.Peek();
                if (aux.Left == null)
                {
                    aux.Left = Add(aux.Left, node);
                    aux.Left.Parent = aux;

                    if (PriorityComparer(aux.Record, aux.Left.Record) == -1)
                    {
                        var auxLeft = aux.Left;
                        Swap(ref aux, ref auxLeft);
                    }
                    
                }
                else if (aux.Right == null)
                {
                    aux.Right = Add(aux.Right, node);
                    aux.Right.Parent = aux;

                    if (PriorityComparer(aux.Record, aux.Right.Record) == -1)
                    {
                        var auxRight = aux.Right;
                        Swap(ref aux, ref auxRight);
                    }
                    
                }

                if (aux.Right != null && aux.Left != null)
                {
                    NodesToVisit.Peek().IsNull = 1;
                    UpdateNodesToVisit();
                    
                }



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


        public void Remove()
        {
            string BinaryNodeCount = Convert.ToString(NodeCount, 2);
            


            if (BinaryNodeCount != "1" && NodeCount != 0)
            {
                var aux = Root.Record;
                swapNodes(Root, FindNode(BinaryNodeCount, ref Root));
                FindNode(BinaryNodeCount, ref Root).IsNull = 1;
                NodeList.Remove(FindNode(BinaryNodeCount, ref Root).Record);
                FindNode(BinaryNodeCount, ref Root).Parent.DeleteSuccesor(int.Parse(BinaryNodeCount[BinaryNodeCount.Length - 1].ToString()));
                NodeCount--;

                UpdateNodesToVisit();
                UpdateQueue(ref Root);
                
                
            }
            else
            {
                if (NodeCount != 0)
                {

                    if (NodesToVisit.Count != 0)
                    {
                        NodesToVisit.Peek().IsNull = 1;
                        UpdateNodesToVisit();
                    }
                    
                    NodeList.Remove(Root.Record);
                    
                    Root = null;
                    NodeCount--;
                    
                }
                    
                
                
            }
        }


        public List<T> GetNodeList(Node<T> root)
        {
           
            List<T> NodeList = new List<T>();
            
            int NodeCountAux = NodeCount;
            while (NodeCountAux != 0)
            {
                string BinaryNodeCount = Convert.ToString(NodeCountAux, 2);

                if (BinaryNodeCount != "1")
                {
                    

                    NodeList.Add(root.Record);
                    swapNodes(root, FindNode(BinaryNodeCount, ref root));
                    
                    
                    FindNode(BinaryNodeCount, ref Root).Parent.DeleteSuccesor(int.Parse(BinaryNodeCount[BinaryNodeCount.Length - 1].ToString()));
                    NodeCountAux--;
                    

                    UpdateQueue(ref Root);
                }
                else
                {
                    NodeList.Add(root.Record);
                    root = null;
                    NodeCountAux--;
                    
                }
            }

            return NodeList;

            

        }

        
       

        public Node<T> FindNode(string BinaryPath, ref Node<T> ActualNode)
        {
            
            BinaryPath = BinaryPath.Remove(0, 1);
            if (BinaryPath != "")
            {
                

                if (BinaryPath[0] == '0')
                {
                    var aux = ActualNode.Left;
                    return FindNode(BinaryPath, ref aux);
                }
                else
                {
                    var aux = ActualNode.Right;
                    return FindNode(BinaryPath, ref aux);

                }
                    
            }
            


            return ActualNode;
        }

        public void UpdateQueue(ref Node<T> root)
        {
            if (root.Right != null && root.Left != null)
            {
                var higherSuccesor = root.GetHigherSuccesor(root, PriorityComparer);
                swapNodes(root, higherSuccesor);
                UpdateQueue(ref higherSuccesor);
            }
            else if (root.Right != null && root.Left == null)
            {
                if (PriorityComparer(root.Record, root.Right.Record) == -1)
                    swapNodes(root, root.Right);

                var aux = root.Right;
                UpdateQueue(ref aux);
            }
            else if (root.Right == null && root.Left != null)
            {
                if (PriorityComparer(root.Record, root.Left.Record) == -1)
                    swapNodes(root, root.Left);

                var aux = root.Left;
                UpdateQueue(ref aux);
            }


                
        }

       
        public Node<T> Peek()
        {
            return Root;
        }

        public void UpdateNodesToVisit()
        {
            Node<T>[] nodesArray = new Node<T>[NodesToVisit.Count];
            for (int i = 0; i < nodesArray.Length; i++)
            {
                nodesArray[i] = NodesToVisit.Dequeue();
            }

            for (int i = 0; i < nodesArray.Length; i++)
            {
                if (nodesArray[i].IsNull != 1)
                    NodesToVisit.Enqueue(nodesArray[i]);
            }
        }






       

    }
}
