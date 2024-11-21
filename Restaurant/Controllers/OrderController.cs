using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Restaurant.Data;
using Restaurant.Data.Model;
using Restaurant.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Restaurant.Controllers
{
    public class OrderController : Controller
    {
        private ApplicationDbContext _db;

        public OrderController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.OrderDetails.Include(c => c.Order).Include(c => c.Product).ToList());
        
        }
        public IActionResult OrderDone()
        {
            return View();
        }
        
        public IActionResult Checkout()
        {
            return View();
        }

        //POST Checkout 

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Checkout(Order anOrder)
        {
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    OrderDetails orderDetails = new OrderDetails();
                    orderDetails.ProductId = product.Id;
                    anOrder.OrderDetails.Add(orderDetails);
                }
            }
           
            anOrder.OrderNo = GetOrderNo();
            anOrder.OrderPlaced = DateTime.Now;
            anOrder.OrderTotal = (double)GetTotalPrice();
            _db.Orders.Add(anOrder);
            await _db.SaveChangesAsync();
            TempData["save"] = "Поръчката е изпратена успешно!";
            HttpContext.Session.Set("products", new List<Product>());
            return RedirectToAction(nameof(OrderDone));
        }

        public string GetOrderNo()
        {
            int rowCount = _db.Orders.ToList().Count() + 1;
            return rowCount.ToString("000");
        }
        public decimal GetTotalPrice()
        {
            decimal totalPrice = 0;
            List<Product> products = HttpContext.Session.Get<List<Product>>("products");
            if (products != null)
            {
                foreach (var product in products)
                {
                    totalPrice += product.Price;
                }
            }

            return totalPrice;
        }
    }
}

