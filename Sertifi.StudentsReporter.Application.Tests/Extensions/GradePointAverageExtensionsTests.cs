using System.Linq;
using Sertifi.StudentsReporter.Application.Extensions;
using Xunit;

namespace Sertifi.StudentsReporter.Application.Tests.Extensions
{
    public class GradePointAverageExtensionsTests : IClassFixture<StudentsTestFixture>
    {
        private readonly StudentsTestFixture _fixture;

        public GradePointAverageExtensionsTests(StudentsTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_TakeEarliestHighestAttendanceYear_When_TiesPresent()
        {
            //Arrange
            var gradePointAverages = _fixture.Students.SelectMany(x => x.GradePointAverages);

            //Act
            var year = gradePointAverages.YearWithHighestAttendance();

            //Assert
            Assert.Equal(2013, year);
        }

        [Fact]
        public void Should_CalculateYearWithHighestOverallGPA()
        {
            //Arrange
            var gradePointAverages = _fixture.Students.SelectMany(x => x.GradePointAverages);

            //Act
            var highestGPAYear = gradePointAverages.YearWithHighestGPA();

            //Assert
            Assert.Equal(2016, highestGPAYear);
        }
    }
}