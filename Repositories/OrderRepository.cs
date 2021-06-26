using AppRestaurant.Models;
using AppRestaurant.ViewModel;
using System;

namespace AppRestaurant.Repositories
{
    public class OrderRepository
    {
        private readonly RestaurantDbEntities db;

        public OrderRepository()
        {
            db = new RestaurantDbEntities();
        }

        public bool AddOrder(OrderViewModel objOrderViewModel)
        {
            Order objOrder = new Order();

            // Set
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.FinalTotal = objOrderViewModel.FinalTotal;
            objOrder.CustomerId = objOrderViewModel.CustomerId;
            objOrder.OrderDate = DateTime.Now;
            objOrder.OrderNumber = String.Format("{0:ddmmyyyyhhmmss}", DateTime.Now);
            objOrder.PaymentTypeId = objOrderViewModel.PaymentTypeId;

            // Save
            db.Orders.Add(objOrder);
            db.SaveChanges();

            int OrderId = objOrder.OrderId;

            foreach (var item in objOrderViewModel.ListOfOrderDetailViewModel)
            {
                OrderDetail objOrderDetail = new OrderDetail();

                // Set
                objOrderDetail.OrderId = OrderId;
                objOrderDetail.ItemId = item.ItemId;
                objOrderDetail.Discount = item.Discount;
                objOrderDetail.Total = item.Total;
                objOrderDetail.UnitPrice = item.UnitPrice;
                objOrderDetail.Quantity = item.UnitPrice;

                // Save
                db.OrderDetails.Add(objOrderDetail);
                db.SaveChanges();

                Transaction objTransaction = new Transaction();

                // Set
                objTransaction.ItemId = item.ItemId;
                objTransaction.Quantity = (-1) * item.Quantity;
                objTransaction.TransactionDate = DateTime.Now;

                // Save
                db.Transactions.Add(objTransaction);
                db.SaveChanges();
            }

            return true;
        }
    }
}