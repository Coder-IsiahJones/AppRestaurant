using AppRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppRestaurant.Repositories
{
    public class CustomerRepository
    {
        private readonly RestaurantDbEntities db;

        public CustomerRepository()
        {
            db = new RestaurantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAllCustomers()
        {
            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in db.Customers
                                  select new SelectListItem()
                                  {
                                      Text = obj.CustomerName,
                                      Value = obj.CustomerId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}