using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using SportsTime.Data.Entities.Training;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Repositories;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Services.Implementation.AccountServices;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Training;
using System;
using System.Collections.Generic;
using System.Formats.Tar;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Implementation.Training;

public class TraineeService : ServiceBase, ITraineeService
{
	private readonly IMapper _mapper;
	private readonly ApplicationDbContext _context;
	private readonly ILoggerService _loggerService;
	private readonly IBaseRepository<Trainee> _trainees;

	public TraineeService(IBaseRepository<Trainee> trainees, IMapper mapper, ILoggerService loggerService,
		ApplicationDbContext context)
	{
		_mapper = mapper;
		_context = context;
		_loggerService = loggerService;
		_trainees = trainees;
	}

	public async Task<bool> Create(TraineeModel model)
	{
		try
		{
			var entity = _mapper.Map<Trainee>(model);
			entity.Sport = null;
			entity.Trainer = null;
			await _trainees.AddAsync(entity);
			var result = await _trainees.SaveChangesAsync();
			return result > 0;
		}
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, new { model });
			return false;
		}
	}

	public async Task<bool> Edit(TraineeModel model)
	{
		try
		{
			var entity = await _context.Trainees.FirstOrDefaultAsync(x => x.Id == model.Id);
			_context.Entry<Trainee>(entity).State = EntityState.Detached;
			entity = _mapper.Map<Trainee>(model);
			_context.Entry(entity).State = EntityState.Modified;
			var result = await _trainees.SaveChangesAsync();
			return result > 0;
		}
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, new { model });
			return false;
		}

	}

	public async Task<TraineeModel> GetById(int id)
	{
		try
		{
			var _data = await _context.Trainees.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);
			var model = _mapper.Map<TraineeModel>(_data);
			return model;
		}
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, new { id });
			return null;
		}
	}

	public async Task<List<TraineeModel>> GetAll()
	{
		try
		{
			var data = await _context.Trainees.Where(x => x.IsDeleted == false)
				.Include(x => x.Sport).Include(x => x.Trainer)
				.Select(t => new TraineeModel
				{
					Id = t.Id,
					Name = t.Name,
					Code = t.Code,
					Status = t.Status,
					Gender = t.Gender,
					SportId = t.SportId,
					TrainerId = t.TrainerId,
					Email = t.Email ?? "",
					Address = t.Address,
					PhoneNumber = t.PhoneNumber,
					JoinDate = t.JoinDate,
					DateOfBirth = t.DateOfBirth,
					Notes = t.Notes ?? "",
					ImagePath = t.ImagePath,
					SportName = t.Sport.Name,
					TrainerName = t.Trainer.Name
				}).ToListAsync();

			var result = data.Count > 0 ? _mapper.Map<List<TraineeModel>>(data) : new List<TraineeModel>();
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
            var result = await _context.Trainees.AnyAsync(x => x.Code == code);
            return result;
        }
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, null);
			return default;
		}
	}

	public async Task<bool> Delete(int id)
	{
		try
		{
			var _data = await _trainees.FirstOrDefaultAsync(x => x.Id == id);
			_data.IsDeleted = true;
			//_data.DelReason = DelReason;
			var result = await _trainees.SaveChangesAsync();
			return result > 0;
		}
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, null);
			return false;
		}
	}

	public async Task<List<TraineeReportModel>> ReadTraineesGrid(TraineeReportParameterModel parameter)
	{
		try
		{
			if (parameter != null)
			{
				var data = await _context.Trainees.Where(x => x.IsDeleted == false)
					.Include(x => x.Sport).Include(x => x.Trainer)
					.Where
					(	x =>
						(x.Name.Contains(parameter.Name) || String.IsNullOrWhiteSpace(parameter.Name)) &&
						(x.Code.ToString().Contains(parameter.Code.ToString()) || String.IsNullOrWhiteSpace(parameter.Code.ToString())) &&
						(parameter.Gender == x.Gender || parameter.Gender == null) &&
						(parameter.SportId == x.SportId || parameter.SportId == null) &&
						(parameter.TrainerId == x.TrainerId || parameter.TrainerId == null)
					)
					.Select(t => new TraineeReportModel
					{
						Id = t.Id,
						Name = t.Name,
						Code = t.Code,
                        GenderName = t.Gender == 1 ? "ذكر" : "أنثى",
						Address = t.Address,
                        JoinDateFormated = t.JoinDate.Date.ToString("dd/MM/yyyy"),
						SportName = t.Sport.Name,
						PhoneNumber = t.PhoneNumber,
						TrainerName = t.Trainer.Name,
					}).ToListAsync();
				return data;
			}
			return new List<TraineeReportModel>();
		}
		catch (Exception ex)
		{
			_loggerService.AddExceptionError(ex, null);
			return null;
		}
	}

}