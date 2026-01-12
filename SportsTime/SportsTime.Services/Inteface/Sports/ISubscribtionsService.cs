using SportsTime.Models.DTOs.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Sports;

public interface ISubscribtionsService
{
    Task<bool> Create(SubscribtionModel model);
    Task<bool> Edit(SubscribtionModel model);
    Task<SubscribtionModel> GetById(int id);
    Task<List<SubscribtionModel>> GetTraineeSubsList(int traineeId);
    Task<List<SubscribtionModel>> GetAll();
    Task<bool> Delete(int id);
}