using System;

namespace Sertifi.StudentsReporter.Application.Exceptions
{
    public class GetStudentsException : Exception
    {
        public GetStudentsException()
        {
        }

        public GetStudentsException(string message) : base(message)
        {
        }

        public GetStudentsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}