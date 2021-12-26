using GL_ProjectManagement;
using GL_ProjectManagement.BusinessEntities.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GL_ProjectManagementTestSuite.UnitTest
{
    public class BaseControllerTests: IClassFixture<GL_ProjMgtWebApplicationFactoryClient<Startup>>
    {
    
        private readonly HttpClient _client;
        public BaseControllerTests(GL_ProjMgtWebApplicationFactoryClient<Startup> factory)
        {
        _client = factory.CreateClient();
        }


        [Theory]
        [Trait("Category", "GetProjectTaskUser")]
        [InlineData("/api/Project")]
        [InlineData("/api/Project/11")]
        [InlineData("/api/Task")]
        [InlineData("/api/Task/111")]
        [InlineData("/api/User")]
        [InlineData("/api/User/1011")]
        public async System.Threading.Tasks.Task GetAllAndById_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
        // Act
        var actualResult = await _client.GetAsync(url);
        // Assert
        actualResult.EnsureSuccessStatusCode();
        Assert.Equal("application/json; charset=utf-8", actualResult.Content.Headers.ContentType.ToString());
        }


        [Theory]
        [Trait("Category", "GetByIdProjectTaskUser")]
        [InlineData("/api/Project/4")]
        [InlineData("/api/User/4")]
        [InlineData("/api/Task/4")]
        public async System.Threading.Tasks.Task GetsProjectTaskUser_ByID_Returns404(string url)
        {
        // Act
        var actualResult = await _client.GetAsync(url);
        //Assert
        Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
        }


        [Theory]
        [Trait("Category", "Create_ProjectTaskUser")]
        [InlineData("/api/Project")]
        [InlineData("/api/Task")]
        [InlineData("/api/User")]
        public async System.Threading.Tasks.Task CreateNewProjectTaskUser_ReturnsSuccess(string url)
        {
        if (url.Equals("/api/Project"))
        {
            var modelobjects = new Project() { ID = 13, Name = "Fullstack", Detail = "Detail for project 2", CreatedOn = DateTime.Now };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);
            actualResult.EnsureSuccessStatusCode();
            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.Created, actualResult.StatusCode);
        }
        if (url.Equals("/api/Task"))
        {
            var modelobjects = new GL_ProjectManagement.BusinessEntities.Models.Task() { ID = 113, ProjectID = 12, Status = 2, AssignedToUserID = 1011, Detail = "PTest Task 1", CreatedOn = DateTime.Now };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);
            actualResult.EnsureSuccessStatusCode();
            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.Created, actualResult.StatusCode);
        }
        if (url.Equals("/api/Task"))
        {
            var modelobjects = new User() { ID = 1013, FirstName = "Rathis", LastName = "R", Email = "rathis@gmail.com", Password = "T123" };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);
            actualResult.EnsureSuccessStatusCode();
            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.Created, actualResult.StatusCode);
        }

        }


        [Theory]
        [Trait("Category", "Create_ProjectTaskUser")]
        [InlineData("/api/Project")]
        [InlineData("/api/Task")]
        [InlineData("/api/User")]
        public async System.Threading.Tasks.Task CreateNewProjectTaskUser_ReturnsBadRequestAsIdExists(string url)
        {
        if (url.Equals("/api/Project"))
        {
            var modelobjects = new Project() { ID = 11, Name = "Fullstack", Detail = "Detail for project 2", CreatedOn = DateTime.Now };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
        }
        if (url.Equals("/api/Task"))
        {
            var modelobjects = new GL_ProjectManagement.BusinessEntities.Models.Task() { ID = 111, ProjectID = 12, Status = 2, AssignedToUserID = 1011, Detail = "PTest Task 1", CreatedOn = DateTime.Now };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
        }
        if (url.Equals("/api/User"))
        {
            var modelobjects = new User() { ID = 1011, FirstName = "Rathis", LastName = "R", Email = "rathis@gmail.com", Password = "T123" };
            var postContent = new StringContent(JsonConvert.SerializeObject(modelobjects), Encoding.UTF8, "application/json");

            var actualResult = await _client.PostAsync(url, postContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.BadRequest, actualResult.StatusCode);
        }
        }

        [Theory]
        [Trait("Category", "UpdatesProjectTaskUser")]
        [InlineData("/api/Project/12")]
        [InlineData("/api/Task/112")]
        [InlineData("/api/User/1012")]
        public async System.Threading.Tasks.Task UpdateProjectTaskUserInfoAnd_ReturnSuccess(string url)
        {
        if (url.Equals("/api/Project/11"))
        {
            Project project = new Project()
            { ID = 11, Name = "Project 11", Detail = "Updating the project Details for 11", CreatedOn = DateTime.Now };
            var updateContent = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);
            actualResult.EnsureSuccessStatusCode();

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NoContent, actualResult.StatusCode);
        }
        if (url.Equals("/api/Task/112"))
        {
            GL_ProjectManagement.BusinessEntities.Models.Task task = new GL_ProjectManagement.BusinessEntities.Models.Task()
            { ID = 112, ProjectID = 11, Status = 1, AssignedToUserID = 1011, Detail = "PTask 1", CreatedOn = DateTime.Now };
            var updateContent = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);
            actualResult.EnsureSuccessStatusCode();

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NoContent, actualResult.StatusCode);
        }
        if (url.Equals("/api/User/1012"))
        {
            User user = new User() { ID = 1012, FirstName = "SaiSangeetha", LastName = "D", Email = "saisangeetha@gmail.com", Password = "D123" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);
            actualResult.EnsureSuccessStatusCode();

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NoContent, actualResult.StatusCode);
        }
        }


        [Theory]
        [Trait("Category", "UpdatesProjectTaskUser")]
        [InlineData("/api/Project/10")]
        [InlineData("/api/Task/100")]
        [InlineData("/api/User/1000")]
        public async System.Threading.Tasks.Task UpdateProjectTaskUser_IdNotFound(string url)
        {
        if (url.Equals("/api/Project/10"))
        {
            Project project = new Project()
            { ID = 10, Name = "Project 10", Detail = "Updating the project Details for 11", CreatedOn = DateTime.Now };
            var updateContent = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
        }
        if (url.Equals("/api/Task/100"))
        {
            GL_ProjectManagement.BusinessEntities.Models.Task task = new GL_ProjectManagement.BusinessEntities.Models.Task()
            { ID = 100, ProjectID = 11, Status = 1, AssignedToUserID = 1011, Detail = "PTask 1", CreatedOn = DateTime.Now };
            var updateContent = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
        }
        if (url.Equals("/api/User/1000"))
        {
            User user = new User() { ID = 1000, FirstName = "SaiSangeetha", LastName = "D", Email = "saisangeetha@gmail.com", Password = "D123" };
            var updateContent = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, "application/json");
            var actualResult = await _client.PutAsync(url, updateContent);

            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
        }
        }

        [Theory]
        [Trait("Category", "DeleteProjectTaskUser")] 
        [InlineData("/api/Project/9")] 
        [InlineData("/api/Task/9")] 
        [InlineData("/api/User/9")]
        public async System.Threading.Tasks.Task DeleteById_EndpointsReturnNotFound(string url)
        {
            // Act
            var actualResult = await _client.DeleteAsync(url);
            // Assert
            Assert.NotNull(actualResult);
            Assert.Equal(HttpStatusCode.NotFound, actualResult.StatusCode);
        }
    }
}
