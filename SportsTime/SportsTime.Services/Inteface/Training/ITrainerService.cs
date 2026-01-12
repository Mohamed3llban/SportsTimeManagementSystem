using SportsTime.Data.Entities.Sports;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Training;

public interface ITrainerService
{
    Task<bool> Create(TrainerModel model);
    Task<bool> Edit(TrainerModel model);
    Task<TrainerModel> GetById(int id);
    Task<List<TrainerModel>> GetAll();
    Task<decimal> GetTrainerSalaryAmount(int trainerId);
    Task<List<PayrollModel>> GetTrainerPayroll(int trainerId);
    Task<List<TrainerModel>> GetAllBySportId(int sportId);
    Task<bool> CheckIfCodeExists(int code); // CODE Check If Exists :) OnChange() ✅
    Task<bool> Delete(int id);
    Task<List<TrainerReportModel>> ReadTrainersGrid(TrainerReportParameterModel parameter);
}
