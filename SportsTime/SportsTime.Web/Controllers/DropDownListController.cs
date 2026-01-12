using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsTime.Models.DTOs;
using SportsTime.Resources.Resources;
using SportsTime.Services.Implementation.Training;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Services.Inteface.Training;
using SportsTime.Services.Inteface.Users;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers;

[Authorize]
public class DropDownListController : BaseController
{
    private readonly LocalizeService _localizer;
    private readonly SessionManager _sessionManager;
    private readonly ISportsService _sportsService;
    private readonly ITraineeService _traineeService;
    private readonly ITrainerService _trainerService;
    private readonly IEmployeeService _employeeService;
    public DropDownListController(LocalizeService localizeService, SessionManager sessionManager,
        ISportsService sportsService, ITrainerService trainerService, ITraineeService traineeService, IEmployeeService employeeService)
    {
        _localizer = localizeService;
        _sessionManager = sessionManager;
        _sportsService = sportsService;
        _traineeService= traineeService;
        _trainerService = trainerService;
        _employeeService = employeeService;
    }

    [HttpGet]
    public async Task<List<DropDownModel>> READ_TrainersBySportId(int sportId)
    {
        var trainers = (await _trainerService.GetAllBySportId(sportId));
        if (trainers != null)
        {
            var result = trainers.Select(d => new DropDownModel
             {
                 ValueField = d != null ? d.Id : default,
                 TextField = d != null ? d.Name : default,
             }).ToList();
            return result;
        }
        return new List<DropDownModel>();
    }

    [HttpGet]
    public async Task<List<DropDownModel>> READ_Sports()
    {
        var sports = (await _sportsService.GetAll());
        if (sports != null)
        {
            var result = sports.Select(d => new DropDownModel
            {
                ValueField = d != null ? d.Id : default,
                TextField = d != null ? d.Name : default,
            }).ToList();
            return result;
        }
        return new List<DropDownModel>();
    }

    [HttpGet]
    public async Task<List<DropDownModel>> READ_Trainees()
    {
        var sports = (await _traineeService.GetAll());
        if (sports != null)
        {
            var result = sports.Select(d => new DropDownModel
            {
                ValueField = d != null ? d.Id : default,
                TextField = d != null ? d.Name : default,
            }).ToList();
            return result;
        }
        return new List<DropDownModel>();
    }
    
    [HttpGet]
    public async Task<List<DropDownModel>> ReadEmployees()
    {
        var employees = (await _employeeService.GetAll());
        if (employees != null)
        {
            var result = employees.Select(d => new DropDownModel
            {
                ValueField = d != null ? d.Id : default,
                TextField = d != null ? d.Name : default,
            }).ToList();
            return result;
        }
        return new List<DropDownModel>();
    }

    [HttpGet]
    public async Task<List<DropDownModel>> READ_Trainers()
    {
        var sports = (await _trainerService.GetAll());
        if (sports != null)
        {
            var result = sports.Select(d => new DropDownModel
            {
                ValueField = d != null ? d.Id : default,
                TextField = d != null ? d.Name : default,
            }).ToList();
            return result;
        }
        return new List<DropDownModel>();
    }

}
