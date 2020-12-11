using Microsoft.AspNetCore.Mvc;
using RPShop.Models.Entities;
using RPShop.Services;

namespace RPShop.Controllers
{
    public class VoteController : Controller
    {
        private readonly ICommentServices commentServices;

        public VoteController(ICommentServices commentServices)
        {
            this.commentServices = commentServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult post(Vote model)
        {
            var result = commentServices.PostVote(model);
            return Json(new { data = result });
        }
    }
}
