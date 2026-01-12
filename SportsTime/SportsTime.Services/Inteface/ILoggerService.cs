using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsTime.Services.Inteface;

public interface ILoggerService
{
	void AddExceptionError(Exception e, int UserId, string Action, string filePath);
	void AddLoggerInfo(string message, int UserId, string Action, string filePath);
	void AddExceptionError(Exception ex, object inputs);
}
