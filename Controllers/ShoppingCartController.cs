using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using seafood_version_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeafoodV4.Controllers
{
    public class ShoppingCartController : Controller
    {
        SeafoodContext db = new SeafoodContext();

        // Key lưu chuỗi json của Cart
        public const string CARTKEY = "cart";

        // Lấy cart từ Session (danh sách CartItem)
        public Cart GetCart()
        {
            var session = HttpContext.Session;
            string jsoncart = session.GetString(CARTKEY);
            if (jsoncart != null)
            {
                return JsonConvert.DeserializeObject<Cart>(jsoncart);
            }
            Cart cart = new Cart();
            SaveCartSession(cart);
            return cart;
        }
        void ClearCart()
        {
            var session = HttpContext.Session;
            session.Remove(CARTKEY);
        }

        // Lưu Cart (Danh sách CartItem) vào session
        void SaveCartSession(Cart cart)
        {
            var session = HttpContext.Session;
            String jsoncart = JsonConvert.SerializeObject(cart);
            session.SetString(CARTKEY, jsoncart);
        }

        public IActionResult AddToCart(int id)
        {
            var pro = db.Products.SingleOrDefault(s => s.ProId == id);
            if (pro != null)
            {
                var cart = GetCart();
                var item = cart.Items.FirstOrDefault(s => s.shopping_product.ProId == pro.ProId);
                if (item == null)
                {
                    cart.Items.Add(new CartItem
                    {
                        shopping_product = pro,
                        shopping_quantity = 1
                    });
                }
                else
                {
                    item.shopping_quantity++;
                }
                SaveCartSession(cart);
            }
            return RedirectToAction("ShowCart", "ShoppingCart");
        }


        [HttpPost]
        public IActionResult UpdateProduct(int ID_Product, int Quantity)

        {
            Cart cart = GetCart();
            var item = cart.Items.Find(s => s.shopping_product.ProId == ID_Product);
            if (item != null)
            {
                item.shopping_quantity = Quantity;
            }
            SaveCartSession(cart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        [Route("/removecart/{ProId:int}", Name = "removecart")]
        public IActionResult RemoveCart([FromRoute] int ProId)
        {
            var cart = GetCart();
            var item = cart.Items.Find(p => p.shopping_product.ProId == ProId);
            if (item != null)
            {
                cart.Items.Remove(item);
            }
            SaveCartSession(cart);
            return RedirectToAction("ShowCart", "ShoppingCart");
        }

        public IActionResult ShowCart()
        {
            Cart cart = GetCart();
            return View(cart);
        }

        public IActionResult Checkout()
        {
            try
            {
                Cart cart = GetCart();
                Order order = new Order();

            }
            catch (Exception)
            {

                throw;
            }
        }




       /* public IActionResult Checkout(FormCollection form)
        {
            try
            {
                Cart cart = GetCart();
                Order order = new Order();
                order.UserId = int.Parse(form["CodeCustomer"]);
            }
            catch (Exception)
            {

                throw;
            }
        }*/
    }
}
