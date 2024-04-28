using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Infrastructure.Contracts
{
    public interface ITaskItemRepository
    {
        Task<TaskItemModel?> AddItem(TaskItemModel taskItemModel);
        Task<IEnumerable<TaskItemModel>> GetAllItems();
        Task<int> UpdateItem(TaskItemModel taskItemModel);
    }
}
