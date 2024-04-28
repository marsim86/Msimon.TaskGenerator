using AutoMapper;
using Msimon.TaskGenerator.Library.Impl.Mappers.Profile;

namespace Msimon.TaskGenerator.Library.Impl.Mappers.Extension
{
    public static class AutoMapperLibraryExtension
    {
        static AutoMapperLibraryExtension()
        {
            Mapper = new MapperConfiguration
                (cfg =>
                {
                    cfg.AddProfile<TaskItemDtoProfile>();
                    cfg.AddProfile<TaskItemModelProfile>();
                })
                .CreateMapper();
        }

        public static T MapToDto<T>(this object model) where T : class
        {
            return Mapper.Map<T>(model);
        }
        public static T MapToModel<T>(this object entity) where T : class
        {
            return Mapper.Map<T>(entity);
        }
        
        internal static IMapper Mapper { get; }

       
    }
}