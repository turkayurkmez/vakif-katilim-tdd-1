using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Speakers.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Tests.IntegrationTests
{
    public class InMemoryWebApplicationFactory<T> : WebApplicationFactory<T> where T : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Testing")
                   .ConfigureTestServices(services =>
                   {
                       var options = new DbContextOptionsBuilder<SpeakerDbContext>()
                                         .UseInMemoryDatabase("testMemory")
                                         .Options;

                       services.AddScoped<SpeakerDbContext>(provider=> new SpeakerTestDbContext(options));
                       var serviceProvider = services.BuildServiceProvider();
                       using var scope = serviceProvider.CreateScope();
                       var scopedService = scope.ServiceProvider;
                       var db = scopedService.GetRequiredService<SpeakerDbContext>();
                       db.Database.EnsureCreated();
                                   
                   });

        }
    }  
}
