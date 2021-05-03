using System.Collections.Generic;
using System.Linq;
using Sertifi.StudentsReporter.Application.Dto;
using Sertifi.StudentsReporter.Application.Extensions;
using Sertifi.StudentsReporter.Domain;

namespace Sertifi.StudentsReporter.Application
{
    public class StudentsReport
    {
        public string YourName { get; set; }
        public string YourEmail { get; set; }
        public int? YearWithHighestAttendance { get; set; }
        public int? YearWithHighestOverallGPA { get; set; }
        public int[] Top10StudentIdsWithHighestGPA { get; set; }
        public int? StudentIdMostInconsistent { get; set; }

        public static StudentsReport Create(string name, string email, IEnumerable<Student> students)
        {
            var studentsArray = students as Student[] ?? students.ToArray();
            var gradePointAverages = studentsArray.SelectMany(x => x.GradePointAverages).ToList();

            return new StudentsReport
            {
                YourName = name,
                YourEmail = email,
                YearWithHighestAttendance = gradePointAverages.YearWithHighestAttendance(),
                YearWithHighestOverallGPA = gradePointAverages.YearWithHighestGPA(),
                Top10StudentIdsWithHighestGPA = studentsArray.OrderByHighestOverallGPA()
                                                          .Take(10)
                                                          .Select(x => x.Id)
                                                          .ToArray(),
                StudentIdMostInconsistent = studentsArray.OrderByMostInconsistent()
                                                      .Select(x => x.Id)
                                                      .FirstOrDefault()
            };
        }
    }
}