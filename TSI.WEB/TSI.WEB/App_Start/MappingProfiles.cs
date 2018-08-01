using AutoMapper;
using TSI.BU.ViewModels.Requests;
using TSI.BU.ViewModels.Responses;
using TSI.DAL.Models;

namespace TSI.WEB.App_Start
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Instroductions, Instroductions>();
            CreateMap<InstroductionRequest, InstroductionResponse>();
        }
    }
}