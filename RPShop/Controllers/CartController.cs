using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RPShop.Helpers;
using RPShop.Models;
using RPShop.Models.Entities;
using RPShop.Models.ViewModels;
using RPShop.Repository;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RPShop.Controllers
{
    public class CartController : Controller
    {
        //private readonly RPDbcontext context;
        private const string CartSession = "CartSession";
        private readonly IProductRepository productRepository;
        //private readonly IOderService oderService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IOrderRepository orderRepository;
        private readonly IOrderDetailRepository orderDetailRepository;

        public CartController(IProductRepository productRepository,
                                UserManager<ApplicationUser> userManager,
                                SignInManager<ApplicationUser> signInManager,
                                IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository)
        {
            //this.context = context;
            //this.oderService = oderService;
            this.productRepository = productRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.orderRepository = orderRepository;
            this.orderDetailRepository = orderDetailRepository;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            var model = new HomeViewModel();

            if (cart != null)
            {
                model.CartItems = cart;
            }
            else
            {
                model.CartItems = new List<CartItem>();
            }

            return View(model);
        }
        [AllowAnonymous]
        public IActionResult DeleteAll()
        {
            HttpContext.Session.SetObjectAsJson(CartSession, null);
            return RedirectToAction("Index", "Cart");
        }
        [AllowAnonymous]

        public ActionResult Delete(int id)
        {
            int index = isExisting(id);
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            cart.RemoveAt(index);
            HttpContext.Session.SetObjectAsJson(CartSession, cart);
            return RedirectToAction("Index");
        }
        private int isExisting(int id)
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            for (int i = 0; i < cart.Count; i++)
                if (cart[i].Product.Id == id)
                    return i;
            return -1;
        }
        [AllowAnonymous]
        [Route("Cart/AddItem/{productId}/{quantity}")]
        public JsonResult AddItem(int productId, int quantity)
        {
            var product = productRepository.Get(productId);

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            if (cart != null)
            {
                var list = cart;
                if (list.Exists(x => x.Product.Id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == productId)
                        {
                            item.Quantity += quantity;
                        }
                    }
                    HttpContext.Session.SetObjectAsJson(CartSession, cart);
                    return Json(cart.Count);
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.ProductId = product.Id;
                    item.Quantity = quantity;
                    cart.Add(item);
                    HttpContext.Session.SetObjectAsJson(CartSession, cart);
                    return Json(cart.Count);
                }
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.ProductId = product.Id;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                HttpContext.Session.SetObjectAsJson(CartSession, list);
                return Json(list.Count);
            }

        }
        [Route("Cart/ChangeItem/{productId}/{quantity}")]
        [AllowAnonymous]
        public JsonResult ChangeItem(int productId, int quantity)
        {
            var product = productRepository.GetProduct(productId);

            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            if (cart != null)
            {
                var list = cart;
                if (list.Exists(x => x.Product.Id == productId))
                {
                    foreach (var item in list)
                    {
                        if (item.Product.Id == productId)
                        {
                            item.Quantity = quantity;
                        }
                    }
                    HttpContext.Session.SetObjectAsJson(CartSession, cart);
                    return Json(cart);
                }
                else
                {
                    var item = new CartItem();
                    item.Product = product;
                    item.ProductId = product.Id;
                    item.Quantity = quantity;
                    cart.Add(item);
                    HttpContext.Session.SetObjectAsJson(CartSession, cart);
                    return Json(cart);
                }
            }
            else
            {
                var item = new CartItem();
                item.Product = product;
                item.ProductId = product.Id;
                item.Quantity = quantity;
                var list = new List<CartItem>();
                list.Add(item);
                HttpContext.Session.SetObjectAsJson(CartSession, list);
                return Json(list);
            }

        }
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Payment()
        {
            var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
            var model = new HomeViewModel();

            if (cart != null)
            {
                model.CartItems = cart;
            }

            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Payment(string shipName, string mobile, string address, string email)
        {
            var order = new OrderOnline();
            order.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy");
            order.ShipAddress = address;
            order.ShipPhoneNumber = mobile;
            order.ShipName = shipName;
            order.ShipEmail = email;
            order.CustomerId = (shipName + order.CreatedDate.ToString()).Substring(0, 6);
            order.Status = false;
            order.IsDelete = false;
            if (signInManager.IsSignedIn(User))
            {
                var user = await userManager.FindByNameAsync(email);
                order.ApplicationUser = user;
                order.ApplicationUserId = user.Id;
            }

            try
            {
                var id = orderRepository.CreateOrder(order);
                var cart = HttpContext.Session.GetObjectFromJson<List<CartItem>>(CartSession);
                var orderDetail = new OrderDetail();
                foreach (var item in cart)
                {
                    var _orderDetail = new OrderDetail();
                    orderDetail.ProductId = item.Product.Id;
                    orderDetail.Discount = item.Product.Discount;
                    orderDetail.OrderOnlineId = order.Id;
                    orderDetail.UnitPrice = item.Product.Price;
                    orderDetail.Quantity = item.Quantity;
                    orderDetailRepository.Insert(orderDetail);
                }
                DeleteAll();
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Something went wrong, try it later!");
                var error = "Too many failed login attempts. Please try again later.";
                return Json(String.Format("'Success':'false','Error':'{0}'", error));
            }
            return RedirectToAction("index", "cart");
        }
        [AllowAnonymous]
        public ActionResult Success()
        {
            return View();
        }
    }
}
