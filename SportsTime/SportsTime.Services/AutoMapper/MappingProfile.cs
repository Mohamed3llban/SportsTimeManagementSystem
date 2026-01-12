using AutoMapper;
using SportsTime.Data.Entities.Finance;
using SportsTime.Data.Entities.Sports;
using SportsTime.Data.Entities.Training;
using SportsTime.Data.Entities.Users;
using SportsTime.Models.DTOs.Finance;
using SportsTime.Models.DTOs.Sports;
using SportsTime.Models.DTOs.Training;
using SportsTime.Models.DTOs.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.AutoMapper
{
	public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			CreateMap<Trainee, TraineeModel>().ReverseMap();
			CreateMap<Trainer, TrainerModel>().ReverseMap();
			CreateMap<Sport, SportModel>().ReverseMap();
			CreateMap<Subscribtion, SubscribtionModel>().ReverseMap();
			CreateMap<Payroll, PayrollModel>().ReverseMap();
			CreateMap<Revenue, RevenueModel>().ReverseMap();
			CreateMap<Expense, ExpenseModel>().ReverseMap();
			CreateMap<Client, ClientModel>().ReverseMap();
			CreateMap<Employee, EmployeeModel>().ReverseMap();
			CreateMap<Championship, ChampionshipModel>().ReverseMap();
		}




		//CreateMap<UserBranch, UserBranchModel>();
		//CreateMap<AccountTax, AccountTaxModel>()
		//              .ForMember(dest => dest.AmmountTypeName, opts => opts.MapFrom(src => src.AmmountType == 1 ? "Percentage Fee" : "Fixed Fee"))
		//              .ForMember(dest => dest.AmmountTypeArName, opts => opts.MapFrom(src => src.AmmountType == 1 ? "نسبة مئوية " : "نسبة ثابتة"));

		//CreateMap<CompanyBranch, CompanyBranchModel>()
		//              .ForMember(model => model.ImageBase64, opt => opt.MapFrom(entity => Convert.ToBase64String(entity.Img))).ReverseMap();

		//CreateMap<Journal, JournalViewModel>()
		//               .ForMember(dest => dest.BranchName, opt => opt.MapFrom(src => GetCurrentLanguage() == "ar-JO" ? src.Branch.BranchArabicName : src.Branch.BranchName))
		//               .ForMember(dest => dest.VoucherTypeName, opt => opt.MapFrom(src => GetCurrentLanguage() == "ar-JO" ? src.VoucherTY.TypeArName : src.VoucherTY.TypeEnName))
		//               .ForMember(dest => dest.FiscalName, opt => opt.MapFrom(src => GetCurrentLanguage() == "ar-JO" ? src.FiscalYear.ArabicName : src.FiscalYear.EnglishName));

		//CreateMap<Role, RoleModel>()
		//              .ForMember(dest => dest.NumberofUser, opt => opt.MapFrom(src => src.userRoles.Count()));

		//CreateMap<UserAuthentication, UserAuthenticationModel>()
		//          .ForMember(dest => dest.ScreenName, opt => opt.MapFrom(src => src.ScreenActions.Screen.ArabicName))
		//          .ForMember(dest => dest.ScreenId, opt => opt.MapFrom(src => src.ScreenActions.Screen.Id))
		//          .ForMember(dest => dest.ActionId, opt => opt.MapFrom(src => src.ScreenActions.ActionId))
		//          .ForMember(dest => dest.ActionName, opt => opt.MapFrom(src => src.ScreenActions.Action.ArabicName));


		//      CreateMap<VATGroupsHDR, VATGroupsHDRModel>()
		//              .ForMember(dest => dest.VatGroupsDTLs, opt => opt.MapFrom(src => src.VatGroupsDTL)).ReverseMap();
	}
}
