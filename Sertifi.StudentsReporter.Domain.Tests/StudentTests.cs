using Sertifi.StudentsReporter.Domain.Exceptions;
using System;
using System.Linq;
using Xunit;

namespace Sertifi.StudentsReporter.Domain.Tests
{
    public class StudentTests
    {
        [Fact]
        public void Should_ThrowFieldValidationException_When_NameIsEmpty()
        {
            //Assert
            var exception = Assert.Throws<FieldValidationException>(() => { new Student(1, string.Empty, 2013, 2015); });
            Assert.Equal(nameof(Student.Name), exception.FieldName);
        }

        [Fact]
        public void Should_ThrowFieldValidationException_When_StartYearIsLessThenMinValue()
        {
            //Assert
            var exception = Assert.Throws<FieldValidationException>(() => { new Student(1, "Jill", 0, 2015); });
            Assert.Equal(nameof(Student.StartYear), exception.FieldName);
        }

        [Fact]
        public void Should_ThrowFieldValidationException_When_EndYearIsLessThenMinValue()
        {
            //Assert
            var exception = Assert.Throws<FieldValidationException>(() => { new Student(1, "Jill", 2013, 0); });
            Assert.Equal(nameof(Student.EndYear), exception.FieldName);
        }

        [Fact]
        public void Should_ThrowDomainValidationException_When_EndYearIsLessThenMinValue()
        {
            //Assert
            var exception = Assert.Throws<DomainValidationException>(() => { new Student(1, "Jill", 2013, 2011); });
            Assert.Contains("cannot be less than", exception.Message);
        }

        [Fact]
        public void Should_ThrowDomainValidationException_When_GPAYearsCountDoesntMatchTotalYearsStudied()
        {
            //Arrange
            var student = new Student(1, "Jill", 2011, 2013);

            //Assert
            var exception = Assert.Throws<DomainValidationException>(() => { student.SetAllTimeGradePointAverages(new[] { 1.1, 3.5 }); });
            Assert.Contains("doesn't match total years studied", exception.Message);
        }

        [Fact]
        public void Should_SetAllTimeGPAByEachYear()
        {
            //Arrange
            var student = new Student(1, "Jill", 2011, 2013);

            //Act
            student.SetAllTimeGradePointAverages(new[] { 1.1, 3.1, 4.1 });
            var gradePointAverages = student.GradePointAverages.ToArray();

            //Assert
            Assert.Equal(2011, gradePointAverages[0].Year);
            Assert.Equal(1.1, gradePointAverages[0].Value);

            Assert.Equal(2012, gradePointAverages[1].Year);
            Assert.Equal(3.1, gradePointAverages[1].Value);

            Assert.Equal(2013, gradePointAverages[2].Year);
            Assert.Equal(4.1, gradePointAverages[2].Value);
        }
    }
}
