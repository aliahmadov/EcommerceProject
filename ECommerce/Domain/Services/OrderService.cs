using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Services
{
    internal class OrderService
    {
        private readonly IRepository<Order> _orderRepo;
        private readonly  ECommerceDataClassesDataContext _dtx;


        public OrderService()
        {
            _orderRepo = new OrderRepository();
            _dtx = new ECommerceDataClassesDataContext();
        }

        public ObservableCollection<OrderModel> GetOrderModelData()
        {
            var orders = from o in _orderRepo.GetAllData()
                         select new OrderModel
                         {
                             Order=o,
                             TotalPrice=_dtx.Products.FirstOrDefault(d=>d.Id==o.ProductId).Price*o.Amount
                         };

            return new ObservableCollection<OrderModel>(orders);
        }
    }
}
