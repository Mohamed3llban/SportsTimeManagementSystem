
//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.DependencyInjection;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace SportsTime.Web.Extensions
//{
//	public static class AuthorizationServiceCollectionExtension
//	{
//		public static void AddAuthorizationLayer(this IServiceCollection services)
//		{
//			//			WATING

//			//services.AddAuthorization(options =>
//			//{
//			//	//---Default Policy
//			//	options.DefaultPolicy = new AuthorizationPolicyBuilder()
//			//						.RequireAuthenticatedUser()
//			//						.AddRequirements(new SessionRequirement())
//			//						//.RequireClaim(ClaimTypes.Name)
//			//						.Build();
//			//	//			WATING

//			//	// PolicyRegister.Register(options);
//			//});


//			//---- add Antiforgery  for (CSRF)

//			services.AddAntiforgery(options =>
//			{
//				options.HeaderName = "X-CSRF-TOKEN-Loan";
//			});

//			//--- 
//			AddAuthorizationService(services);
//		}


//		private static void AddAuthorizationService(IServiceCollection services)
//		{
//			//			WATING
//			//services.AddTransient<IAuthorizationHandler, SessionHandlerAuthorization>();
//			//services.AddTransient<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
//			//services.AddTransient<IAuthorizationHandler, PermissionHandlerAuthorization>();
//			//services.AddTransient<IUserPermissionsService, UserPermissionsService>();

//		}
//	}
//}
