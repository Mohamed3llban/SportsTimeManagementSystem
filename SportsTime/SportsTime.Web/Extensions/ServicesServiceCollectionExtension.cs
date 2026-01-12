
using SportsTime.Web.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using SportsTime.Services.Inteface.Training;
using SportsTime.Services.Implementation.Training;
using SportsTime.Services.Inteface;
using SportsTime.Services.Implementation;
using SportsTime.Services.Inteface.Sports;
using SportsTime.Services.Implementation.Sports;
using SportsTime.Services.Inteface.Finance;
using SportsTime.Services.Implementation.Finance;
using SportsTime.Services.Inteface.Users;
using SportsTime.Services.Implementation.Users;

namespace SportsTime.Web.Extensions
{
	public static class ServicesServiceCollectionExtension
	{
		public static void AddServicesLayer(this IServiceCollection services)
		{
			services.AddTransient<SessionManager, SessionManager>();
			services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<ILoggerService, LoggerService>();

			#region Training

			services.AddTransient<ITraineeService, TraineeService>();
			services.AddTransient<ITrainerService, TrainerService>();

            #endregion

            #region Sports

            services.AddTransient<ISportsService, SportsService>();
            services.AddTransient<ISubscribtionsService, SubscribtionsService>();
            services.AddTransient<IChampionshipService, ChampionshipService>();

            #endregion

            #region Finance

            services.AddTransient<IPayrollService, PayrollService>();
            services.AddTransient<IRevenueService, RevenueService>();
            services.AddTransient<IExpenseService, ExpenseService>();

            #endregion

            #region Users

            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IEmployeeService, EmployeeService>();
            
            #endregion
        }
    }
}