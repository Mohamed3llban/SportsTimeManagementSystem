using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Sports;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Models.DTOs;
using SportsTime.Data.Entities.Finance;
using SportsTime.Data.Entities.Training;

namespace SportsTime.Services.Implementation.Sports;

public class ChampionshipService : IChampionshipService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Championship> _Championships;

    public ChampionshipService(IBaseRepository<Championship> Championships, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Championships = Championships;
    }

    public async Task<bool> Create(ChampionshipModel model)
    {
        try
        {
            var entity = _mapper.Map<Championship>(model);
            entity.Sport = null;
            entity.Trainer = null;
            await _context.Championships.AddAsync(entity);
            var result = await _context.SaveChangesAsync();
            
            if (result > 0)
            {
                var revenue = new Revenue
                {
                    Amount = model.TraineesIds.Split(',').Length * model.CostPerTrainee,
                    RecordScreenCode = 3,
                    RecordId = entity.Id,
                    Note = " إيراد" + model.Name + " عن شهر " + model.ChampDate.Date.Month + " سنة " + model.ChampDate.Year,
                };
                await _context.Revenues.AddAsync(revenue);
                await _context.SaveChangesAsync();

            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(ChampionshipModel model)
    {
        try
        {
            var entity = await _context.Championships.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Championship>(entity).State = EntityState.Detached;
            entity = _mapper.Map<Championship>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = _context.SaveChanges();
            if (result > 0)
            {
                var revenue = await _context.Revenues.FirstOrDefaultAsync(a => a.RecordId == entity.Id && a.RecordScreenCode == 3 && a.IsDeleted != true);
                if (revenue != null)
                {
                    revenue.Amount = model.TraineesIds.Split(',').Length * model.CostPerTrainee;
                }
                else
                {
                    revenue = new Revenue
                    {
                        Amount = model.TraineesIds.Split(',').Length * model.CostPerTrainee,
                        RecordScreenCode = 3,
                        RecordId = entity.Id,
                        Note = " إيراد" + model.Name + " عن شهر " + model.ChampDate.Date.Month + " سنة " + model.ChampDate.Year,
                    };
                    await _context.Revenues.AddAsync(revenue);
                }
                await _context.SaveChangesAsync();
            }
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<ChampionshipModel> GetById(int id)
    {
        try
        {
            var _data = await _context.Championships.Include(x => x.Trainer).Include(x => x.Sport)
                .Where(x => x.IsDeleted == false)
                .Select(t => new ChampionshipModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.Type,
                    SportId = t.SportId,
                    Location = t.Location,
                    TrainerId = t.TrainerId,
                    ChampDate = t.ChampDate,
                    IsIndividual = t.IsIndividual,
                    CostPerTrainee = t.CostPerTrainee,
                    TraineesIds = t.TraineesIds
                }).FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<ChampionshipModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<ChampionshipModel>> GetAll()
    {
        try
        {
            var data = await _context.Championships.Where(x => x.IsDeleted == false)
                .Include(x => x.Trainer).Include(x => x.Sport)
                .Select(t => new ChampionshipModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    Type = t.Type,
                    SportId = t.SportId,
                    Location = t.Location,
                    TrainerId = t.TrainerId,
                    ChampDate = t.ChampDate,
                    SportName = t.Sport.Name,
                    TraineesIds = t.TraineesIds,
                    TrainerName = t.Trainer.Name,
                    IsIndividual = t.IsIndividual,
                    CostPerTrainee = t.CostPerTrainee,
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<ChampionshipModel>>(data) : new List<ChampionshipModel>();
            return result;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }
    
    public async Task<List<DropDownModel>> GetAllTraineesForMultiSelect()
    {
        try
        {
            var data = await _context.Trainees.Where(x => x.IsDeleted == false)
                .Select(t => new DropDownModel
                {
                    ValueField = t.Id,
                    TextField = t.Name,
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
            var _data = await _Championships.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            _data.IsDeleted = true;
            var result = await _Championships.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }

}