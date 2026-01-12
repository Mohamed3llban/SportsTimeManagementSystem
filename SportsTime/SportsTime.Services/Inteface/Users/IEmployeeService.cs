using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Users;

public interface IEmployeeService
{
    Task<bool> Create(EmployeeModel model);
    Task<bool> Edit(EmployeeModel model);
    Task<EmployeeModel> GetById(int id);
    Task<List<EmployeeModel>> GetAll();
    Task<bool> Delete(int id);
    Task<bool> CheckIfCodeExists(int code); // CODE Check If Exists :) OnChange() ✅
    Task<List<PayrollModel>> GetEmployeePayroll(int employeeId); 
    Task<decimal> GetEmployeeSalaryAmount(int employeeId);
}