using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace Form_Submission.Models
{
    public class Student
    {
        [Required(ErrorMessage = "Please provide  Id")]
        [Range(1,40)]
        public int Id { get; set; }
        [Required]
        [StringLength(10,ErrorMessage ="Name should not exceed 10 chars")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        [StringLength(30)]
        public string Email { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Profession { get; set; }
        public DateTime Dob { get; set; }
        public string[] Hobbies { get; set; }
    }
}