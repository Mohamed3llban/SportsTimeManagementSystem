using Newtonsoft.Json;
using System.IO;

namespace SportsTime.Services.Implementation.AccountServices
{
    public class ServiceBase
    {
        public ServiceBase()
        {

        }
        public ServiceBase(int userId)
        {
            UserId = userId;
        }
        public static int UserId { get; set; }

        public static string GetCurrentLanguage()
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.ToString();
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

    }
}
