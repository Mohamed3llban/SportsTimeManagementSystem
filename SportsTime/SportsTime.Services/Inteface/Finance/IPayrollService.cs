using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Finance;

public interface IPayrollService
{
    Task<bool> Create(PayrollModel model);
    Task<bool> Edit(PayrollModel model);
    Task<PayrollModel> GetById(int id);
    Task<List<PayrollModel>> GetAll();
    Task<bool> Delete(int id);
}
