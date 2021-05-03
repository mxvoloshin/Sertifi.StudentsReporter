using System;

namespace Sertifi.StudentsReporter.Application.Exceptions
{
    public class PublishReportException : Exception
    {
        public PublishReportException()
        {
        }

        public PublishReportException(string message) : base(message)
        {
        }

        public PublishReportException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}