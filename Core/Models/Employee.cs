using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Employee
    {
        public int Id { get; set; }
        [Required, MaxLength(50, ErrorMessage = "Name cannot exceed 50 characters")]
        public string Name { get; set; }
        //[RegularExpression(@"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$",
            //ErrorMessage = "Invalid email format")]
        [EmailAddress]
        [Display(Name = "Office Email")]
        [Required]
        public string Email { get; set; }
        [Required]
        public Department? Department { get; set; }

        public string Imagepath { get; set; }
    }
}
