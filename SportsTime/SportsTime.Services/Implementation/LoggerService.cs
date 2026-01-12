using System;
using Serilog;
using System.IO;
using Newtonsoft.Json;
using SportsTime.Services.Inteface;

namespace SportsTime.Services.Implementation;

public class LoggerService : ILoggerService
{
	public void AddExceptionError(Exception e, int UserId, string Action, string filePath)
	{
		Log.Logger.ForContext("UserId", UserId)
				  .ForContext("Action", Action)
				  .ForContext("Source", e.Source)
				  .ForContext("StackTrace", e.StackTrace)
				  .ForContext("FilePath", filePath)
				  .ForContext("Exception", e.InnerException)
				  .ForContext("TargetSite", e.TargetSite)
				  .Error(e.Message);
	}

	public void AddExceptionError(Exception ex, object inputs)
	{
		if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString(@"yyyy\\MM"))))
			Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString(@"yyyy\\MM")));

		string path = Path.Combine(Directory.GetCurrentDirectory(), DateTime.Now.ToString(@"yyyy\\MM\\dd")) + ".log";
		string contents = $@"==={DateTime.Now.ToString("HH:mm:ss")}=======================================================================================
                    {ex.Message}
                    ----------------------------------------
                    {ex.InnerException?.Message}
                    ----------------------------------------
                    {ex.StackTrace}

                    ----------------------------------------
                    {JsonConvert.SerializeObject(inputs)}
                    =================================================================================================="

				+ Environment.NewLine;
		File.AppendAllText(path, contents);
	}

	public void AddLoggerInfo(string message, int UserId, string Action, string filePath)
	{
		Log.Logger.ForContext("UserId", UserId)
							 .ForContext("Action", Action)
							 .ForContext("FilePath", filePath)
							 .Information(message);
	}
}
