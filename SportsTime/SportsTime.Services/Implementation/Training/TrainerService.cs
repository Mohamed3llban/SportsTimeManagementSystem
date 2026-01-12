using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Training;
using SportsTime.Models.DTOs.Training;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsTime.Services.Inteface.Training;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Models.DTOs.Finance;
using Microsoft.VisualBasic;
using SportsTime.Data.Entities.Finance;
using SportsTime.Models.DTOs.Reports;

namespace SportsTime.Services.Implementation.Training;

public class TrainerService : ITrainerService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Trainer> _Trainers;

    public TrainerService(IBaseRepository<Trainer> Trainers, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Trainers = Trainers;
    }

    public async Task<bool> Create(TrainerModel model)
    {
        try
        {
            var entity = _mapper.Map<Trainer>(model);
            entity.Sport = null;
            await _Trainers.AddAsync(entity);
            var result = await _Trainers.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(TrainerModel model)
    {
        try
        {
            var entity = await _Trainers.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Trainer>(entity).State = EntityState.Detached;
            entity = _mapper.Map<Trainer>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Trainers.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<TrainerModel> GetById(int id)
    {
        try
        {
            var _data = await _context.Trainers.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            var model = _mapper.Map<TrainerModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<TrainerModel>> GetAll()
    {
        try
        {
            var data = await _context.Trainers.Where(x => x.IsDeleted == false).Include(x => x.Sport)
                .Select(t => new TrainerModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code,
                    Status = t.Status,
                    Gender = t.Gender,
                    SportId = t.SportId,
                    Email = t.Email ?? "",
                    Address = t.Address,
                    PhoneNumber = t.PhoneNumber,
                    IsHired = t.IsHired,
                    Salary = t.Salary,
                    JoinDate = t.JoinDate,
                    DateOfBirth = t.DateOfBirth,
                    Notes = t.Notes ?? "",
                    ImagePath = t.ImagePath,
                    CVPath = t.CVPath,
                    SportName = t.Sport.Name,
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<TrainerModel>>(data) : new List<TrainerModel>();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

    public async Task<List<PayrollModel>> GetTrainerPayroll(int trainerId)
    {
        try
        {
            var data = await _context.Payrolls.Where(x => x.IsDeleted == false && x.EmployeeId == trainerId)
                .Include(a => a.Trainer).Select(a => new PayrollModel
                {
                    Id = a.Id,
                    EmployeeId = a.EmployeeId,
                    SalaryAmount = a.SalaryAmount,
                    EmployeeName = a.Trainer.Name,
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

    public async Task<List<TrainerModel>> GetAllBySportId(int sportId)
    {
        try
        {
            var data = await _context.Trainers.Where(x => x.IsDeleted == false && x.SportId == sportId && x.IsHired == true)
                .Include(x => x.Sport)
                .Select(t => new TrainerModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Code = t.Code,
                    Status = t.Status,
                    Gender = t.Gender,
                    SportId = t.SportId,
                    Email = t.Email ?? "",
                    Address = t.Address,
                    PhoneNumber = t.PhoneNumber,
                    IsHired = t.IsHired,
                    Salary = t.Salary,
                    JoinDate = t.JoinDate,
                    DateOfBirth = t.DateOfBirth,
                    Notes = t.Notes ?? "",
                    ImagePath = t.ImagePath,
                    CVPath = t.CVPath,
                    SportName = t.Sport.Name,
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<TrainerModel>>(data) : new List<TrainerModel>();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

    public async Task<bool> CheckIfCodeExists(int code)
    {
        try
        {
            var result = await _context.Trainers.AnyAsync(x => x.Code == code);
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return default;
        }
    }

    public async Task<decimal> GetTrainerSalaryAmount(int trainerId)
    {
        try
        {
            var result = await _context.Trainers.Where(s => !s.IsDeleted && s.Id == trainerId)
                .Select(s => s.Salary).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { trainerId });
            return 0;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var _data = await _Trainers.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            //_data.DelReason = DelReason;
            var result = await _Trainers.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }

    public async Task<List<TrainerReportModel>> ReadTrainersGrid(TrainerReportParameterModel parameter)
    {
        try
        {
            if (parameter != null)
            {
                var data = await _context.Trainers.Where(x => x.IsDeleted == false)
                    .Include(x => x.Sport).Where(x =>
                        (x.Name.Contains(parameter.Name) || String.IsNullOrWhiteSpace(parameter.Name)) &&
                        (x.Code.ToString().Contains(parameter.Code.ToString()) || String.IsNullOrWhiteSpace(parameter.Code.ToString())) &&
                        (parameter.Gender == x.Gender || parameter.Gender == null) &&
                        (parameter.SportId == x.SportId || parameter.SportId == null) &&
                        (parameter.IsHired == x.IsHired || parameter.IsHired == null)
                    )
                    .Select(t => new TrainerReportModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Code = t.Code,
                        GenderName = t.Gender == 1 ? "ذكر" : "أنثى",
                        StatusName = t.IsHired == true ? "فعال" : "غير فعال",
                        Address = t.Address,
                        JoinDateFormated = t.JoinDate.Date.ToString("dd/MM/yyyy"),
                        SportName = t.Sport.Name,
                        PhoneNumber = t.PhoneNumber,
                    }).ToListAsync();
                return data;
            }
            return new List<TrainerReportModel>();
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

}
