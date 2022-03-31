using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    [Serializable]
    public class Patient
    {
        
        
        [Required]
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        [Range (0,120)]
        public int Age { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string EntryMethod { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }

        public string EntryTime { get; set; }
        public int Priority { get; set; }

    }
}
