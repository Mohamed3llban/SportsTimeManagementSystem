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

public class ExpenseService : IExpenseService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Expense> _Expenses;

    public ExpenseService(IBaseRepository<Expense> Expenses, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Expenses = Expenses;
    }

    public async Task<bool> Create(ExpenseModel model)
    {
        try
        {
            var entity = _mapper.Map<Expense>(model);
            await _Expenses.AddAsync(entity);
            var result = await _Expenses.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(ExpenseModel model)
    {
        try
        {
            var entity = await _context.Expenses.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Expense>(entity).State = EntityState.Detached;
            entity.Note = model.Note;
            entity.Amount = model.Amount;
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Expenses.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<ExpenseModel> GetById(int id)
    {
        try
        {
            var _data = await _Expenses.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
            var model = _mapper.Map<ExpenseModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<ExpenseModel>> GetAll()
    {
        try
        {
            var data = await _context.Expenses.Where(a => !a.IsDeleted)
                .Select(a => new ExpenseModel
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
            var _data = await _Expenses.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            var result = await _Expenses.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }
}