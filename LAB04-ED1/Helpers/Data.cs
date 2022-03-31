using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using ClassLibrary;

namespace LAB04_ED1.Helpers
{
    public class Data
    {
        private static Data _instance = null;

        public static string CorrectTime(DateTime time)
        {

            string TimeCorrection = "";

            TimeCorrection += time.Hour;

            if (time.Minute < 10)
                TimeCorrection += "0" + time.Minute;
            else
                TimeCorrection += time.Minute;

            if (time.Second < 10)
                TimeCorrection += "0" + time.Second;
            else
                TimeCorrection += time.Second;


            return TimeCorrection;
        }
        
        //[IgnoreDataMember]
        public static Func<Patient, Patient, int> PriorityComparer = (parent, root) =>
        {
            if (parent.Priority > root.Priority)
                return 1;
            else if (parent.Priority < root.Priority)
                return -1;
            else
            {
                DateTime timeParent = Convert.ToDateTime(parent.EntryTime);
                DateTime timeRoot = Convert.ToDateTime(root.EntryTime);
                
                int TimeParent = Convert.ToInt32("" + CorrectTime(timeParent));
                int TimeRoot = Convert.ToInt32("" + CorrectTime(timeRoot));

                //TimeParent > TimeRoot
                if (timeParent.CompareTo(timeRoot) == 1)
                {
                    return -1;
                }
                else
                {
                    return 1;
                }
            }               
        };

        //[IgnoreDataMember]
        public static Action<Node<Patient>, Node<Patient>> swapNodes = (parent, actualNode) =>
        {
            if (actualNode != null)
            {
                var aux = actualNode.Record;
                int IsNullAux = actualNode.IsNull;
                actualNode.IsNull = parent.IsNull;
                parent.IsNull = IsNullAux;
                actualNode.Record = parent.Record;
                parent.Record = aux;
                

            }
            
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
        public PriorityQueue<Patient> OutputPatientQueue = new PriorityQueue<Patient>(PriorityComparer, swapNodes);
        

    }
}
