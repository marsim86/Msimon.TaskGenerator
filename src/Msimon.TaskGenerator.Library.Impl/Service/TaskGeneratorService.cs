using Msimon.TaskGenerator.Infrastructure.Contracts;
using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
using Msimon.TaskGenerator.Library.Contracts.Dto;
using Msimon.TaskGenerator.Library.Contracts.Service;
using Msimon.TaskGenerator.Library.Impl.Mappers.Extension;
using Msimon.TaskGenerator.Library.Impl.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Library.Impl.Service
{
    public class TaskGeneratorService(ITaskCacheService taskCacheService,
        ITaskItemRepository taskItemRepository) : ITaskGeneratorService
    {
        public async Task<TaskItemRsDto?> AddNewTask(TaskItemRqDto taskItemRqDto)
        {
            try
            {
                var taskItem = taskItemRqDto.MapToModel<TaskItem>();
                var result = await Task.Run(() => taskCacheService.AddTask(taskItem));

                var taskItemModel = taskItem.MapToModel<TaskItemModel>();
                await taskItemRepository.AddItem(taskItemModel);
                return result ? taskItem.MapToDto<TaskItemRsDto>() : null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return null;
            }

        }

        public async Task<TaskItemRsDto?> CheckAsCompleted(int taskId)
        {
            try
            {
                var result = await Task.Run(() => taskCacheService.GetTasks().FirstOrDefault(x => x.TaskId == taskId && !x.IsCompleted));

                if (result != null)
                {
                    result.IsCompleted = true;
                    var updateResult = await Task.Run(() => taskCacheService.UpdateTask(result));
                    await taskItemRepository.UpdateItem(result.MapToModel<TaskItemModel>());

                    return updateResult ? result.MapToDto<TaskItemRsDto>() : null;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                //Pinta Logs
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

        public async Task<IEnumerable<TaskItemRsDto>> GetAllTask(bool onlyUncompleted = false)
        {
            try
            {
                var result = await Task.Run(() => taskCacheService.GetTasks());
                if (!result.Any())
                {
                    result = taskItemRepository.GetAllItems().MapToModel<IEnumerable<TaskItem>>();
                    taskCacheService.AddTask(result);
                }

                return result.Where(x => x.IsCompleted || !onlyUncompleted).MapToDto<IEnumerable<TaskItemRsDto>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Enumerable.Empty<TaskItemRsDto>();
            }
        }

        public async Task<IEnumerable<TaskItemRsDto>> SortTask()
        {
            try
            {
                var result = await Task.Run(() => taskCacheService.GetTasks().Where(x => x.IsCompleted));
                return result.OrderBy(x => x.CreationDate).MapToDto<IEnumerable<TaskItemRsDto>>();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return Enumerable.Empty<TaskItemRsDto>();
            }
        }
    }
}
