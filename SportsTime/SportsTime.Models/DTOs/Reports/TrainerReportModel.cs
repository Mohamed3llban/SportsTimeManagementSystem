using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Reports;

public class TrainerReportModel : TrainerModel
{
    public string? JoinDateFormated { get; set; }
    public string? GenderName { get; set; }
    public string? StatusName { get; set; }
}

public class TrainerReportParameterModel
{
    public string? Name { get; set; }
    public int? Code { get; set; }
    public int? Gender { get; set; }
    public int? SportId { get; set; }
    public bool IsHired { get; set; }
}