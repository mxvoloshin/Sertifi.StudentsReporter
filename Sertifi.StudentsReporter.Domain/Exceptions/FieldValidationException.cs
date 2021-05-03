using System;

namespace Sertifi.StudentsReporter.Domain.Exceptions
{
    public class FieldValidationException : DomainValidationException
    {
        public FieldValidationException(string fieldName)
        {
            FieldName = fieldName;
        }

        public FieldValidationException(string fieldName, string message) : base(message)
        {
            FieldName = fieldName;
        }

        public FieldValidationException(string fieldName, string message, Exception innerException) : base(message, innerException)
        {
            FieldName = fieldName;
        }

        public string FieldName { get; }
    }
}