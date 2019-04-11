using System.Collections.Generic;
using System.Linq;
using Domain.Models;
using EF;

namespace MVC.Helper
{
    public class DBHelper
    {
        public List<OrderDB> AddOrders(List<Order> orders)
        {
            List<OrderDB> addedOrders = new List<OrderDB>();
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var order in MapOrdersToOrdersDB(orders))
                {
                    addedOrders.Add(db.Orders.Add(order).Entity);
                }
                db.SaveChanges();
            }
            return addedOrders;
        }

        public void SetupOrders(List<OrderDB> orders)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                foreach (var order in orders)
                {
                    OrderDB temp = db.Orders.First(o => o.Id == order.Id);
                    temp.Status = order.Status;
                    temp.InvoiceNumber = order.InvoiceNumber;
                    db.Orders.Update(temp);
                    db.SaveChanges();
                }
            }
        }

        private List<OrderDB> MapOrdersToOrdersDB(List<Order> orders)
        {
            List<OrderDB> ordersDB = new List<OrderDB>();
            foreach (var order in orders)
            {
                OrderDB orderDB = new OrderDB()
                {
                    BillingAddress = order.BillingAddress,
                    OrderDate = order.OrderDate,
                    OxId = order.OxId,
                    Status = order.Status,
                    Articles = order.Articles.ToList(),
                    Payments = order.Payments.ToList(),
                    InvoiceNumber = order.InvoiceNumber,
                };
                ordersDB.Add(orderDB);
            }
            return ordersDB;
        }

        public List<OrderDB> GetAllOrder()
        {
            List<OrderDB> allOrders;
            using (ApplicationContext db = new ApplicationContext())
            {
                allOrders = db.Orders.ToList();
            }
            return allOrders;
        }

        public List<OrderArticle> GetArticlesByOrderId(int id)
        {
            List<OrderArticle> orderArticles;
            using (ApplicationContext db = new ApplicationContext())
            {
                orderArticles = db.Articles.Where(o => o.OrderDBId == id).ToList();
            }
            return orderArticles;
        }
    }
}
