using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Sports;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsTime.Data.Entities.Finance;
using SportsTime.Data.Entities.Training;

namespace SportsTime.Services.Implementation.Sports;

public class SubscribtionsService : ISubscribtionsService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Subscribtion> _Subscribtions;
    private readonly IBaseRepository<Revenue> _Revenues;

    public SubscribtionsService(IBaseRepository<Subscribtion> Subscribtions, IMapper mapper, ILoggerService loggerService, IBaseRepository<Revenue> Revenues,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Subscribtions = Subscribtions;
        _Revenues = Revenues;
    }

    public async Task<bool> Create(SubscribtionModel model)
    {
        try
        {
            var entity = _mapper.Map<Subscribtion>(model);
            entity.Sport = null;
            entity.Trainee = null;
            entity.Trainer = null;
            await _Subscribtions.AddAsync(entity);
            var result = await _Subscribtions.SaveChangesAsync();
            if (result > 0)
            {
                var trainee = await _context.Trainees.FirstOrDefaultAsync(a => a.Id == entity.TraineeId);
                if (trainee == null)
                    return false;
                var revenue = new Revenue { 
                    Amount = model.SubscribtionCost,
                    RecordScreenCode = 1,
                    RecordId = entity.Id,
                    Note = " إيراد إشتراك اللاعب/لاعبة " + trainee.Name + " عن شهر " + model.StartingDate.Date.Month + " سنة " + model.StartingDate.Year,
                };
                await _Revenues.AddAsync(revenue);
                await _Revenues.SaveChangesAsync();
            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(SubscribtionModel model)
    {
        try
        {
            var entity = await _context.Subscribtions.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Subscribtion>(entity).State = EntityState.Detached;
            entity = _mapper.Map<Subscribtion>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Subscribtions.SaveChangesAsync();
            if (result > 0)
            {
                var revenue = await _Revenues.FirstOrDefaultAsync(a => a.RecordId == entity.Id && a.RecordScreenCode == 1 && a.IsDeleted != true);
                if (revenue != null)
                {
                    revenue.Amount = entity.SubscribtionCost;
                }
                else
                {
                    var trainee = await _context.Trainees.FirstOrDefaultAsync(a => a.Id == entity.TraineeId);
                    if (trainee == null)
                        return false; 
                    revenue = new Revenue
                    {
                        Amount = model.SubscribtionCost,
                        RecordScreenCode = 1,
                        RecordId = entity.Id,
                        Note = " إيراد إشتراك اللاعب/لاعبة " + trainee.Name + " عن شهر " + model.StartingDate.Date.Month + " سنة " + model.StartingDate.Year,
                    };
                    await _Revenues.AddAsync(revenue);
                }
                await _Revenues.SaveChangesAsync();
            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<SubscribtionModel> GetById(int id)
    {
        try
        {
            var _data = await _Subscribtions.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            var model = _mapper.Map<SubscribtionModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<SubscribtionModel>> GetAll()
    {
        try
        {
            var data = await _context.Subscribtions.Include(a => a.Sport).Include(a => a.Trainee).Include(a => a.Trainer)
                    .Where(a => !a.IsDeleted).Select(a => new SubscribtionModel
                    {
                        Id = a.Id,
                        SportName = a.Sport.Name,
                        TraineeName = a.Trainee.Name,
                        TrainerName = a.Trainer.Name,
                        SportId = a.SportId,
                        TraineeId = a.TraineeId,
                        TrainerId = a.TrainerId,
                        EndingDate = a.EndingDate,
                        StartingDate = a.StartingDate,
                        SubscribtionCost = a.SubscribtionCost,
                    }).ToListAsync();
            return data;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }
    
    public async Task<List<SubscribtionModel>> GetTraineeSubsList(int traineeId)
    {
        try
        {
            var data = await _context.Subscribtions.Include(a => a.Sport).Include(a => a.Trainee).Include(a => a.Trainer)
                    .Where(a => !a.IsDeleted && a.TraineeId == traineeId).Select(a => new SubscribtionModel
                    {
                        Id = a.Id,
                        SportName = a.Sport.Name,
                        TraineeName = a.Trainee.Name,
                        TrainerName = a.Trainer.Name,
                        SportId = a.SportId,
                        TraineeId = a.TraineeId,
                        TrainerId = a.TrainerId,
                        EndingDate = a.EndingDate,
                        StartingDate = a.StartingDate,
                        SubscribtionCost = a.SubscribtionCost,
                    }).ToListAsync();
            return data;
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
            var _data = await _Subscribtions.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            var result = await _Subscribtions.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }
}