using Xunit;

namespace Sertifi.StudentsReporter.Application.Tests
{
    public class StudentsReportTests : IClassFixture<StudentsTestFixture>
    {
        private readonly StudentsTestFixture _fixture;

        public StudentsReportTests(StudentsTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_CreateStudentsReport()
        {
            //Arrange
            const string name = "MyName";
            const string email = "MyEmail";

            //Act
            var orderedStudents = StudentsReport.Create(name, email, _fixture.Students);

            //Assert
            Assert.Equal(name, orderedStudents.YourName);
            Assert.Equal(email, orderedStudents.YourEmail);
            Assert.Equal(2013, orderedStudents.YearWithHighestAttendance);
            //TODO: Setup bigger test fixture to test TOP10 property
            Assert.Equal(2016, orderedStudents.YearWithHighestOverallGPA);
            Assert.Equal(3, orderedStudents.StudentIdMostInconsistent);
        }
    }
}