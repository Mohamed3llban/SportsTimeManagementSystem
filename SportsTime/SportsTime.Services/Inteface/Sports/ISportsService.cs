using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Sports;

public interface ISportsService
{
    Task<bool> Create(SportModel model);
    Task<bool> Edit(SportModel model);
    Task<SportModel> GetById(int id);
    Task<List<SportModel>> GetAll();
    Task<bool> Delete(int id);
    Task<decimal> GetSportSubscribtionCost(int sportId);
    Task<List<SportReportModel>> ReadSportsGrid(SportReportParameterModel parameter);
}
