using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Sports;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsTime.Data.Entities.Finance;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Data.Entities.Training;
using SportsTime.Models.DTOs.Users;

namespace SportsTime.Services.Implementation.Finance;

public class PayrollService : IPayrollService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Payroll> _Payrolls;
    private readonly IBaseRepository<Expense> _Expenses;
    private readonly IExpenseService _expensesService;

    public PayrollService(IBaseRepository<Payroll> Payrolls, IMapper mapper, ILoggerService loggerService,
        IExpenseService expensesService, IBaseRepository<Expense> Expenses, ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Payrolls = Payrolls;
        _Expenses = Expenses;
        _expensesService = expensesService;
    }

    public async Task<bool> Create(PayrollModel model)
    {
        try
        {
            var entity = _mapper.Map<Payroll>(model);
            entity.Trainer = null;
            await _Payrolls.AddAsync(entity);
            var result = await _Payrolls.SaveChangesAsync();

            if (result > 0)
            {
                var expense = new Expense
                {
                    Amount = model.SalaryAmount,
                    RecordScreenCode = 2,
                    RecordId = entity.Id,
                    Note = " مصروف راتب " + model.EmployeeName + " عن شهر " + model.LastPaymentDate.Date.Month + " سنة " + model.LastPaymentDate.Year,
                };
                await _Expenses.AddAsync(expense);
                await _Expenses.SaveChangesAsync();

            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(PayrollModel model)
    {
        try
        {
            var entity = await _context.Payrolls.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Payroll>(entity).State = EntityState.Detached;
            entity.DueDate = model.DueDate;
            entity.SalaryAmount = model.SalaryAmount;
            entity.LastPaymentDate = model.LastPaymentDate;
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Payrolls.SaveChangesAsync();
            if (result > 0)
            {
                var expense = await _Expenses.FirstOrDefaultAsync(a => a.RecordId == entity.Id && a.RecordScreenCode == 1 && a.IsDeleted != true);
                if (expense != null)
                {
                    expense.Amount = entity.SalaryAmount;
                }
                else
                {
                    expense = new Expense
                    {
                        Amount = model.SalaryAmount,
                        RecordScreenCode = 1,
                        RecordId = entity.Id,
                        Note = " مصروف راتب " + model.EmployeeName + " عن شهر " + model.LastPaymentDate.Date.Month + " سنة " + model.LastPaymentDate.Year,
                    };
                    await _Expenses.AddAsync(expense);
                }
                await _Expenses.SaveChangesAsync();
            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<PayrollModel> GetById(int id)
    {
        try
        {
            var _data = await _Payrolls.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            var model = _mapper.Map<PayrollModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<PayrollModel>> GetAll()
    {
        try
        {
            var employees = await (from _payroll in _context.Payrolls
                                   join _employee in _context.Employees
                                   on _payroll.IsTrainer equals false
                                   where _payroll.EmployeeId == _employee.Id && !_payroll.IsDeleted
                                   select new PayrollModel
                                   {
                                       Id = _payroll.Id,
                                       EmployeeId = _payroll.EmployeeId,
                                       SalaryAmount = _payroll.SalaryAmount,
                                       EmployeeName = "أ/" + _employee.Name,
                                       IsTrainer = _payroll.IsTrainer,
                                       DueDate = _payroll.DueDate,
                                       LastPaymentDate = _payroll.LastPaymentDate,
                                   }).ToListAsync();

            var fullData = await (from _payroll in _context.Payrolls
                                  join _trainer in _context.Trainers
                                  on _payroll.IsTrainer equals true
                                  where _payroll.EmployeeId == _trainer.Id && !_payroll.IsDeleted
                                  select new PayrollModel
                                  {
                                      Id = _payroll.Id,
                                      EmployeeId = _payroll.EmployeeId,
                                      SalaryAmount = _payroll.SalaryAmount,
                                      EmployeeName = "ك/" + _trainer.Name,
                                      IsTrainer = _payroll.IsTrainer,
                                      DueDate = _payroll.DueDate,
                                      LastPaymentDate = _payroll.LastPaymentDate,
                                  }).ToListAsync();

            fullData.AddRange(employees);

            return fullData.OrderByDescending(x =>x.LastPaymentDate).ToList();
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var _data = await _Payrolls.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;

            var result = await _Payrolls.SaveChangesAsync();
            if (result > 0)
            {
                var expense = _Expenses.GetAllWhereQueryable(x => x.RecordId == id).FirstOrDefault();
                if (expense != null)
                    await _expensesService.Delete(expense.Id);
            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }
}
