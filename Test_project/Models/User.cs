using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_project.Models;

public partial class Users
{
    [Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "Email Id is required")]
    public required string EmailId { get; set; }

    [Required(ErrorMessage = "mobile No. is required")]
    public required string MobileNo { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public required string Address { get; set; }

    [Required(ErrorMessage = "gender is required")]
    public required string Gender { get; set; }

    [Required(ErrorMessage = "State is required")]
    public required string State { get; set; }

    [Required(ErrorMessage = "Hobbies are required")]
    public required string Hobbies { get; set; } = null!;
}
