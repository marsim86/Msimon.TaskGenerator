using Msimon.TaskGenerator.Infrastructure.Contracts.Model;
using Msimon.TaskGenerator.Library.Impl.Model;

namespace Msimon.TaskGenerator.Library.Impl.Mappers.Profile
{
    public class TaskItemModelProfile : AutoMapper.Profile
    {
        public TaskItemModelProfile()
        {
            CreateMap<TaskItem, TaskItemModel>();
            CreateMap<TaskItemModel, TaskItem>();
        }
    }
}
