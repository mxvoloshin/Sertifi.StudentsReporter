using System.Collections.Generic;
using System.Threading.Tasks;
using Sertifi.StudentsReporter.Application.Dto;

namespace Sertifi.StudentsReporter.Application.Services
{
    public interface IStudentsSource
    {
        Task<IEnumerable<StudentDto>> GetStudentsAsync();
    }
}
