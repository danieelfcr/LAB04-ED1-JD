using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClassLibrary;

namespace LAB04_ED1.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        

        public static Func<Patient, Patient, int> PriorityComparer = (parent, root) =>
        {
            if (parent.Priority > root.Priority)
                return 1;
            else if (parent.Priority < root.Priority)
                return -1;
            else
                return 0;
        };

        public static Action<Node<Patient>, Node<Patient>> swapNodes = (parent, actualNode) =>
        {
            var aux = actualNode.Record;
            actualNode.Record = parent.Record;
            parent.Record = aux;
        };



        public static Data Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Data();
                }
                return _instance;
            }
        }

        public PriorityQueue<Patient> PatientQueue = new PriorityQueue<Patient>(PriorityComparer, swapNodes);


    }
}
