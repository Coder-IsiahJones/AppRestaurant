using AppRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppRestaurant.Repositories
{
    public class PaymentTypeRepository
    {
        private readonly RestaurantDbEntities db;

        public PaymentTypeRepository()
        {
            db = new RestaurantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAllPaymentTypes()
        {
            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in db.PaymentTypes
                                  select new SelectListItem()
                                  {
                                      Text = obj.PaymentTypeName,
                                      Value = obj.PaymentTypeId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}