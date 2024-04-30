using Msimon.TaskGenerator.Infrastructure.Contracts;
using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Infrastructure.Impl
{
    public class TaskItemMockedRespository : ITaskItemRepository
    {
        public async Task<TaskItemModel?> AddItem(TaskItemModel taskItemModel)
        {
            //Simulate insert an item in DB
            return await Task.Run(() => taskItemModel);
        }

        public async Task<IEnumerable<TaskItemModel>> GetAllItems()
        {
            var result = new List<TaskItemModel>(){
                new()
                {
                    TaskId = 10,
                    CreationDate = new DateTime(2024,04,30,10,45,20, DateTimeKind.Local),
                    IsCompleted= true,
                    OperationDate = new DateTime(2024,04,30,11,00,20, DateTimeKind.Local),
                    TaskDescription = "Task DEscription 10",
                    TaskName = "Task Name 10"
                },
                new()
                {
                    TaskId = 11,
                    CreationDate = new DateTime(2024,04,30,11,45,20, DateTimeKind.Local),
                    IsCompleted= false,
                    TaskDescription = "Task DEscription 11",
                    TaskName = "Task Name 11"
                },
                new()
                {
                    TaskId = 12,
                    CreationDate = new DateTime(2024,04,29,12,45,20, DateTimeKind.Utc),
                    IsCompleted= false,
                    TaskDescription = "Task DEscription 12",
                    TaskName = "Task Name 12"
                }
            };
            return await Task.Run(() => result);
        }

        public async Task<int> UpdateItem(TaskItemModel taskItemModel)
        {
            //Simulate update ert an item in DB
            return await Task.Run(() => 1);
        }
    }
}
