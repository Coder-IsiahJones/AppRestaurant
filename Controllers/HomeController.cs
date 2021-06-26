using AppRestaurant.Models;
using AppRestaurant.Repositories;
using AppRestaurant.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly RestaurantDbEntities db;

        public HomeController()
        {
            db = new RestaurantDbEntities();
        }

        public ActionResult Index()
        {
            CustomerRepository objCustomerRepository = new CustomerRepository();
            ItemRepository objItemRepository = new ItemRepository();
            PaymentTypeRepository objPaymentTypeRepository = new PaymentTypeRepository();

            var objMultipleModels =
                new Tuple<IEnumerable<SelectListItem>, IEnumerable<SelectListItem>, IEnumerable<SelectListItem>>
                (
                 objCustomerRepository.GetAllCustomers(),
                 objItemRepository.GetAllItems(),
                 objPaymentTypeRepository.GetAllPaymentTypes()
                 );

            return View(objMultipleModels);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet]
        public JsonResult GetItemUnitPrice(int itemId)
        {
            decimal UnitPrice = db.Items.Single(model => model.ItemId == itemId).ItemPrice;

            return Json(UnitPrice, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Index(OrderViewModel objOrderViewModel)
        {
            OrderRepository objOrderRepository = new OrderRepository();

            objOrderRepository.AddOrder(objOrderViewModel);

            return Json("Order has been Successfully Placed.", JsonRequestBehavior.AllowGet);
        }
    }
}