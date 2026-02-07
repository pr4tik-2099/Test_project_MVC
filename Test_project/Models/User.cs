using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Test_project.Models;

public partial class User
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; } = null!;

    [Required(ErrorMessage = "Email Id is required")]
    public string? EmailId { get; set; }

    [Required(ErrorMessage = "mobile No. is required")]
    public string? MobileNo { get; set; }

    [Required(ErrorMessage = "Address is required")]
    public string Address { get; set; } = null!;

    [Required(ErrorMessage = "gender is required")]
    public string Gender { get; set; } = null!;

    [Required(ErrorMessage = "State is required")]
    public string State { get; set; } = null!;

    [Required(ErrorMessage = "Hobbies is required")]
    public string Hobbies { get; set; } = null!;
}
