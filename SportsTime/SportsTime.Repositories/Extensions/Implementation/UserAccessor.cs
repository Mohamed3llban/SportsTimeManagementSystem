using Microsoft.AspNetCore.Http;
using SportsTime.Repositories.Extensions.Interface;

namespace SportsTime.Repositories.Extensions.Implementation
{
	public class UserAccessor : IUserAccessor
	{
		private readonly IHttpContextAccessor _httpContextAccessor;
		public UserAccessor(IHttpContextAccessor httpContextAccessor)
		{
			_httpContextAccessor = httpContextAccessor;
		}

		public int GetCurrentUserId()
		{
			return _httpContextAccessor.HttpContext.Session.GetInt32(SessionKeys.SessionKeyUserId) ?? default;
		}

		public int GetCurrentCompanyId()
		{
			return _httpContextAccessor.HttpContext.Session.GetInt32(SessionKeys.SessionKeyCompany) ?? default;
		}

	}
}
