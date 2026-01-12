using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SportsTime.Data.Entities.Users;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Users;
using SportsTime.Repositories;
using SportsTime.Repositories.Inteface.IRepositories;
using SportsTime.Services.Inteface;
using SportsTime.Services.Inteface.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Implementation.Users;

public class ClientService : IClientService
{
    private readonly IMapper _mapper;
    private readonly ApplicationDbContext _context;
    private readonly ILoggerService _loggerService;
    private readonly IBaseRepository<Client> _Clients;

    public ClientService(IBaseRepository<Client> Clients, IMapper mapper, ILoggerService loggerService,
        ApplicationDbContext context)
    {
        _mapper = mapper;
        _context = context;
        _loggerService = loggerService;
        _Clients = Clients;
    }

    public async Task<bool> Create(ClientModel model)
    {
        try
        {
            var entity = _mapper.Map<Client>(model);
            await _Clients.AddAsync(entity);
            var result = await _Clients.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }
    }

    public async Task<bool> Edit(ClientModel model)
    {
        try
        {
            var entity = await _Clients.FirstOrDefaultAsync(x => x.Id == model.Id);
            _context.Entry<Client>(entity).State = EntityState.Detached;
            entity = _mapper.Map<Client>(model);
            _context.Entry(entity).State = EntityState.Modified;
            var result = await _Clients.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { model });
            return false;
        }

    }

    public async Task<ClientModel> GetById(int id)
    {
        try
        {
            var _data = await _context.Clients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            var model = _mapper.Map<ClientModel>(_data);
            return model;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, new { id });
            return null;
        }
    }

    public async Task<List<ClientModel>> GetAll()
    {
        try
        {
            var data = await _context.Clients.Where(x => x.IsDeleted == false)
                .Select(t => new ClientModel
                {
                    Id = t.Id,
                    Name = t.Name,
                    IsCurrentClient = t.IsCurrentClient,
                    Email = t.Email ?? "",
                    Address = t.Address,
                    PhoneNumber = t.PhoneNumber,
                    JoinDate = t.JoinDate,
                    WebsiteUrl = t.WebsiteUrl,
                }).ToListAsync();

            var result = data.Count > 0 ? _mapper.Map<List<ClientModel>>(data) : new List<ClientModel>();
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
            var _data = await _Clients.FirstOrDefaultAsync(x => x.Id == id);
            _data.IsDeleted = true;
            //_data.DelReason = DelReason;
            var result = await _Clients.SaveChangesAsync();
            return result > 0;
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return false;
        }
    }

    public async Task<List<ClientReportModel>> ReadClientsGrid(ClientReportParameterModel parameter)
    {
        try
        {
            if (parameter != null)
            {
                var data = await _context.Clients.Where(x => x.IsDeleted == false)
                    .Where(x =>(x.Name.Contains(parameter.Name) || String.IsNullOrWhiteSpace(parameter.Name)))
                    .Select(t => new ClientReportModel
                    {
                        Id = t.Id,
                        Name = t.Name,
                        PhoneNumber = t.PhoneNumber,
                        WebsiteUrl = t.WebsiteUrl,
                        StatusName = t.IsCurrentClient ? "عميل حالي" : "عميل محتمل",
                        JoinDateFormated = t.JoinDate.Date.ToString("dd/MM/yyyy"),
                    }).ToListAsync();
                return data;
            }
            return new List<ClientReportModel>();
        }
        catch (Exception ex)
        {
            _loggerService.AddExceptionError(ex, null);
            return null;
        }
    }

}