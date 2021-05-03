using System.Collections.Generic;
using System.Linq;
using Sertifi.StudentsReporter.Domain;

namespace Sertifi.StudentsReporter.Application.Extensions
{
    public static class StudentsExtensions
    {
        public static IEnumerable<Student> OrderByHighestOverallGPA(this IEnumerable<Student> students)
        {
            return students.OrderByDescending(x => x.GradePointAverages.Average(y => y.Value));
        }

        public static IEnumerable<Student> OrderByMostInconsistent(this IEnumerable<Student> students)
        {
            return students.OrderByDescending(x =>
                x.GradePointAverages.Max(y => y.Value) - x.GradePointAverages.Min(y => y.Value));
        }
    }
}