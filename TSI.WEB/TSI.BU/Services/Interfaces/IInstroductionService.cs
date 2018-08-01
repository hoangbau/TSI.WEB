using System.Collections.Generic;
using TSI.BU.ViewModels.Requests;
using TSI.BU.ViewModels.Responses;

namespace TSI.BU.Services.Interfaces
{
    public interface IInstroductionService
    {
        List<InstroductionResponse> GetInstroductions();
        InstroductionResponse GetInstroduction(int id);
        bool CreateInstroduction(InstroductionRequest request);
        bool UpdateInstroduction(InstroductionRequest request);
        bool DeleteInstroduction(int id);
    }
}
