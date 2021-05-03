using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Sertifi.StudentsReporter.Application.Exceptions;

namespace Sertifi.StudentsReporter.Application.Services
{
    public class StudentsReportPublishService : IStudentsReportPublishService
    {
        private const string PublishTargetUrl = @" http://apitest.sertifi.net/api/"; //TODO: move to config settings
        private const string StudentsReportEndpoint = @"StudentAggregate";

        private readonly IHttpClientFactory _httpClientFactory;

        public StudentsReportPublishService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task PublishAsync(StudentsReport report)
        {
            var client = _httpClientFactory.CreateClient();

            var content = new StringContent(JsonSerializer.Serialize(report), Encoding.UTF8, "application/json");
            var response = await client.PutAsync($"{PublishTargetUrl}{StudentsReportEndpoint}", content);
            if (!response.IsSuccessStatusCode)
            {
                //TODO: logging
                throw new PublishReportException($"Failed to publish students report - {response.ReasonPhrase}");
            }
        }
    }
}