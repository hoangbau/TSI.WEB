using System.Net;
using System.Web.Mvc;
using TSI.BU.Services.Interfaces;
using TSI.BU.ViewModels.Requests;
using TSI.BU.ViewModels.Responses;

namespace TSI.WEB.Areas.Admin.Controllers
{
    public class InstroductionController : Controller
    {
        private readonly IInstroductionService _instroductionService;

        public InstroductionController(IInstroductionService instroductionService)
        {
            _instroductionService = instroductionService;
        }
        // GET: Admin/ManageInstroduction
        public ActionResult Index()
        {
            var instroudctions = _instroductionService.GetInstroductions();
            return View(instroudctions);
        }

        public ActionResult Create()
        {
            var instroduction = new InstroductionRequest();
            return View("Create", instroduction);
        }

        public ActionResult Update(int id)
        {
            var instroduction = _instroductionService.GetInstroduction(id);

            if(instroduction == null)
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            var updateInstroduction = new InstroductionResponse
            {
                Id = id,
                Description = instroduction.Description,
                CreateBy = instroduction.CreateBy,
                CreateDate = instroduction.CreateDate,
                Name = instroduction.Name
            };
            return View("Update", updateInstroduction);
        }

        [HttpPost]
        public ActionResult CreateInstroduction(InstroductionRequest request)
        {
            if(!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = _instroductionService.CreateInstroduction(request);

            if (!result)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return RedirectToAction("Index", "Instroduction");
        }

        [HttpPost]
        public ActionResult UpdateInstroduction(InstroductionRequest request)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var result = _instroductionService.UpdateInstroduction(request);

            if (!result)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return RedirectToAction("Index", "Instroduction");
        }


        public ActionResult DeleteInstroduction(int id)
        {
            var result = _instroductionService.DeleteInstroduction(id);

            if (!result)
                return new HttpStatusCodeResult(HttpStatusCode.InternalServerError);

            return RedirectToAction("Index", "Instroduction");
        }
    }
}