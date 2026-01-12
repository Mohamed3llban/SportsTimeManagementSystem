using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Resources.Resources;
using SportsTime.Services.Implementation.Sports;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Sports;

[Authorize]
public class ChampionshipsController : Controller
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly IChampionshipService _championshipService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ChampionshipsController
        (IChampionshipService championshipService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _championshipService = championshipService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(RevenuesPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Championships";
        var Revenues = await _championshipService.GetAll();
        return View(Revenues);
    }

    //[Authorize(RevenuesPermission.Create)]
    public async Task<IActionResult> Create()
    {
        TempData["JS"] = "Championships";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        var model = new ChampionshipModel { Trainees = await _championshipService.GetAllTraineesForMultiSelect() };
        
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Create)]
    public async Task<IActionResult> Create(ChampionshipModel model)
    {
        TempData["JS"] = "Championships";

        if (ModelState.IsValid)
        {
            var saved = await _championshipService.Create(model);
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

    //[Authorize(RevenuesPermission.Edit)]
    public async Task<IActionResult> Edit(int Id)
    {
        //ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        TempData["JS"] = "Championships";
        var model = await _championshipService.GetById(Id);
        model.Trainees = await _championshipService.GetAllTraineesForMultiSelect();
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Edit)]
    public async Task<IActionResult> Edit(ChampionshipModel model)
    {
        TempData["JS"] = "Championships";
        if (ModelState.IsValid)
        {
            var saved = await _championshipService.Edit(model);
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

    //[Authorize(RevenuesPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _championshipService.Delete(id);
        return deleted;
    }
    
}
