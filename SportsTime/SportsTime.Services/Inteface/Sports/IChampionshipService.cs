using SportsTime.Models.DTOs;
using SportsTime.Models.DTOs.Sports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface.Sports;

public interface IChampionshipService
{
    Task<bool> Create(ChampionshipModel model);
    Task<bool> Edit(ChampionshipModel model);
    Task<ChampionshipModel> GetById(int id);
    Task<List<ChampionshipModel>> GetAll();
    Task<List<DropDownModel>> GetAllTraineesForMultiSelect();
    Task<bool> Delete(int id);
}