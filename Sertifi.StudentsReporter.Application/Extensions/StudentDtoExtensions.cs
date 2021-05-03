using Sertifi.StudentsReporter.Application.Dto;
using Sertifi.StudentsReporter.Domain;

namespace Sertifi.StudentsReporter.Application.Extensions
{
    public static class StudentDtoExtensions
    {
        public static Student ToEntity(this StudentDto dto)
        {
            var student = new Student(dto.Id, dto.Name, dto.StartYear, dto.EndYear);
            student.SetAllTimeGradePointAverages(dto.GPARecord);
            return student;
        }
    }
}