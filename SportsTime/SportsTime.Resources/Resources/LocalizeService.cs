using Microsoft.Extensions.Localization;
using System.Reflection;

namespace SportsTime.Resources.Resources;

public class LocalizeService
{
	private readonly IStringLocalizer _localizer;

	public LocalizeService()
	{
	}

	public LocalizeService(IStringLocalizerFactory factory)
	{
		var type = typeof(Resource);
		var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
		_localizer = factory.Create("CultureResource", assemblyName.Name);
	}

	public string GetLocalized(string key)
	{
		if (_localizer == null) return key;
		return _localizer[key].Value;
	}
}
