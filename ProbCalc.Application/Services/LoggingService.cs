using Microsoft.Extensions.Configuration;

namespace ProbCalc.Application.Services
{
    public class LoggingService : ILoggingService
    {
        private readonly IConfiguration _configuration;
        private readonly string _filePath;

        public LoggingService(IConfiguration configuration)
        {
            _configuration = configuration;
            _filePath = _configuration.GetSection("LoggingService")["FilePath"] ?? AppDomain.CurrentDomain.BaseDirectory + "log.txt";
        }

        public void Write(string message)
        {
            try
            {
                File.AppendAllText(_filePath, message + Environment.NewLine);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
