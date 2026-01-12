using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Finance;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Finance;

[Authorize]
public class RevenuesController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly IRevenueService _RevenueService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public RevenuesController
        (IRevenueService RevenueService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _RevenueService = RevenueService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(RevenuesPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Revenues";
        var Revenues = await _RevenueService.GetAll();
        return View(Revenues);
    }

    //[Authorize(RevenuesPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Revenues";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Create)]
    public async Task<IActionResult> Create(RevenueModel model)
    {
        TempData["JS"] = "Revenues";

        if (ModelState.IsValid)
        {
            var saved = await _RevenueService.Create(model);
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
        TempData["JS"] = "Revenues";
        var model = await _RevenueService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Edit)]
    public async Task<IActionResult> Edit(RevenueModel model)
    {
        TempData["JS"] = "Revenues";
        if (ModelState.IsValid)
        {
            var saved = await _RevenueService.Edit(model);
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
        var deleted = await _RevenueService.Delete(id);
        return deleted;
    }

}
