using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Sertifi.StudentsReporter.Application.Dto;
using Sertifi.StudentsReporter.Application.Exceptions;

namespace Sertifi.StudentsReporter.Application.Services
{
    public class StudentsSource : IStudentsSource
    {
        private const string StudentsSourceUrl = @"http://apitest.sertifi.net/api/"; //TODO: move to config settings
        private const string GetStudentsEndpoint = @"Students";

        private readonly IHttpClientFactory _httpClientFactory;

        public StudentsSource(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<StudentDto>> GetStudentsAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, $"{StudentsSourceUrl}{GetStudentsEndpoint}");

            var client = _httpClientFactory.CreateClient();
            var response = await client.SendAsync(request);
            if (!response.IsSuccessStatusCode)
            {
                //TODO: logging
                throw new GetStudentsException($"Failed to get students - {response.ReasonPhrase}");
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<IEnumerable<StudentDto>>(jsonString);
        }
    }
}