namespace Sertifi.StudentsReporter.Application.Dto
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int StartYear { get; set; }
        public int EndYear { get; set; }
        public double[] GPARecord { get; set; }
    }
}
