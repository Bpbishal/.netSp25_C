using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UsageOfDTO.DTOs
{
    public class StudentDTO
    {
        [Required]
        [StringLength(50)]
        public string FName { get; set; }
        [Required]
        [StringLength (50)]
        public string LName { get; set; }
        public DateTime Dob { get; set; }
        public double Cgpa { get; set; }
    }
}