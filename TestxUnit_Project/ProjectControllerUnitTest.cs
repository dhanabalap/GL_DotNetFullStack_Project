using GL_DotNetFullStack_Project;
using GL_DotNetFullStack_Project.Models;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestxUnit_Project
{
    public class ProjectControllerUnitTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private const string WeatherForecastUriPath = "weatherforecast";
        private const string ProjectUriPath = "ProjectController";

        private static HttpClient _httpClientWithFullIntegration;

        private readonly WebApplicationFactory<Startup> _webApplicationFactory;
        public ProjectControllerUnitTest(WebApplicationFactory<Startup> webApplicationFactory)
        {
            _webApplicationFactory = webApplicationFactory;
            _httpClientWithFullIntegration ??= webApplicationFactory.CreateClient();
        }

        


        [Fact]
        public async void Get_WithFullyIntegratedServices_ReturnsOkWithExpectedResponse()
        {
            // Act
            var weatherForecastResponse = await _httpClientWithFullIntegration.GetAsync(WeatherForecastUriPath);

            // Assert
            Assert.Equal(HttpStatusCode.OK, weatherForecastResponse.StatusCode);

            var weatherForecastContent = await weatherForecastResponse.Content.ReadAsStringAsync();
            var weatherForecast = JsonConvert.DeserializeObject<WeatherForecast>(weatherForecastContent);

            Assert.NotNull(weatherForecast);
            Assert.NotNull(weatherForecast.Summary);
        }
        /*
        [Fact]
        public async void Get_WithFullyIntegratedServices_ReturnsOkWithExpectedResponse()
        {
            // Act
            var projectResponse = await _httpClientWithFullIntegration.GetAsync(ProjectUriPath);

            // Assert
            Assert.Equal(HttpStatusCode.OK, projectResponse.StatusCode);

            var projectContent = await projectResponse.Content.ReadAsStringAsync();
            var project = JsonConvert.DeserializeObject<Project>(projectContent);

            Assert.NotNull(project);
            Assert.NotNull(project.Name);
        }*/
    }
}
