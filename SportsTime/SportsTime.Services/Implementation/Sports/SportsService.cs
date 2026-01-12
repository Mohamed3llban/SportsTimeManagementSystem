using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Sports;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Models.DTOs.Reports;

namespace SportsTime.Services.Implementation.Sports;

public class SportsService : ISportsService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Sport> _Sports;

    public SportsService(IBaseRepository<Sport> Sports, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Sports = Sports;
    }

    public async Task<bool> Create(SportModel model)
    {
        try
        {
            var entity = _mapper.Map<Sport>(model);
            await _context.Sports.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(SportModel model)
    {
        try
        {
            var entity = await _context.Sports.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Sport>(entity).State = EntityState.Detached;
            entity = _mapper.Map<Sport>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<SportModel> GetById(int id)
    {
        try
        {
            var _data = await _context.Sports.Include(x => x.Trainers).Include(x => x.Trainees)
                .Where(x => x.IsDeleted == false && x.Id == id).Select(t => new SportModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    SportType = t.SportType,
                    SubscribtionCost = t.SubscribtionCost,
                    TrainersCount = t.Trainers.Count(t => t.IsHired && !t.IsDeleted),
                    TraineesCount = t.Trainees.Count(t => !t.IsDeleted),
                }).FirstOrDefaultAsync();
            var model = _mapper.Map<SportModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<SportModel>> GetAll()
    {
        try
        {
            var data = await _context.Sports.Where(x => x.IsDeleted == false)
                .Include(x => x.Trainers).Include(x => x.Trainees)
                .Select(t => new SportModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    SportType = t.SportType,
                    TrainersCount = t.Trainers.Count(t => t.IsHired && !t.IsDeleted),
                    TraineesCount = t.Trainees.Count(t => !t.IsDeleted),
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<SportModel>>(data) : new List<SportModel>();
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
            var _data = await _Sports.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            var result = await _Sports.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }

    public async Task<decimal> GetSportSubscribtionCost(int sportId)
    {
        try
        {
            var result = await _context.Sports.Where(s => !s.IsDeleted && s.Id == sportId)
                .Select(s => s.SubscribtionCost).FirstOrDefaultAsync();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { sportId });
            return 0;
        }
    }

    public async Task<List<SportReportModel>> ReadSportsGrid(SportReportParameterModel parameter)
    {
        try
        {
            if (parameter != null)
            {
                var data = await _context.Sports.Where(x => x.IsDeleted == false).Include(x => x.Trainers).Include(x => x.Trainees)
                    .Where(x => (x.Name.Contains(parameter.Name) || String.IsNullOrWhiteSpace(parameter.Name)))
                    .Select(t => new SportReportModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        Description = t.Description,
                        sportTypeName = t.SportType == 1 ? "فردي" : "جماعي",
                        TrainersCount = t.Trainers.Count(t => t.IsHired && !t.IsDeleted),
                        TraineesCount = t.Trainees.Count(t => !t.IsDeleted),
                    }).ToListAsync();
                return data;
            }
            return new List<SportReportModel>();
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

}
