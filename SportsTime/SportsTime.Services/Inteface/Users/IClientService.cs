using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Users;

public interface IClientService
{
    Task<bool> Create(ClientModel model);
    Task<bool> Edit(ClientModel model);
    Task<ClientModel> GetById(int id);
    Task<List<ClientModel>> GetAll();
    Task<bool> Delete(int id);
    Task<List<ClientReportModel>> ReadClientsGrid(ClientReportParameterModel parameter);
}