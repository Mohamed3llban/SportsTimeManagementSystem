using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Sports;

[Authorize]
public class SubscribtionsController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly ISubscribtionsService _subscribtionsService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public SubscribtionsController
        (ISubscribtionsService subscribtionsService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _subscribtionsService = subscribtionsService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(SubscribtionsPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Subscribtions";
        var Subscribtions = await _subscribtionsService.GetAll();
        return View(Subscribtions);
    }

    //[Authorize(SubscribtionsPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Subscribtions";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(SubscribtionsPermission.Create)]
    public async Task<IActionResult> Create(SubscribtionModel model)
    {
        TempData["JS"] = "Subscribtions";

        if (ModelState.IsValid)
        {
            var saved = await _subscribtionsService.Create(model);
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

    //[Authorize(SubscribtionsPermission.Edit)]
    public async Task<IActionResult> Edit(int Id)
    {
        //ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        TempData["JS"] = "Subscribtions";
        var model = await _subscribtionsService.GetById(Id);
        return View(model);
    }
    
    //[Authorize(SubscribtionsPermission.Edit)]
    public async Task<IActionResult> TraineeSubsList(int traineeId)
    {
        TempData["JS"] = "Subscribtions";
        var model = await _subscribtionsService.GetTraineeSubsList(traineeId);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(SubscribtionsPermission.Edit)]
    public async Task<IActionResult> Edit(SubscribtionModel model)
    {
        TempData["JS"] = "Subscribtions";
        if (ModelState.IsValid)
        {
            var saved = await _subscribtionsService.Edit(model);
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

    //[Authorize(SubscribtionsPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _subscribtionsService.Delete(id);
        return deleted;
    }

    //[Authorize(SubscribtionsPermission.Print)]
    //public IActionResult Print(int id)
    //{
    //	ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
    //	//HandlingITLAter
    //	return View(id);
    //}
}
