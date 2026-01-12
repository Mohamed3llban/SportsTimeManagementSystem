//using Microsoft.Extensions.DependencyInjection;

//namespace SportsTime.Web.Extensions
//{
//	public static class AuthenticationServiceCollectionExtension
//	{
//		public const string AuthenticationSchemeName = "CookieAuthentication";
//		public static void AddAuthenticationLayer(this IServiceCollection services)
//		{
//			services.AddAuthentication(AuthenticationSchemeName)
//			   .AddCookie("CookieAuthentication", config =>
//			   {
//				   config.Cookie.Name = "UserLoginCookie"; // Name of cookie   
//				   config.LoginPath = "/Identity/Account/Login"; // Path for the redirect to user login page
//				   config.AccessDeniedPath = "/Home/AccessDenied";
//			   });

//		}
//    }
//}
