using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sertifi.StudentsReporter.Application;
using Sertifi.StudentsReporter.Application.Extensions;
using Sertifi.StudentsReporter.Application.Services;
using Sertifi.StudentsReporter.ConsoleApp.Services;

namespace Sertifi.StudentsReporter.ConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host = CreateHost();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var studentsSource = services.GetRequiredService<IStudentsSource>();
                    var studentDtos = await studentsSource.GetStudentsAsync();

                    var students = studentDtos.Select(x => x.ToEntity()).ToList();
                    var report = StudentsReport.Create("Maksym Voloshyn", "mx.voloshin@gmail.com", students);

                    var outputReportService = services.GetRequiredService<IOutputReportService>();
                    var outputReportTask = outputReportService.OutputAsync(report);

                    var publishService = services.GetRequiredService<IStudentsReportPublishService>();
                    var publishTask = publishService.PublishAsync(report);

                    await Task.WhenAll(outputReportTask, publishTask);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.ReadLine();
        }

        private static IHost CreateHost()
        {
            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHttpClient();
                    services.AddTransient<IStudentsSource, StudentsSource>();
                    services.AddTransient<IStudentsReportPublishService, StudentsReportPublishService>();
                    services.AddTransient<IOutputReportService, ConsoleOutputReportService>();
                });

            return builder.Build();
        }
    }
}

