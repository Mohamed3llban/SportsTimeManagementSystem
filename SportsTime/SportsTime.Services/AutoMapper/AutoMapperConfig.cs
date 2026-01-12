using AutoMapper;

namespace SportsTime.Services.AutoMapper;
public class AutoMapperConfig
{
	public static IMapper Initialize()
	{
		var config = new MapperConfiguration(cfg => {
			cfg.AddProfile<MappingProfile>();
		});
		return config.CreateMapper();
	}
}
//var mapper = AutoMapperConfig.Initialize();