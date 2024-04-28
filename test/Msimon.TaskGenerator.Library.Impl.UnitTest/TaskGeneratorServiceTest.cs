using Msimon.TaskGenerator.Infrastructure.Contracts;
using Msimon.TaskGenerator.Library.Contracts.Dto;
using Msimon.TaskGenerator.Library.Contracts.Service;
using Msimon.TaskGenerator.Library.Impl.Model;
using Msimon.TaskGenerator.Library.Impl.Service;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Msimon.TaskGenerator.Library.Impl.UnitTest
{
    public class TaskGeneratorServiceTest
    {
        [Fact]
        public async Task When_AddNewTask_RetunOk()
        {
            //Arrange
            var taskItemRepository = Substitute.For<ITaskItemRepository>();
            var taskCacheService = Substitute.For<ITaskCacheService>();
            var taskItemRqDto = new TaskItemRqDto()
            {
                CreationDate = DateTime.UtcNow,
                TaskDescription = "Description",
                TaskName = "Name"
            };
            var taskItem = new TaskItem() {
                TaskId = 1,
                CreationDate = DateTime.UtcNow,
                TaskDescription = "Description",
                TaskName = "Name",
                IsCompleted = false,
            };

            taskCacheService.AddTask(taskItem).ReturnsForAnyArgs(true);
            //Act
            var service = new TaskGeneratorService(taskCacheService, taskItemRepository);
            var result = await service.AddNewTask(taskItemRqDto);

            //Assert
            Assert.NotNull(result);
        }
    }
}
