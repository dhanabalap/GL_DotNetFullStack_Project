using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit; 

namespace TestxUnit_Project.IntegrationTest
{
    #region snippet1
    public class BasicTests : IClassFixture<WebApplicationFactory<GL_DotNetFullStack_Project.Startup>>
    {
        private readonly WebApplicationFactory<GL_DotNetFullStack_Project.Startup> _factory;

        public BasicTests(WebApplicationFactory<GL_DotNetFullStack_Project.Startup> factory)
        {
            _factory = factory;
        }

        [Theory] 
        [InlineData("/api/Project")]
        [InlineData("/api/Task")]
        [InlineData("/api/User")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync(url);

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            Assert.Equal("application/json; charset=utf-8",
                response.Content.Headers.ContentType.ToString());
        }
    }
    #endregion
}