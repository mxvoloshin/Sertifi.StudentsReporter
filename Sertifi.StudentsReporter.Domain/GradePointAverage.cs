using System;
using Sertifi.StudentsReporter.Domain.Exceptions;

namespace Sertifi.StudentsReporter.Domain
{
    public class GradePointAverage
    {
        public GradePointAverage(int studentId, int year, double value)
        {
            if (year < DateTime.MinValue.Year)
            {
                throw new FieldValidationException(nameof(Year), $"{nameof(Year)} cannot be less than {DateTime.MinValue.Year}");
            }

            if (value < 0)
            {
                throw new FieldValidationException(nameof(Value), $"{nameof(Value)} cannot be less than zero");
            }

            StudentId = studentId;
            Year = year;
            Value = value;
        }

        public  int StudentId { get; }
        public int Year { get; }
        public double Value { get;}
    }
}