using System;
using System.Collections.Generic;
using System.Linq;
using Sertifi.StudentsReporter.Domain;

namespace Sertifi.StudentsReporter.Application.Tests
{
    public class StudentsTestFixture : IDisposable
    {
        private readonly IList<Student> _students = new List<Student>();

        public StudentsTestFixture()
        {
            var jack = new Student(1, "Jack", 2013, 2016);
            jack.SetAllTimeGradePointAverages(new[] { 3.4, 2.1, 1.2, 3.6 });

            var jill = new Student(2, "Jill", 2011, 2014);
            jill.SetAllTimeGradePointAverages(new[] { 3.3, 2.3, 1.1, 3.7 });

            var sharon = new Student(3, "Sharon", 2013, 2016);
            sharon.SetAllTimeGradePointAverages(new[] { 3.6, 2.3, 1.1, 3.8 });

            _students.Add(jack);
            _students.Add(jill);
            _students.Add(sharon);
        }

        public IEnumerable<Student> Students => _students.AsEnumerable();

        public void Dispose()
        {
        }
    }
}