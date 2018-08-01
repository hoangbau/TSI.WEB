using System;
using System.Collections.Generic;
using System.Linq;
using TSI.BU.Services.Interfaces;
using TSI.BU.ViewModels.Requests;
using TSI.BU.ViewModels.Responses;
using TSI.DAL.Models;
using TSI.DAL.Repositories;
using TSI.DAL.UnitOfWork;

namespace TSI.BU.Services.Implements
{
    public class InstroductionService : IInstroductionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IInstroductionRepository _instroductionRepository;

        public InstroductionService(IUnitOfWork unitOfWork, IInstroductionRepository instroductionRepository)
        {
            _unitOfWork = unitOfWork;
            _instroductionRepository = instroductionRepository;
        }
        public List<InstroductionResponse> GetInstroductions()
        {
            var query = _instroductionRepository.GetMany(inst => !inst.IsDeleted)
                         .Select(t => new InstroductionResponse
                {
                    Id = t.Id,
                    Name = t.Name,
                    Description = t.Description,
                    CreateBy = "HoangDT",
                    CreateDate = "2018-31-07"
                });

            var instroductions = query.ToList();

            return instroductions;
        }

        public InstroductionResponse GetInstroduction(int id)
        {
            var instroduction = _instroductionRepository.GetSingle(g => g.Id == id && !g.IsDeleted);
            var response = new InstroductionResponse
            {
                Name = instroduction.Name,
                Description = instroduction.Description
            };

            return response;
        }

        public bool CreateInstroduction(InstroductionRequest request)
        {
            if (request == null)
                return false;

            var newItem = new Instroductions
            {
                Name = request.Name,
                Description = request.Description,
                CreatedBy = 1,
                CreatedDate = DateTime.Now
        };
           
            _instroductionRepository.Add(newItem);

            return  _unitOfWork.Commit();
        }

        public bool UpdateInstroduction(InstroductionRequest request)
        {
            if (!request.Id.HasValue)
                return false;

            var update = _instroductionRepository.GetById(request.Id.Value);

            if (update == null)
                return false;

            update.Name = request.Name;
            update.Description = request.Description;
            update.ModifiedBy = 1;
            update.ModifiedDate = DateTime.Now;

            _instroductionRepository.Update(update);

            return _unitOfWork.Commit();
        }

        public bool DeleteInstroduction(int id)
        {

            var deleteItem = _instroductionRepository.GetById(id);

            if (deleteItem == null)
                return false;

            deleteItem.IsDeleted = true;
            deleteItem.DeletedBy = 1;
            deleteItem.DeletedDate = DateTime.Now;

            _instroductionRepository.Delete(deleteItem);

            return _unitOfWork.Commit();
        }
    }
}
