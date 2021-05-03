using System.Threading.Tasks;

namespace Sertifi.StudentsReporter.Application.Services
{
    public interface IStudentsReportPublishService
    {
        Task PublishAsync(StudentsReport report);
    }
}