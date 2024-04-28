using Msimon.TaskGenerator.Library.Contracts.Dto;
using Msimon.TaskGenerator.WebApi.IntegrationTest.Helpers;
using System.Net;
using Xunit.Abstractions;
using Xunit;

namespace Msimon.TaskGenerator.WebApi.IntegrationTest
{

    public class TaskControleTest(WebApplicationTest applicationTest)
   : IClassFixture<WebApplicationTest>
    {
        private readonly HttpClient _client = applicationTest.CreateDefaultClient();

        [Fact]
        public async Task GivenTaskItemRqDto_WhenYouPostData_ThenReturnOk()
        {
            //Arrange
            var request = new TaskItemRqDto()
            {
                CreationDate = DateTime.Now,
                TaskDescription = "TestDescription",
                TaskName = "TestName",
            };

            //Act
            var response = await _client.PostAsJsonAsync("/v1/Task/InsertTask", request);

            //Assert 
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}

