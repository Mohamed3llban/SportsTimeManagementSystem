using Microsoft.Extensions.Primitives;
using System.Net;

namespace SportsTime.Web.Managers
{
	public class SessionManager
	{
		//private readonly IUserRoleService _userRoleService;
		//private readonly IHttpContextAccessor _httpContextAccessor;
		//private ISession _session => _httpContextAccessor.HttpContext.Session;
		//private int _defCompanyId = 1;

		//public SessionManager(IHttpContextAccessor httpContextAccessor, IUserRoleService userRoleService)
		//{
		//	_httpContextAccessor = httpContextAccessor;
		//	_userRoleService = userRoleService;
		//}

		//public void SetCurrentCompanyId(int companyId)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetInt32(SessionModel.SessionKeyCompany, companyId);
		//}

		//public void SetCurrentCompanyBranchId(int companyBranchId)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetInt32(SessionModel.SessionKeyCompanyBranch, companyBranchId);
		//}

		//public int GetCurrentCompanyBranchId()
		//{
		//	var sessionValue = _httpContextAccessor.HttpContext.Session.GetInt32(SessionModel.SessionKeyCompanyBranch);
		//	if (sessionValue != null)
		//	{
		//		return sessionValue.Value;
		//	}
		//	else
		//	{
		//		return 0;
		//	}
		//}

		//public int GetCurrentCompanyId()
		//{
		//	int currentCompanyId = _defCompanyId;
		//	var sessionValue = _httpContextAccessor.HttpContext.Session.GetInt32(SessionModel.SessionKeyCompany);
		//	if (sessionValue != null)
		//	{
		//		currentCompanyId = sessionValue.Value;
		//	}

		//	return currentCompanyId;
		//}

		//public void SetCurrentCompanyName(string companyName)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetObjectAsJson(SessionModel.SessionKeyCompanyName, companyName);
		//}

		//public string GetCurrentCompanyName()
		//{
		//	return _httpContextAccessor.HttpContext.Session.GetString(SessionModel.SessionKeyCompanyName);
		//}

		//public void SetCurrentDefualtCurrency(int defualtCurrency)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetInt32(SessionModel.SessionKeyDefualtCurrencyId, defualtCurrency);
		//}

		//public int GetCurrentDefualtCurrencyId()
		//{
		//	int DefualtCurrency = 1;
		//	var sessionValue = _httpContextAccessor.HttpContext.Session.GetInt32(SessionModel.SessionKeyDefualtCurrencyId);
		//	if (sessionValue != null)
		//	{
		//		//  DefualtCurrency = sessionValue.Value;
		//	}
		//	return DefualtCurrency;
		//}

		//public void SetUserId(int UserId)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetInt32(SessionModel.SessionKeyUserId, UserId);
		//}

		//public int GetUserId()
		//{
		//	int UserId = 1;
		//	var sessionValue = _httpContextAccessor.HttpContext.Session.GetInt32(SessionModel.SessionKeyUserId);
		//	if (sessionValue != null)
		//	{
		//		UserId = sessionValue.Value;
		//	}

		//	return UserId;
		//}

		//public void SetIsGlobalAdmin(bool sGlobalAdmin)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetBoolean(SessionModel.SessionKeyIsGlobalAdmin, sGlobalAdmin);
		//}

		//public bool GetIsGlobalAdmin()
		//{
		//	var isGlobalAdmin = false;
		//	var sessionValue = _httpContextAccessor.HttpContext.Session.GetBoolean(SessionModel.SessionKeyIsGlobalAdmin);
		//	if (sessionValue != null)
		//	{
		//		isGlobalAdmin = sessionValue.Value;
		//	}

		//	return isGlobalAdmin;
		//}

		//public void SetUserPermissions(List<int> screen)
		//{
		//	_httpContextAccessor.HttpContext.Session.SetObjectAsJson(SessionModel.SessionKeyUserPermissions, screen);
		//}

		//public List<int> GetUserPermission()
		//{
		//	var permissions = _httpContextAccessor.HttpContext.Session.GetObjectFromJson<List<int>>(SessionModel.SessionKeyUserPermissions);
		//	return permissions;
		//}

		//public string GetIpsAddress()
		//{
		//	IPHostEntry host;
		//	string localIP = "";
		//	host = Dns.GetHostEntry(Dns.GetHostName());
		//	foreach (IPAddress ip in host.AddressList)
		//	{
		//		if (ip.AddressFamily.ToString() == "InterNetwork")
		//		{
		//			localIP = ip.ToString();
		//		}
		//	}

		//	return localIP;
		//}
		//public string GetBrowserName()
		//{
		//	string BrowserName = "";
		//	StringValues userAgent = _httpContextAccessor.HttpContext.Request.Headers["User-Agent"];
		//	string uaString = Convert.ToString(userAgent[0]);
		//	var uaParser = Parser.GetDefault();
		//	ClientInfo c = uaParser.Parse(uaString);
		//	BrowserName = c.UserAgent.Family;

		//	return BrowserName;
		//}
		//public void SetSessionValues(int companyId, int userId, int BranchId, bool IsGlobalAdministrator)
		//{
		//	SetUserId(userId);
		//	SetCurrentCompanyId(companyId);
		//	SetCurrentCompanyBranchId(BranchId);
		//	SetIsGlobalAdmin(IsGlobalAdministrator);
		//}

		//public void ClearSessions()
		//{
		//	try
		//	{
		//		_httpContextAccessor.HttpContext.Session.Clear();
		//	}
		//	catch (Exception)
		//	{

		//	}
		//}

		//public bool UserHasSession
		//{
		//	get
		//	{
		//		return SessionHasKeys();
		//	}
		//}

		//private bool SessionHasKeys()
		//{
		//	try
		//	{
		//		var keys = _httpContextAccessor.HttpContext.Session.Keys.Count();
		//		return keys > 0;
		//	}
		//	catch (Exception)
		//	{

		//		return false;
		//	}
		//}
	}
}
