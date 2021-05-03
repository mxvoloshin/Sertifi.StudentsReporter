using Sertifi.StudentsReporter.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Sertifi.StudentsReporter.Domain.Tests
{
    public class GradePointAverageTests
    {
        [Fact]
        public void Should_ThrowFieldValidationException_When_YearIsLessThanMinValue()
        {
            //Assert
            var exception = Assert.Throws<FieldValidationException>(() => { new GradePointAverage(1, 0, 3.1); });
            Assert.Equal(nameof(GradePointAverage.Year), exception.FieldName);
        }

        [Fact]
        public void Should_ThrowFieldValidationException_When_ValueIsLessThanZero()
        {
            //Assert
            var exception = Assert.Throws<FieldValidationException>(() => { new GradePointAverage(1, 2011, -1); });
            Assert.Equal(nameof(GradePointAverage.Value), exception.FieldName);
        }
    }
}
