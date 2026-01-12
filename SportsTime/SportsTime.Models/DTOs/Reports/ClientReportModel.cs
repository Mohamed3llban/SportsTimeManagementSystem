using SportsTime.Models.DTOs.Training;
using SportsTime.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Models.DTOs.Reports;

public class ClientReportParameterModel
{
    public string? Name { get; set; }
}

public class ClientReportModel : ClientModel
{
    public string? JoinDateFormated { get; set; }
    public string? StatusName { get; set; }
}