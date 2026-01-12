using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs.Users;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Users;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Users;

[Authorize]
public class EmployeesController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly IEmployeeService _employeeService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public EmployeesController
        (IEmployeeService employeeService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _employeeService = employeeService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(RevenuesPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Employees";
        var Revenues = await _employeeService.GetAll();
        return View(Revenues);
    }

    //[Authorize(RevenuesPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Employees";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Create)]
    public async Task<IActionResult> Create(EmployeeModel model)
    {
        TempData["JS"] = "Employees";

        if (ModelState.IsValid)
        {
            if (await CheckIfCodeExists(model.Code))
            {
                TempData[Messages.WarningMessage] = "! هذا الكود مستخدم بالفعل";
                return View(model);
            }
            if (model.ImageFile != null)
                model.ImagePath = "assets/media/employees/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

            var saved = (await _employeeService.Create(model));
            if (saved)
            {
                // ----- Image ------ //
                if (model.ImageFile != null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, model.ImagePath);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    //TempData[Messages.SuccessMessage] = localizer.GetLocalized("SavedSuccess");
                    TempData[Messages.SuccessMessage] = "تمت عملية الحفظ بنجاح";
                }
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
        TempData["JS"] = "Employees";
        var model = await _employeeService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Edit)]
    public async Task<IActionResult> Edit(EmployeeModel model)
    {
        TempData["JS"] = "Employees";
        if (ModelState.IsValid)
        {
            if (model.ImageFile != null)
                model.ImagePath = "assets/media/employees/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

            var saved = await _employeeService.Edit(model);
            if (saved)
            {
                // ----- Image ------ //
                if (model.ImageFile != null)
                {
                    var path = Path.Combine(_webHostEnvironment.WebRootPath, model.ImagePath);
                    if (System.IO.File.Exists(path))
                        System.IO.File.Delete(path);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                }
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

    //[Authorize(SubscribtionsPermission.Edit)]
    public async Task<IActionResult> EmployeePayroll(int employeeId)
    {
        TempData["JS"] = "Employees";
        var model = await _employeeService.GetEmployeePayroll(employeeId);
        return View(model);
    }

    //[Authorize(RevenuesPermission.Delete)]
    public async Task<bool> Delete(int id)
    {
        var deleted = await _employeeService.Delete(id);
        return deleted;
    }

    //[Authorize(TraineePermission.Create)]
    [HttpGet]
    public async Task<bool> CheckIfCodeExists(int code)
    {
        var IsExists = await _employeeService.CheckIfCodeExists(code);
        return IsExists;
    }

    [HttpGet]
    public async Task<decimal> GetEmployeeSalaryAmount(int employeeId)
    {
        var result = await _employeeService.GetEmployeeSalaryAmount(employeeId);
        return result;
    }

}
