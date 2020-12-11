using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Services;

namespace RPShop.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentServices commentServices;
        private readonly UserManager<ApplicationUser> userManager;

        public CommentController(ICommentServices commentServices, UserManager<ApplicationUser> userManager)
        {
            this.commentServices = commentServices;
            this.userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpGet("/comment/show/{ProductId}")]
        public async Task<JsonResult> Show(int ProductId)
        {
            var result = await commentServices.Gets(ProductId);
            return Json(new { data = result });
        }
        [HttpPost]
        public JsonResult Post(Comment model)
        {
            var result = commentServices.Post(model);
            return Json(new { data = result });
        }
    }
}
