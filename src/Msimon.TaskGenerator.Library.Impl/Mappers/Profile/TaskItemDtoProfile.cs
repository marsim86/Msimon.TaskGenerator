using Msimon.TaskGenerator.Library.Contracts.Dto;
using Msimon.TaskGenerator.Library.Impl.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msimon.TaskGenerator.Library.Impl.Mappers.Profile
{
    public class TaskItemDtoProfile : AutoMapper.Profile
    {
        public TaskItemDtoProfile()
        {
            CreateMap<TaskItem, TaskItemRsDto>();
            CreateMap<TaskItemRqDto, TaskItem>();
        }
    }
}
