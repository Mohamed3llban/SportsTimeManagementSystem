using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Resources.Resources;
using SportsTime.Services.Implementation.Training;
using SportsTime.Services.Inteface.Training;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;
using System.IO;

namespace SportsTime.Web.Controllers.Training;

[Authorize]
public class TraineesController : BaseController
{
	private readonly LocalizeService localizer;
	private readonly SessionManager _sessionManager;
	private readonly ITraineeService _traineeService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public TraineesController
		(ITraineeService traineeService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
	{
		localizer = localizeService;
		_traineeService = traineeService;
		_sessionManager = sessionManager;
		_webHostEnvironment = webHostEnvironment;
	}

	//[Authorize(TraineePermission.View)]
	public IActionResult Index()
	{
		TempData["JS"] = "Trainee";
		return View();
	}

	//[Authorize(TraineePermission.Create)]
	public IActionResult Create()
	{
		TempData["JS"] = "Trainee";
		ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	//[Authorize(TraineePermission.Create)]
	public async Task<IActionResult> Create(TraineeModel model)
	{
		TempData["JS"] = "Trainee";
		if (ModelState.IsValid)
		{
			if (await CheckIfCodeExists(model.Code))
			{
				TempData[Messages.WarningMessage] = "! هذا الكود مستخدم بالفعل";
				return View(model);
			}
			if (model.ImageFile != null)
				model.ImagePath = "assets/media/trainees/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

			var saved = await _traineeService.Create(model);
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

	//[Authorize(TraineePermission.Edit)]
	public async Task<IActionResult> Edit(int Id)
	{
		TempData["JS"] = "Trainee";
		//ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
		var model = await _traineeService.GetById(Id);
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	//[Authorize(TraineePermission.Edit)]
	public async Task<IActionResult> Edit(TraineeModel model)
	{
		TempData["JS"] = "Trainee";
		if (ModelState.IsValid)
		{
			if (model.ImageFile != null)
				model.ImagePath = "assets/media/trainees/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

			var saved = await _traineeService.Edit(model);
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

	//[Authorize(TraineePermission.Delete)]
	public async Task<bool> Delete(int id)
	{
		var deleted = await _traineeService.Delete(id);
		return deleted;
	}

	//[Authorize(TraineePermission.Create)]
	[HttpGet]
	public async Task<bool> CheckIfCodeExists(int code)
	{
		var IsExists = await _traineeService.CheckIfCodeExists(code);
		return IsExists;
	}

	[HttpGet]
	public async Task<List<TraineeReportModel>> ReadTraineesGrid(TraineeReportParameterModel parameter)
	{
		var trainees = await _traineeService.ReadTraineesGrid(parameter);
		return trainees;
	}

	//[Authorize(TraineePermission.Print)]
	//public IActionResult Print(int id)
	//{
	//	ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
	//	//HandlingITLAter
	//	return View(id);
	//}

}