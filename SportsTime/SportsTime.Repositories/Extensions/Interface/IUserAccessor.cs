using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Repositories.Extensions.Interface;

public interface IUserAccessor
{
	int GetCurrentUserId();
	int GetCurrentCompanyId();
}
