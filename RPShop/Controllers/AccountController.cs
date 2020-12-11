using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Internal;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RPShop.Controllers
{
    [Authorize(Roles = "System Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IWebHostEnvironment webHostEnvironment,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.webHostEnvironment = webHostEnvironment;
            this.roleManager = roleManager;
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginView model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    userName: model.Email,
                    password: model.Password,
                    isPersistent: model.RememberMe,
                    lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    return RedirectToAction("List", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attemp");
                    if (!string.IsNullOrEmpty(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Register(RegisterView model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    Email = model.Email,
                    UserName = model.Email,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Address = model.Address,
                    DoB = model.DoB,
                    PhoneNumber = model.PhoneNumber,
                    Company = model.Company,
                    Facebook = model.Facebook
                };
                var fileName = string.Empty;
                if (model.Image != null)
                {
                    string uploadFolder = Path.Combine(webHostEnvironment.WebRootPath, "images/Avatar");
                    fileName = $"{Guid.NewGuid()}_{model.Image.FileName}";
                    var filePath = Path.Combine(uploadFolder, fileName);
                    using (var fs = new FileStream(filePath, FileMode.Create))
                    {
                        model.Image.CopyTo(fs);
                    }
                }
                else
                {
                    fileName = "avatar1.png";
                }
                user.ImagePath = fileName;
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("List", "Product");
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Detail(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(user != null)
            {
                var result = new User()
                {
                    Address = user.Address,
                    Email = user.Email,
                    FullName = user.FullName,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    AvatarPath = user.ImagePath
                };
                return View(result);
            }
            return View();
        }
        [HttpGet("/Account/Edit/{Id}")]
        public async Task<IActionResult> Edit(string Id)
        {

            var user = await userManager.FindByIdAsync(Id);
            if (user != null)
            {
                var result = new User()
                {
                    Address = user.Address,
                    Email = user.Email,
                    FullName = user.FullName,
                    Id = user.Id,
                    PhoneNumber = user.PhoneNumber,
                    UserName = user.UserName,
                    AvatarPath = user.ImagePath
                };
                var roleName = await userManager.GetRolesAsync(user);
                if(roleName !=null && roleName.Any())
                {
                    var role = await roleManager.FindByNameAsync(roleName.FirstOrDefault());
                    result.RoleId = role.Id;
                }
                ViewBag.Roles = roleManager.Roles;
                return View(result);
            }
            ViewBag.Roles = roleManager.Roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(User model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.FullName = model.FullName;
                    user.Id = model.Id;
                    user.PhoneNumber = model.PhoneNumber;
                    user.UserName = model.UserName;
                    user.ImagePath = model.AvatarPath;

                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var rolesName = await userManager.GetRolesAsync(user);
                        if (!string.IsNullOrEmpty(model.RoleId))
                        {
                            var role = await roleManager.FindByIdAsync(model.RoleId);
                            var add = await userManager.AddToRoleAsync(user, role.Name);
                            if (add.Succeeded)
                            {
                                return RedirectToAction("List", "Account");
                            }
                            foreach(var error in add.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                        
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            var user = userManager.Users;
            if(user!=null && user.Any())
            {
                var model = new List<User>();
                model = user.Select(u => new User()
                {
                    Address = u.Address,
                    Email = u.Email,
                    Id = u.Id,
                    UserName = u.UserName,
                }).ToList();
                foreach(var user1 in model)
                {
                    user1.RoleName = GetRolesName(user1.Id);
                }
                return View(model);
            }
            return View();
        }
        public string GetRolesName (string userId)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(userId)).Result;
            var roles = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(", ", roles) : string.Empty;
        }

    }
}
