﻿using System;
using System.Collections.Generic;

namespace TCS_ClientName_DBFirstApproach.DBConnect;

public partial class Departement
{
    public int Deptid { get; set; }

    public string Deptname { get; set; } = null!;

    public string Deptlocation { get; set; } = null!;
}
