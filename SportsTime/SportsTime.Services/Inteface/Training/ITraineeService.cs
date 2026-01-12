using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Training;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Training;

public interface ITraineeService
{
	Task<bool> Create(TraineeModel model);
	Task<bool> Edit(TraineeModel model);
	Task<TraineeModel> GetById(int id);
	Task<List<TraineeModel>> GetAll();
    Task<bool> CheckIfCodeExists(int code);
	Task<bool> Delete(int id);
	Task<List<TraineeReportModel>> ReadTraineesGrid(TraineeReportParameterModel parameter);
}