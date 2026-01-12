using SportsTime.Models.DTOs.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Finance;

public interface IExpenseService
{
    Task<bool> Create(ExpenseModel model);
    Task<bool> Edit(ExpenseModel model);
    Task<ExpenseModel> GetById(int id);
    Task<List<ExpenseModel>> GetAll();
    Task<bool> Delete(int id);
}
