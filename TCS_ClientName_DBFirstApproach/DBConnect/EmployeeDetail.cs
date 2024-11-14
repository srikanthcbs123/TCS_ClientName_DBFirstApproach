﻿using System;
using System.Collections.Generic;

namespace TCS_ClientName_DBFirstApproach.DBConnect;

public partial class EmployeeDetail
{
    public int EmpId { get; set; }

    public string? EmpName { get; set; }

    public DateOnly? DateOfBirth { get; set; }

    public string? EmailId { get; set; }

    public string? Gender { get; set; }

    public string? Address { get; set; }

    public string? PinCode { get; set; }
}
