using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;

namespace Test_project.Models
{
    public partial class Users
    {
        
        public int ID { get;}

        [Required(ErrorMessage ="Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email is required")]
        public required string Email { get; set; }
        
        [Required(ErrorMessage = "Mobile No. is required")]
        public required string Mobile_No { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }

        [Required(ErrorMessage = "Hobbies is required")]
        public required string Hobbies { get; set; }

    }
}
