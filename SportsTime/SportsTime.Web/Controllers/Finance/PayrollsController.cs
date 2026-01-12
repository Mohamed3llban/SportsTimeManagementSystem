using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Finance;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Finance;

[Authorize]
public class PayrollsController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly IPayrollService _PayrollService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public PayrollsController
        (IPayrollService PayrollService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _PayrollService = PayrollService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(PayrollsPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Payroll";
        var Payrolls = await _PayrollService.GetAll();
        return View(Payrolls);
    }

    //[Authorize(PayrollsPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Payroll";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(PayrollsPermission.Create)]
    public async Task<IActionResult> Create(PayrollModel model)
    {
        TempData["JS"] = "Payroll";

        if (ModelState.IsValid)
        {
            var saved = await _PayrollService.Create(model);
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

    //[Authorize(PayrollsPermission.Edit)]
    public async Task<IActionResult> Edit(int Id)
    {
        //ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        TempData["JS"] = "Payroll";
        var model = await _PayrollService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(PayrollsPermission.Edit)]
    public async Task<IActionResult> Edit(PayrollModel model)
    {
        TempData["JS"] = "Payroll";
        if (ModelState.IsValid)
        {
            var saved = await _PayrollService.Edit(model);
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

    //[Authorize(PayrollsPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _PayrollService.Delete(id);
        return deleted;
    }

    //[Authorize(PayrollsPermission.Print)]
    //public IActionResult Print(int id)
    //{
    //	ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
    //	//HandlingITLAter
    //	return View(id);
    //}
}