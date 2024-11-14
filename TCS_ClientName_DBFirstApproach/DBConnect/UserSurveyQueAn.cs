using System;
using System.Collections.Generic;

namespace TCS_ClientName_DBFirstApproach.DBConnect;

public partial class UserSurveyQueAn
{
    public int? QuestionOrder { get; set; }

    public int? QuestionId { get; set; }

    public string? QuestionText { get; set; }

    public string? ResponseValue { get; set; }
}
