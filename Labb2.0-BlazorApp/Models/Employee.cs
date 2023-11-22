using System;
using System.Collections.Generic;

namespace Labb2._0_BlazorApp.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string? EmployeeName { get; set; }

    public string? EmployeeLastName { get; set; }

    public string? EmployeeEmail { get; set; }

    public int? EmployeeStore { get; set; }

    public virtual Store? EmployeeStoreNavigation { get; set; }
}
