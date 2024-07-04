using System;
using System.Collections.Generic;

namespace Test_App_API.DBContext;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public int? DesignationId { get; set; }

    public decimal? Salary { get; set; }

    public bool? Status { get; set; }
}
