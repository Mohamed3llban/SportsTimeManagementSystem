using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;
using SportsTime.Resources.Resources;
using System.Security.Claims;
namespace SportsTime.Web.Controllers
{
	public class BaseController : Controller
	{
		public LocalizeService _localizer => new LocalizeService();

		public string currentLanguage => Request.HttpContext.Features.Get<IRequestCultureFeature>().RequestCulture.Culture.Name;

		public JsonResult JsonSerialize(object data)
		{
			return Json(data, new JsonSerializerSettings() { Formatting = Formatting.Indented });
		}

		public string JsonSerializeAsString(object data)
		{
			return JsonConvert.SerializeObject(data, new JsonSerializerSettings() { Formatting = Formatting.Indented });
		}

		public T JsonDeserialize<T>(string data) where T : class, new()
		{
			var Result = new T();
			try
			{
				return JsonConvert.DeserializeObject<T>(data);

			}
			catch (Exception ex)
			{
				return Result;
			}
		}

		public string ModelStateAsJson(ModelStateDictionary modelStateDictionary)
		{
			var data = modelStateDictionary.Keys.Where(q => ModelState[q].Errors.Any()).Select(k =>
				new { key = k, Errors = ModelState[k].Errors.ToList() }
			).ToList();
			return JsonSerializeAsString(data);
		}

		public bool DataIsValid(object data)
		{
			var context = new System.ComponentModel.DataAnnotations.ValidationContext(data, serviceProvider: null, items: null);
			var results = new List<System.ComponentModel.DataAnnotations.ValidationResult>();
			var ObjIsValid = System.ComponentModel.DataAnnotations.Validator.TryValidateObject(data, context, results);
			return ObjIsValid;
		}
		public string CurrentUserId
		{
			get
			{
				return User.FindFirst(ClaimTypes.NameIdentifier).Value;
			}
		}

	}

}
