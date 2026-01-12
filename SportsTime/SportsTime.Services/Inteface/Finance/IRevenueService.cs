using SportsTime.Models.DTOs.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Finance;

public interface IRevenueService
{
    Task<bool> Create(RevenueModel model);
    Task<bool> Edit(RevenueModel model);
    Task<RevenueModel> GetById(int id);
    Task<List<RevenueModel>> GetAll();
    Task<bool> Delete(int id);
}
