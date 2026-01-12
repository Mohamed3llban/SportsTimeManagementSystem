using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Users;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Users;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Users;
[Authorize]
public class ClientsController : BaseController
{
    private readonly LocalizeService localizer;
    private readonly SessionManager _sessionManager;
    private readonly IClientService _clientService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ClientsController
        (IClientService clientService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
    {
        localizer = localizeService;
        _clientService = clientService;
        _sessionManager = sessionManager;
        _webHostEnvironment = webHostEnvironment;
    }

    //[Authorize(RevenuesPermission.View)]
    public async Task<IActionResult> Index()
    {
        TempData["JS"] = "Clients";
        return View();
    }

    //[Authorize(RevenuesPermission.Create)]
    public IActionResult Create()
    {
        TempData["JS"] = "Clients";
        ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Create)]
    public async Task<IActionResult> Create(ClientModel model)
    {
        TempData["JS"] = "Clients";

        if (ModelState.IsValid)
        {
            var saved = await _clientService.Create(model);
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
        TempData["JS"] = "Clients";
        var model = await _clientService.GetById(Id);
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    //[Authorize(RevenuesPermission.Edit)]
    public async Task<IActionResult> Edit(ClientModel model)
    {
        TempData["JS"] = "Clients";
        if (ModelState.IsValid)
        {
            var saved = await _clientService.Edit(model);
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
        var deleted = await _clientService.Delete(id);
        return deleted;
    }

    [HttpGet]
    public async Task<List<ClientReportModel>> ReadClientsGrid(ClientReportParameterModel parameter)
    {
        var trainees = (await _clientService.ReadClientsGrid(parameter));
        return trainees;
    }
}
