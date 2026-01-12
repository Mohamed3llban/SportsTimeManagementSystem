using SportsTime.Models.DTOs.Sports;

namespace SportsTime.Models.DTOs.Reports;

public class SportReportParameterModel
{
    public string? Name { get; set; }
}

public class SportReportModel : SportModel
{
    public string? JoinDateFormated { get; set; }
    public string? sportTypeName{ get; set; }
}