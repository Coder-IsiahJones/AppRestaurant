using AppRestaurant.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AppRestaurant.Repositories
{
    public class ItemRepository
    {
        private readonly RestaurantDbEntities db;

        public ItemRepository()
        {
            db = new RestaurantDbEntities();
        }

        public IEnumerable<SelectListItem> GetAllItems()
        {
            var objSelectListItems = new List<SelectListItem>();

            objSelectListItems = (from obj in db.Items
                                  select new SelectListItem()
                                  {
                                      Text = obj.ItemName,
                                      Value = obj.ItemId.ToString(),
                                      Selected = true
                                  }).ToList();
            return objSelectListItems;
        }
    }
}