using System;
using System.Collections.Generic;
using Sertifi.StudentsReporter.Domain.Exceptions;

namespace Sertifi.StudentsReporter.Domain
{
    public class Student
    {
        private readonly IList<GradePointAverage> _gradePointAverages = new List<GradePointAverage>();
        public Student(int id, string name, int startYear, int endYear)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new FieldValidationException($"{nameof(Name)}");
            }

            if (startYear < DateTime.MinValue.Year)
            {
                throw new FieldValidationException(nameof(StartYear), $"{nameof(StartYear)} cannot be less than {DateTime.MinValue.Year}");
            }

            if (endYear < DateTime.MinValue.Year)
            {
                throw new FieldValidationException(nameof(EndYear), $"{nameof(EndYear)} cannot be less than {DateTime.MinValue.Year}");
            }

            if (endYear < startYear)
            {
                throw new DomainValidationException($"{nameof(EndYear)} cannot be less than {nameof(StartYear)}");
            }

            Id = id;
            Name = name;
            StartYear = startYear;
            EndYear = endYear;
        }

        public int Id { get; }
        public string Name { get; }
        public int StartYear { get; }
        public int EndYear { get; }
        public IEnumerable<GradePointAverage> GradePointAverages => _gradePointAverages;

        public void SetAllTimeGradePointAverages(double[] gradePointsAverages)
        {
            var totalYearsStudied = EndYear - StartYear + 1;
            if (totalYearsStudied != gradePointsAverages.Length)
            {
                throw new DomainValidationException("GPA records count doesn't match total years studied");
            }

            _gradePointAverages.Clear();
            var recordIndex = 0;
            foreach (var gpa in gradePointsAverages)
            {
                _gradePointAverages.Add(new GradePointAverage(Id, StartYear + recordIndex, gpa));
                recordIndex++;
            }
        }
    }
}
