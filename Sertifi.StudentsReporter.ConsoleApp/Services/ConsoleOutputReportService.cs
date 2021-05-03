using System;
using System.Threading.Tasks;
using Sertifi.StudentsReporter.Application;

namespace Sertifi.StudentsReporter.ConsoleApp.Services
{
    public class ConsoleOutputReportService : IOutputReportService
    {
        public Task OutputAsync(StudentsReport report)
        {
            return Task.Run(() =>
            {
                Console.WriteLine("====================================");
                Console.WriteLine($"YourName                      - {report.YourName}");
                Console.WriteLine($"YourEmail                     - {report.YourEmail}");
                Console.WriteLine($"YearWithHighestAttendance     - {report.YearWithHighestAttendance}");
                Console.WriteLine($"YearWithHighestOverallGPA     - {report.YearWithHighestOverallGPA}");
                Console.WriteLine($"Top10StudentIdsWithHighestGPA - {string.Join(',', report.Top10StudentIdsWithHighestGPA)}");
                Console.WriteLine($"StudentIdMostInconsistent     - {report.StudentIdMostInconsistent}");
                Console.WriteLine("====================================");
            });
        }
    }
}