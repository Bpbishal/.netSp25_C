using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace FormSubmission.Models
{
    public class Student
    {
        [Required(ErrorMessage ="Please provide name")]
        [StringLength(10)]
        public string Name { get; set; }
        [Required]
        [Range(1,40,ErrorMessage ="ID must be 1<=id<=40")]
        public int ID { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
    }
}