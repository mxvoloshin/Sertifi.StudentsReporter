using System.Linq;
using Sertifi.StudentsReporter.Application.Extensions;
using Xunit;

namespace Sertifi.StudentsReporter.Application.Tests.Extensions
{
    public class StudentsExtensionsTests : IClassFixture<StudentsTestFixture>
    {
        private readonly StudentsTestFixture _fixture;

        public StudentsExtensionsTests(StudentsTestFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void Should_OrderStudentsByHighestGPA()
        {
            //Act
            var orderedStudents = _fixture.Students.OrderByHighestOverallGPA().ToArray();

            //Assert
            Assert.Equal(3, orderedStudents[0].Id);
            Assert.Equal(2, orderedStudents[1].Id);
            Assert.Equal(1, orderedStudents[2].Id);
        }

        [Fact]
        public void Should_OrderStudentsByMostInconsistent()
        {
            //Act
            var orderedStudents = _fixture.Students.OrderByMostInconsistent().ToArray();

            //Assert
            Assert.Equal(3, orderedStudents[0].Id);
            Assert.Equal(2, orderedStudents[1].Id);
            Assert.Equal(1, orderedStudents[2].Id);
        }
    }
}