using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Services.Inteface.Training;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Sports;

[Authorize]
public class SportsController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly ISportsService _sportService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public SportsController
        (ISportsService sportService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _sportService = sportService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(SportPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Sport";
        return View();
    }

    //[Authorize(SportPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Sport";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(SportPermission.Create)]
    public async Task<IActionResult> Create(SportModel model)
    {
        TempData["JS"] = "Sport";

        if (ModelState.IsValid)
        {
            var saved = await _sportService.Create(model);
            if (saved)
            {
                //TempData[Messages.SuccessMessage] = localizer.GetLocalized("SavedSuccess");
                TempData[Messages.SuccessMessage] = "تمت عملية الحفظ بنجاح";

            }
            else//TempData[Messages.ErrorMessage] = localizer.GetLocalized("SavedFailed");
                TempData[Messages.ErrorMessage] = "فشلت عملية الحفظ";

            return RedirectToAction(nameof(Index));
        }
        var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
        return View(model);
    }

    //[Authorize(SportPermission.Edit)]
    public async Task<IActionResult> Edit(int Id)
    {
        //ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        TempData["JS"] = "Sport";
        var model = await _sportService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(SportPermission.Edit)]
    public async Task<IActionResult> Edit(SportModel model)
    {
        TempData["JS"] = "Sport";
        if (ModelState.IsValid)
        {
            var saved = await _sportService.Edit(model);
            if (saved)
            {
                //TempData[Messages.SuccessMessage] = localizer.GetLocalized("SavedSuccess");
                TempData[Messages.SuccessMessage] = "تمت عملية الحفظ بنجاح";
            }
            //TempData[Messages.ErrorMessage] = localizer.GetLocalized("SavedFailed");
            else
                TempData[Messages.ErrorMessage] = "فشلت عملية الحفظ";
            return RedirectToAction(nameof(Index));
        }
        var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
        return View(model);
    }

    //[Authorize(SportPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _sportService.Delete(id);
        return deleted;
    }

    [HttpGet]
    public async Task<decimal> GetSportSubscribtionCost(int sportId)
    {
        var result = await _sportService.GetSportSubscribtionCost(sportId);
        return result;
    }

    //[Authorize(SportPermission.Print)]
    //public IActionResult Print(int id)
    //{
    //	ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
    //	//HandlingITLAter
    //	return View(id);
    //}

    [HttpGet]
    public async Task<List<SportReportModel>> ReadSportsGrid(SportReportParameterModel parameter)
    {
        var trainees = (await _sportService.ReadSportsGrid(parameter));
        return trainees;
    }
}
