using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SportsTime.Models.DTOs.Reports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Resources.Resources;
using SportsTime.Services.Inteface.Training;
using SportsTime.Web.Constants;
using SportsTime.Web.Managers;

namespace SportsTime.Web.Controllers.Training;

[Authorize]
public class TrainerController : BaseController
{
	private readonly LocalizeService localizer;
	private readonly SessionManager _sessionManager;
	private readonly ITrainerService _trainerService;
	private readonly IWebHostEnvironment _webHostEnvironment;

	public TrainerController
		(ITrainerService trainerService, LocalizeService localizeService, SessionManager sessionManager, IWebHostEnvironment webHostEnvironment)
	{
		localizer = localizeService;
		_trainerService = trainerService;
		_sessionManager = sessionManager;
		_webHostEnvironment = webHostEnvironment;
	}

	//[Authorize(TrainerPermission.View)]
	public async Task<IActionResult> Index()
	{
		TempData["JS"] = "Trainer";
		return View();
	}

	//[Authorize(TrainerPermission.Create)]
	public IActionResult Create()
	{
		TempData["JS"] = "Trainer";
		ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
		return View();
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	//[Authorize(TrainerPermission.Create)]
	public async Task<IActionResult> Create(TrainerModel model)
	{
		TempData["JS"] = "Trainer";

		if (ModelState.IsValid)
		{
			if (await CheckIfCodeExists(model.Code))
			{
				TempData[Messages.WarningMessage] = "! هذا الكود مستخدم بالفعل";
				return View(model);
			}
			if (model.ImageFile != null)
				model.ImagePath = "assets/media/trainers/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

			var saved = await _trainerService.Create(model);
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

	//[Authorize(TrainerPermission.Edit)]
	public async Task<IActionResult> Edit(int Id)
	{
		//ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
		TempData["JS"] = "Trainer";
		var model = await _trainerService.GetById(Id);
		return View(model);
	}

	[HttpPost]
	[ValidateAntiForgeryToken]
	//[Authorize(TrainerPermission.Edit)]
	public async Task<IActionResult> Edit(TrainerModel model)
	{
		TempData["JS"] = "Trainer";
		if (ModelState.IsValid)
		{
			if (model.ImageFile != null)
				model.ImagePath = "assets/media/Trainers/" + model.Code + Path.GetExtension(model.ImageFile.FileName);

			var saved = await _trainerService.Edit(model);
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

	[HttpGet]
	public async Task<decimal> GetTrainerSalaryAmount(int trainerId)
	{
		var result = await _trainerService.GetTrainerSalaryAmount(trainerId);
		return result;
	}

	//[Authorize(SubscribtionsPermission.Edit)]
	public async Task<IActionResult> TrainerPayroll(int trainerId)
	{
		TempData["JS"] = "Trainer";
		var model = await _trainerService.GetTrainerPayroll(trainerId);
		return View(model);
	}

	//[Authorize(TrainerPermission.Delete)]
	public async Task<bool> Delete(int id)
	{
		var deleted = await _trainerService.Delete(id);
		return deleted;
	}

	//[Authorize(TraineePermission.Create)]
	[HttpGet]
	public async Task<bool> CheckIfCodeExists(int code)
	{
		var IsExists = await _trainerService.CheckIfCodeExists(code);
		return IsExists;
	}

	//[Authorize(TraineePermission.View)]
	public IActionResult AdvancedSearch()
	{
		return View();
	}

	[HttpGet]
	public async Task<List<TrainerReportModel>> ReadTrainersGrid(TrainerReportParameterModel parameter)
	{
		var trainers = await _trainerService.ReadTrainersGrid(parameter);
		return trainers;
	}

	//[Authorize(TrainerPermission.Print)]
	//public IActionResult Print(int id)
	//{
	//	ViewBag.currentLanguage = Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;
	//	//HandlingITLAter
	//	return View(id);
	//}

}