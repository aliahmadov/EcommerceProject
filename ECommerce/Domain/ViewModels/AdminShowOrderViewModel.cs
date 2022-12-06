using ECommerce.Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    internal class AdminShowOrderViewModel:BaseViewModel
    {
        private ObservableCollection<OrderModel> orderModels;

        public ObservableCollection<OrderModel> AllOrders
        {
            get { return orderModels; }
            set { orderModels = value; OnPropertyChanged(); }
        }





    }
}
