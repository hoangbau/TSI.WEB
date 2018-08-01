using AutoMapper;
using System.Collections.Generic;
using TSI.BU.ViewModels.Requests;
using TSI.BU.ViewModels.Responses;
using TSI.DAL.Models;

namespace TSI.BU.Extensions
{
    public static class MappingExtensions
    {
        public static List<InstroductionResponse> ConvertModelToResponses(this List<Instroductions> instroductions)
        {
            return Mapper.Map<List<Instroductions>, List<InstroductionResponse>>(instroductions);
        }

        public static InstroductionResponse ConvertModelToResponse(this Instroductions instroduction)
        {
            return Mapper.Map<Instroductions, InstroductionResponse>(instroduction);
        }

        public static Instroductions ConvertRequestToModel(this InstroductionRequest instroduction)
        {
            return Mapper.Map<InstroductionRequest, Instroductions>(instroduction);
        }
    }
}
