using System;
using System.ComponentModel.DataAnnotations;

namespace ClassLibrary
{
    public class Patient
    {
        [Required]
        public int ID { get; set; }
        public string Names { get; set; }
        [Required]
        public string LastNames { get; set; }
        [Required]
        public string Sex { get; set; }
        [Range (0,120)]
        public int Age { get; set; }
        [Required]
        public string Specialization { get; set; }
        [Required]
        public string EntryMethod { get; set; }
        [Required]
        public DateTime EntryDate { get; set; }
        public int Priority { get; set; }

    }
}
