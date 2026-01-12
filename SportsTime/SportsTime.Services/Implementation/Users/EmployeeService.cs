using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Users;
using SportsTime.Models.DTOs.Users;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsTime.Models.DTOs.Finance;

namespace SportsTime.Services.Implementation.Users;

public class EmployeeService : IEmployeeService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Employee> _employees;

    public EmployeeService(IBaseRepository<Employee> employees, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _employees = employees;
    }

    public async Task<bool> Create(EmployeeModel model)
    {
        try
        {
            var entity = _mapper.Map<Employee>(model);
            await _employees.AddAsync(entity);
            var result = await _employees.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(EmployeeModel model)
    {
        try
        {
            var entity = await _employees.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry(entity).State = EntityState.Detached;
            entity = _mapper.Map<Employee>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _employees.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<EmployeeModel> GetById(int id)
    {
        try
        {
            var _data = await _context.Employees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<EmployeeModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<EmployeeModel>> GetAll()
    {
        try
        {
            var data = await _context.Employees.Where(x => x.IsDeleted == false)
                .Select(t => new EmployeeModel
                {
                    Id = t.Id,
                    Job = t.Job,
                    Code = t.Code,
                    Name = "أ/" + t.Name,
                    Gender = t.Gender,
                    IsHired = t.IsHired,
                    Email = t.Email ?? "",
                    JoinDate = t.JoinDate,
                    IsTrainer = false,
                    PhoneNumber = t.PhoneNumber,
                }).ToListAsync();

            var trainers = _context.Trainers.Where(a => a.IsDeleted == false)
                .Select(t => new EmployeeModel
                {
                    Id = t.Id,
                    Job = "مدرب",
                    Code = t.Code,
                    Name = "ك/" + t.Name,
                    Gender = t.Gender,
                    IsHired = t.IsHired,
                    Email = t.Email ?? "",
                    JoinDate = t.JoinDate,
                    IsTrainer = true,
                    PhoneNumber = t.PhoneNumber,
                });

            data.AddRange(trainers);
            data.OrderBy(a => a.JoinDate);
            var result = data.Count > 0 ? _mapper.Map<List<EmployeeModel>>(data) : new List<EmployeeModel>();
            return result;
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
            var _data = await _employees.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            //_data.DelReason = DelReason;
            var result = await _employees.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }

    public async Task<bool> CheckIfCodeExists(int code)
    {
        try
        {
            var result = await _context.Employees.AnyAsync(x => x.Code == code);
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return default;
        }
    }

    public async Task<List<PayrollModel>> GetEmployeePayroll(int employeeId)
    {
        try
        {
            var employeeName = (await _context.Employees.FirstOrDefaultAsync(a => a.Id == employeeId))?.Name;

            var data = await _context.Payrolls.Where(a => a.IsTrainer == false && a.EmployeeId == employeeId && a.IsDeleted == false)
                .Select(a => new PayrollModel
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    SalaryAmount = a.SalaryAmount,
                    EmployeeName = employeeName,
                    DueDate = a.DueDate,
                    LastPaymentDate = a.LastPaymentDate,
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<PayrollModel>>(data) : new List<PayrollModel>();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

    public async Task<decimal> GetEmployeeSalaryAmount(int employeeId)
    {
        try
        {
            var result = await _context.Employees.Where(s => !s.IsDeleted && s.Id == employeeId)
                .Select(s => s.Salary).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { employeeId });
            return 0;
        }
    }

}