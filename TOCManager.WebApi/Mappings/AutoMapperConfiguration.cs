using AutoMapper;

namespace TOCManager.WebApi.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<EntityToViewModelMappingProfile>();
            });
        }
    }
}