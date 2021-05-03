using System.Collections.Generic;
using System.Linq;
using Sertifi.StudentsReporter.Domain;

namespace Sertifi.StudentsReporter.Application.Extensions
{
    public static class GradePointAverageExtensions
    {
        public static int? YearWithHighestGPA(this IEnumerable<GradePointAverage> gradePointAverages)
        {
            return gradePointAverages.GroupBy(x => x.Year)
                                     .OrderByDescending(x => x.Average(y => y.Value))
                                     .Select(x => x.Key)
                                     .FirstOrDefault();
        }

        public static int? YearWithHighestAttendance(this IEnumerable<GradePointAverage> gradePointAverages)
        {
            return gradePointAverages.GroupBy(x => x.Year)
                                     .OrderByDescending(x => x.Count())
                                     .ThenBy(x => x.Key)
                                     .Select(x => x.Key)
                                     .FirstOrDefault();
        }
    }
}