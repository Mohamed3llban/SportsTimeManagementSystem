using SportsTime.Data.Entities;
using SportsTime.Data.Entities.Training;
using SportsTime.Data.Entities.Sports;
using SportsTime.Data.Entities.Finance;
using SportsTime.Repositories.Implementation.Repositories;
//using SportsTime.Repositories.Implementation.Repositories.Account;
//using SportsTime.Repositories.Implementation.Repositories.Warehouses;
//using SportsTime.Repositories.Interface.IRepositories;
//using SportsTime.Repositories.Interface.IRepositories.Account;
//using SportsTime.Repositories.Interface.IRepositories.Warehouses;
//using SportsTime.Service.Implementation.Lkp;
//using SportsTime.Service.Interface;
//using SportsTime.Service.Interface.ILkp;
using Microsoft.Extensions.DependencyInjection;
using SportsTime.Repositories.Inteface.IRepositories;

namespace SportsTime.Web.Extensions
{
	public static class RepositoryServiceCollectionExtension
	{
		public static void AddRepositoryLayer(this IServiceCollection services)
		{
			services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

			//#region Asset

			//services.AddTransient<IAsyncGeneralRepo, AsyncGeneralRepo>();
			//services.AddTransient<IComplexQuery, ComplextTypeRepository>();
			//services.AddTransient<IRepository<EntryVoucherHdr>, Repository<EntryVoucherHdr>>();
			//services.AddTransient<IRepository<EntryVoucherDtl>, Repository<EntryVoucherDtl>>();
			//services.AddTransient<IRepository<AssetsExpensesType>, Repository<AssetsExpensesType>>();
			//services.AddTransient<IRepository<FixedAssetsType>, Repository<FixedAssetsType>>();
			//services.AddTransient<IRepository<DepartmentSection>, Repository<DepartmentSection>>();
			//services.AddTransient<IRepository<AssetsbyDeprecation>, Repository<AssetsbyDeprecation>>();
			//services.AddTransient<IRepository<StocktakingCloser>, Repository<StocktakingCloser>>();
			//services.AddTransient<IRepository<AssetsDefinition>, Repository<AssetsDefinition>>();
			//services.AddTransient<IRepository<Insurance>, Repository<Insurance>>();
			//services.AddTransient<IRepository<Maintenance>, Repository<Maintenance>>();
			//services.AddTransient<IRepository<Warranty>, Repository<Warranty>>();
			//services.AddTransient<IRepository<FAsset_Update>, Repository<FAsset_Update>>();
			//services.AddTransient<IRepository<FAsset_Disposal>, Repository<FAsset_Disposal>>();

			//services.AddTransient<IRepository<FAsset_DisposeHdr>, Repository<FAsset_DisposeHdr>>();
			//services.AddTransient<IRepository<FAsset_DisposeDtl>, Repository<FAsset_DisposeDtl>>();

			//services.AddTransient<IRepository<AssetSecTransferDTL>, Repository<AssetSecTransferDTL>>();
			//services.AddTransient<IRepository<AssetSecTransferHDR>, Repository<AssetSecTransferHDR>>();

			//services.AddTransient<IRepository<Dep_AssetTransferDtl>, Repository<Dep_AssetTransferDtl>>();
			//services.AddTransient<IRepository<Dep_AssetTransferHdr>, Repository<Dep_AssetTransferHdr>>();

			////services.AddTransient<IUnitOfWorkFAssets, UnitOfWorkFAssets>();
			//services.AddTransient<IRepository<AssetsEntryVoucherType>, Repository<AssetsEntryVoucherType>>();
			//services.AddTransient<IRepository<FixedAssetExp>, Repository<FixedAssetExp>>();
			//services.AddTransient<IRepository<StockTakingHdr>, Repository<StockTakingHdr>>();
			//services.AddTransient<IRepository<StockTakingDtl>, Repository<StockTakingDtl>>();

			//services.AddTransient<IRepository<Dep_Cal>, Repository<Dep_Cal>>();
			//services.AddTransient<IRepository<OtherAssetsEntryTrans>, Repository<OtherAssetsEntryTrans>>();
			//services.AddTransient<IRepository<OtherAssetsEntryDTL>, Repository<OtherAssetsEntryDTL>>();

			//services.AddTransient<IRepository<FAsset_DisposeHdr>, Repository<FAsset_DisposeHdr>>();
			//services.AddTransient<IRepository<FAsset_DisposeDtl>, Repository<FAsset_DisposeDtl>>();
			//services.AddTransient<IRepository<Item>, Repository<Item>>();
			//services.AddTransient<IRepository<ItemAccounts>, Repository<ItemAccounts>>();
			//services.AddTransient<IRepository<Item_Unit>, Repository<Item_Unit>>();
			//services.AddTransient<IRepository<StockTakingSuddenDtl>, Repository<StockTakingSuddenDtl>>();
			//services.AddTransient<IRepository<StockTakingSuddenHdr>, Repository<StockTakingSuddenHdr>>();
			//services.AddTransient<IRepository<CompetitionType>, Repository<CompetitionType>>();
			//services.AddTransient<IRepository<CompetitionTypeBranch>, Repository<CompetitionTypeBranch>>();
			//services.AddTransient<IRepository<CompanyBranch>, Repository<CompanyBranch>>();
			//services.AddTransient<IRepository<Role>, Repository<Role>>();
			//services.AddTransient<IRepository<UserDefinition>, Repository<UserDefinition>>();
			//services.AddTransient<IRepository<Fassets>, Repository<Fassets>>();
			//services.AddTransient<IRepository<WarehousesTransactionType>, Repository<WarehousesTransactionType>>();
			//services.AddTransient<IRepository<LinkCategoriesToAccounts>, Repository<LinkCategoriesToAccounts>>();
			//services.AddTransient<IRepository<SystemNews>, Repository<SystemNews>>();
			//services.AddTransient<IRepository<NewsRole>, Repository<NewsRole>>();
			//services.AddTransient<IRepository<NewsUsers>, Repository<NewsUsers>>();
			//services.AddTransient<IRepository<NewsBranches>, Repository<NewsBranches>>();

			//services.AddTransient<IBaseRepository<Activity>, BaseRepository<Activity>>();
			//services.AddTransient<IBaseRepository<ElectricityAndWaterConsumptionHdr>, BaseRepository<ElectricityAndWaterConsumptionHdr>>();
			//services.AddTransient<IBaseRepository<SupportBranchHDR>, BaseRepository<SupportBranchHDR>>();
			//services.AddTransient<IRepository<SupportBranchDT>, Repository<SupportBranchDT>>();
			//services.AddTransient<IBaseRepository<Organization>, BaseRepository<Organization>>();


			//#endregion Asset

			//#region Account

			//services.AddScoped(typeof(IAccountSetRepository), typeof(AccountSetRepository));

			//services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
			//services.AddTransient<IRepository<Journal>, Repository<Journal>>();

			//services.AddTransient<IRepository<BranchType>, Repository<BranchType>>();
			//services.AddTransient<IRepository<Companies>, Repository<Companies>>();
			//services.AddTransient<IBaseRepository<SaleRepresentativeCustomer>, BaseRepository<SaleRepresentativeCustomer>>();
			////services.AddTransient<IBaseRepository<PettyCashClosure>,BaseRepository<PettyCashClosure>>();
			////services.AddTransient<IRepository<PettyCashClosureTransaction>,Repository<PettyCashClosureTransaction>>();

			//#endregion Account

			//#region Purchases

			//services.AddTransient<IRepository<Fassets>, Repository<Fassets>>();
			//services.AddTransient<IBaseRepository<Supplier>, BaseRepository<Supplier>>();
			//services.AddTransient<IBaseRepository<CreditNote>, BaseRepository<CreditNote>>();
			//services.AddTransient<IBaseRepository<CompanyBranch>, BaseRepository<CompanyBranch>>();
			//services.AddTransient<IRepository<PurchaseReceiptDtl>, Repository<PurchaseReceiptDtl>>();
			//services.AddTransient<IBaseRepository<PurchaseReciptVoucherType>, BaseRepository<PurchaseReciptVoucherType>>();
			//#endregion Purchases

			//#region Warehouses
			//services.AddTransient<IIssuingVoucherRepo, IssuingVoucherRepo>();

			//#endregion
		}
	}
}