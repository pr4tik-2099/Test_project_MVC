using System;
using System.Collections.Generic;

namespace Test_project.Models;

public partial class Employee
{
    public string EId { get; set; } = null!;

    public string EName { get; set; } = null!;

    public int? ESalary { get; set; }
}
