using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Reports;

public class TraineeReportParameterModel
{
    public string? Name { get; set; }
    public int? Code { get; set; }
    public int? Gender { get; set; }
    public int? SportId { get; set; }
    public int? TrainerId { get; set; }
}

public class TraineeReportModel : TraineeModel
{
    public string? JoinDateFormated { get; set; }
    public string? GenderName { get; set; }
}