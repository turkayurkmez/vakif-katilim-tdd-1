using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Speakers.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Speakers.Tests.IntegrationTests
{
    public class WebAPITests : IClassFixture<InMemoryWebApplicationFactory<Program>>
    {
        private InMemoryWebApplicationFactory<Program> _applicationFactory;

        public WebAPITests(InMemoryWebApplicationFactory<Program> applicationFactory)
        {
            _applicationFactory = applicationFactory;
        }

        [Fact]
        public async Task web_api_get_request()
        {
            var client = _applicationFactory.CreateClient();
            var response = await client.GetAsync("/api/speaker?value=kon");

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            
        }
        [Fact]
        public async Task post_request()
        {
            var client = _applicationFactory.CreateClient();
            Speaker speaker = new() { Name = "Konuşmacı", LastName = "3" };
            var httpContent = new StringContent(JsonConvert.SerializeObject(speaker), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/api/speaker", httpContent);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Headers.Location);
            Assert.Equal("http://localhost/api/Speaker?id=3", response.Headers.Location.ToString());
        }

    }
}
