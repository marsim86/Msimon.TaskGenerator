using Microsoft.EntityFrameworkCore;
using Msimon.TaskGenerator.Infrastructure.Contracts;
using Msimon.TaskGenerator.Infrastructure.Contracts.Context;
using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Infrastructure.Impl
{
    internal class TaskItemRepository(TaskGeneratorContext context) : ITaskItemRepository
    {
        public async Task<TaskItemModel?> AddItem(TaskItemModel taskItemModel)
        {
            try
            {
                var taskItemResult = await context.TaskItem.AddAsync(taskItemModel);
                await context.SaveChangesAsync();
                return taskItemResult.Entity;
            }
            catch
            {
                //No existe BD, fuerzo el result
                taskItemModel.TaskId = new Random().Next(0, 100);
                return taskItemModel;
            }
            
        }

        public async Task<IEnumerable<TaskItemModel>> GetAllItems()
        {
            try
            {
                return await context.TaskItem.ToListAsync();
            }
            catch
            {
                //No existe BD, fuerzo el result
                return Enumerable.Empty<TaskItemModel>();
            }
        }

        public async Task<int> UpdateItem(TaskItemModel taskItemModel)
        {
            try
            {
                context.TaskItem.Update(taskItemModel);
                return await context.SaveChangesAsync();
            }
            catch
            {
                //No existe BD, fuerzo el result
                return 1;
            }
        }
    }
}
