using ECommerce.Commands;
using ECommerce.DataAccess.SqlServer;
using ECommerce.Domain.Abstractions;
using ECommerce.Domain.Services;
using ECommerce.Domain.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    internal class AdminHomeViewModel : BaseViewModel
    {
        public RelayCommand ShowProductsCommand { get; set; }

        public RelayCommand ShowOrdersCommand { get; set; }

        private readonly IRepository<Product> _productRepo;
        private readonly ProductService _productService;
        private readonly OrderService _orderService;





        public AdminHomeViewModel()
        {
            _productRepo = new ProductRepository();
            _orderService = new OrderService();
            ShowProductsCommand = new RelayCommand(c =>
            {
                var view = new AdminWindow();
                var viewModel = new AdminViewModel();
                view.DataContext = viewModel;

                viewModel.AllProducts = _productRepo.GetAllData();

                view.ShowDialog();
            });

            ShowOrdersCommand = new RelayCommand(c =>
            {
                var view = new AdminShowOrderWindow();
                var viewModel = new AdminShowOrderViewModel();
                view.DataContext = viewModel;
                viewModel.AllOrders = _orderService.GetOrderModelData();

                view.ShowDialog();
            });


        }

    }
}
