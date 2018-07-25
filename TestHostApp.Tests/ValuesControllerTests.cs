using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace TestHostApp.Tests
{
    public class ValuesControllerTests
    {
        private readonly HttpClient _client;

        public ValuesControllerTests()
        {
            var webHost = new WebHostBuilder()
            //.ConfigureTestServices(s => s.AddSingleton<IFoo, MockedFoo>())
            .UseStartup<Startup>();
            var testserver = new TestServer(webHost);
            _client = testserver.CreateClient();
        }

        [Fact]
        public async Task DefaultGetTest_SucessfulResult()
        {
            // Arrange 
            var expectedResult = 2;
            
            // Act
            var response = await _client.GetAsync("/api/values");
            var content = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<string>>(content);

            // Assert
            Assert.Equal(expectedResult, values.Count);
        }
    }
}
