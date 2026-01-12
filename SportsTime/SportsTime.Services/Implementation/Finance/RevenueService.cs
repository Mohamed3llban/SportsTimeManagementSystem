using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Finance;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Repositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Finance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Implementation.Finance;

public class RevenueService : IRevenueService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Revenue> _Revenues;

    public RevenueService(IBaseRepository<Revenue> Revenues, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Revenues = Revenues;
    }

    public async Task<bool> Create(RevenueModel model)
    {
        try
        {
            var entity = _mapper.Map<Revenue>(model);
            await _Revenues.AddAsync(entity);
            var result = await _Revenues.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(RevenueModel model)
    {
        try
        {
            var entity = await _context.Revenues.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Revenue>(entity).State = EntityState.Detached;
            entity.Note = model.Note;
            entity.Amount = model.Amount;
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Revenues.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<RevenueModel> GetById(int id)
    {
        try
        {
            var _data = await _Revenues.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            var model = _mapper.Map<RevenueModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<RevenueModel>> GetAll()
    {
        try
        {
            var data = await _context.Revenues.Where(a => !a.IsDeleted)
                .Select(a => new RevenueModel
                {
                    Id = a.Id,
                    Note = a.Note,
                    Amount = a.Amount,
                    RecordId = a.RecordId,
                    RecordScreenCode = a.RecordScreenCode
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
            var _data = await _Revenues.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            var result = await _Revenues.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }
}