using GL_DotNetFullStack_Project;
using GL_DotNetFullStack_Project.Data;
using GL_DotNetFullStack_Project.Models;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestxUnit_Project.UnitTest
{
    public class ProjectRepositoryTest: IClassFixture<TestingWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;
        public ProjectRepositoryTest(TestingWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }

        [Fact]
        public async System.Threading.Tasks.Task Project_GETAll_Action()
        {
            // Act
            var response = await _client.GetAsync("/api/Project");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            //Assert.Contains("<h1 class=\"bg-info text-white\">Records</h1>", responseString);
            //Assert.Contains("Create Record", responseString);
        }
        [Fact]
        public async System.Threading.Tasks.Task Project_GETById_Action()
        {
            // Act
            var response = await _client.GetAsync("/api/Project/1");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType.ToString());
            Assert.Contains("{\"id\":1,", responseString); 
            //Assert.Contains("Create Record", responseString);
        }

         
        public async System.Threading.Tasks.Task Project_POST_Action_InvalidModel()
        {
            // Arrange
            var postRequest = new HttpRequestMessage(HttpMethod.Post, "/api/Project");
            
           // Project createModle = new Project() { ID = 3, Name = "BigData", Detail = "BD3", CreatedOn = DateTime.Now };
            var prjformModel = new Dictionary<string, string>
                {
                    { "ID", "3" },
                    { "Name", "BigData" },
                    { "Detail","BD3" },
                    { "CreatedOn" , "2021-12-19" }
                };

            postRequest.Content.Headers.ContentType.MediaType = "application/json";
            postRequest.Content = new FormUrlEncodedContent(prjformModel);

            // Act
            var response = await _client.SendAsync(postRequest);

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("The field Age must be between 40 and 60", responseString);
        }

    }
}


/*
 * private readonly CustomWebApplicationFactory<GL_DotNetFullStack_Project.Startup>
            _factory;

        public ProjectRepositoryTest(CustomWebApplicationFactory<GL_DotNetFullStack_Project.Startup> factory)
        {
            _factory = factory;
        }
         
        #region snippet1
        [Fact]
        public async System.Threading.Tasks.Task GetProjectsList()
        {
            // Arrange
            void ConfigureTestServices(IServiceCollection services) =>
                services.AddSingleton<ProjectRepoSqlEfImpl>(new TestProjectClient());
            var client = _factory
                .WithWebHostBuilder(builder =>
                    builder.ConfigureTestServices(ConfigureTestServices))
                .CreateClient();

            // Act
            var profile = await client.GetAsync("/GithubProfile");
            Assert.Equal(HttpStatusCode.OK, profile.StatusCode);
           /*  var profileHtml = await HtmlHelpers.GetDocumentAsync(profile);

             var profileWithUserName = await client.SendAsync(
                (IHtmlFormElement)profileHtml.QuerySelector("#user-profile"),
                new Dictionary<string, string> { ["Input_UserName"] = "user" }); */

/*
// Assert
Assert.Equal(HttpStatusCode.OK, profileWithUserName.StatusCode);
var profileWithUserHtml =
    await HtmlHelpers.GetDocumentAsync(profileWithUserName);
var userLogin = profileWithUserHtml.QuerySelector("#user-login");
Assert.Equal("user", userLogin.TextContent);
        }
        #endregion

        public class TestProjectClient : ProjectRepoSqlEfImpl
{
    public TestProjectClient(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    public Task<Project> GetProjectAsync(string userName)
    {
        if (userName == "user")
        {
            return System.Threading.Tasks.Task.FromResult(
                new Project() { ID = 5, Name = "Angular # Project", Detail = "project 5", CreatedOn = DateTime.Now }
                );
        }
        else
        {
            return System.Threading.Tasks.Task.FromResult<Project>(null);
        }
    }
}*/