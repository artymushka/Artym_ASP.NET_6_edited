using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult HomePage()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitOrder(User user)
        {
            if (user.Age >= 16)
            {
                TempData["Quantity"] = user.Age;
                return RedirectToAction("ProductOrder");
            }
            else
            {
                return Content("Вибачте, ви повинні бути старші за 16 років для замовлення товарів.");
            }
        }

        [HttpGet]
        public IActionResult ProductOrder()
        {
            if (TempData["Quantity"] == null)
            {
                return RedirectToAction("HomePage");
            }
            ViewBag.Quantity = TempData["Quantity"];
            return View(); 
        }


        [HttpPost]
        public IActionResult ConfirmOrder(Product product)
        {
            // Обработка заказа товара
            return View("ConfirmationPage", product);
        }
    }
}

















