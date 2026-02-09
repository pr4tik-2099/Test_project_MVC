using System.ComponentModel.DataAnnotations;

namespace Test_project.Models
{
    public class UserDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Email Id is required")]
        [RegularExpression(@"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$", ErrorMessage = "Invalid Email Address.")]
        public required string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile No. is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Invalid Mobile Number")]
        public required string MobileNo { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public required string Address { get; set; }

        [Required(ErrorMessage = "gender is required")]
        public required string Gender { get; set; }

        [Required(ErrorMessage = "State is required")]
        public required string State { get; set; }

        [Required(ErrorMessage = "Hobbies are required")]
        public required List<string> Hobbies { get; set; }
    }
}
