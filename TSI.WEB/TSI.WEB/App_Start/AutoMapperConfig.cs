using AutoMapper;

namespace TSI.WEB.App_Start
{
    public class AutoMapperConfig
    {
        public static void Configuration()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfiles>();
            });
        }
    }
}