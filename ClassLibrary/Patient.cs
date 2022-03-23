using System;

namespace ClassLibrary
{
    public class Patient
    {
        public string Names { get; set; }
        public string LastNames { get; set; }
        public string Sex { get; set; }
        public DateTime BirthDate { get; set; }
        public string Specialization { get; set; }
        public string EntryMethod { get; set; }

        public DateTime EntryTime { get; set; }

    }
}
