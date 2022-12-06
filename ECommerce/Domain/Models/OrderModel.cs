using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.Models
{
    internal class OrderModel
    {
        public Order Order { get; set; }

        public int OrdNo { get; set; }

        public decimal TotalPrice { get; set; }


        public OrderModel()
        {
            Order = new Order();
        }
    }
}
