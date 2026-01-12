using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
//using SportsTime.Data.Enums;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Finance;
using SportsTime.Web.Constants;
//using SportsTime.Web.Constants.Permissions;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Finance;

[Authorize]
//[HasPermission(Permission.AccessMember)]
public class ExpensesController : BaseController
{
    private readonly LocalizeService _localizerService;
    private readonly SessionManager _sessionManager;
    private readonly IExpenseService _ExpenseService;
    private readonly IWebHostEnvironment _webHostEnvironment;
    public ExpensesController
        (IExpenseService ExpenseService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
		_localizerService = localizeService;
        _ExpenseService = ExpenseService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[HasPermission(Permission.ReadMember)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Expenses";
        var Expenses = await _ExpenseService.GetAll();
        return View(Expenses);
    }

    //[Authorize(ExpensesPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Expenses";
        ViewBag.CurrentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(ExpensesPermission.Create)]
    public async Task<IActionResult> Create(ExpenseModel model)
    {
        TempData["JS"] = "Expenses";

        if (ModelState.IsValid)
        {
            var saved = await _ExpenseService.Create(model);
            if (saved)
            {
                //TempData[Messages.SuccessMessage] = _localizerService.GetLocalized("SavedSuccess");
                TempData[Messages.SuccessMessage] = "تمت عملية الحفظ بنجاح";

            }
            else//TempData[Messages.ErrorMessage] = _localizerService.GetLocalized("SavedFailed");
                TempData[Messages.ErrorMessage] = "فشلت عملية الحفظ";

            return RedirectToAction(nameof(Index));
        }
        var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
        return View(model);
    }

    //[Authorize(ExpensesPermission.Edit)]
    public async Task<IActionResult> Edit(int Id)
    {
        //ViewBag.CurrentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        TempData["JS"] = "Expenses";
        var model = await _ExpenseService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(ExpensesPermission.Edit)]
    public async Task<IActionResult> Edit(ExpenseModel model)
    {
        TempData["JS"] = "Expenses";
        if (ModelState.IsValid)
        {
            var saved = await _ExpenseService.Edit(model);
            if (saved)
            {
                //TempData[Messages.SuccessMessage] = _localizerService.GetLocalized("SavedSuccess");
                TempData[Messages.SuccessMessage] = "تمت عملية الحفظ بنجاح";
            }
            //TempData[Messages.ErrorMessage] = _localizerService.GetLocalized("SavedFailed");
            else
                TempData[Messages.ErrorMessage] = "فشلت عملية الحفظ";
            return RedirectToAction(nameof(Index));
        }
        var errors = ModelState.Select(x => x.Value.Errors).Where(y => y.Count > 0).ToList();
        return View(model);
    }

    //[Authorize(ExpensesPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _ExpenseService.Delete(id);
        return deleted;
    }

}
