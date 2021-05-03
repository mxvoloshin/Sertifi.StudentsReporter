using System.Threading.Tasks;
using Sertifi.StudentsReporter.Application;

namespace Sertifi.StudentsReporter.ConsoleApp.Services
{
    public interface IOutputReportService
    {
        Task OutputAsync(StudentsReport report);
    }
}