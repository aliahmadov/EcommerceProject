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
using System.Windows;

namespace ECommerce.Domain.ViewModels
{
    internal class AdminViewModel : BaseViewModel
    {

        private readonly IRepository<Product> _productRepo;

        private ObservableCollection<Product> allProducts;

        public ObservableCollection<Product> AllProducts
        {
            get { return allProducts; }
            set { allProducts = value; OnPropertyChanged(); }
        }


        private Product selectedProduct;

        public Product SelectedProduct
        {
            get { return selectedProduct; }
            set { selectedProduct = value; OnPropertyChanged(); }
        }


        public RelayCommand AddProductCommand { get; set; }
        public RelayCommand UpdateProductCommand { get; set; }


        public AdminViewModel()
        {
            _productRepo = new ProductRepository();
            AddProductCommand = new RelayCommand(c =>
            {
                var view = new InsertWindow();
                var viewModel = new AddProductViewModel();
                view.DataContext = viewModel;

                view.ShowDialog();
                if (viewModel.Product != null)
                {
                    var products = _productRepo.GetAllData();
                    if (products != null)
                    {
                        viewModel.Product.Id = products.Skip(products.Count() - 1).First().Id;
                        _productRepo.AddData(viewModel.Product);
                        AllProducts = _productRepo.GetAllData();
                        MessageBox.Show($"{viewModel.Product.Name} with ID {viewModel.Product.Id} has been added successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Something wrong, check inputs");
                }
            });


            UpdateProductCommand = new RelayCommand(c =>
            {
                var view = new UpdateWindow();
                var viewModel = new AdminUpdateViewModel();
                view.DataContext = viewModel;


                if (SelectedProduct != null)
                {
                    string oldName = SelectedProduct.Name;
                    viewModel.Product = SelectedProduct;
                    view.ShowDialog();
                    if (viewModel.Product != null)
                    {
                        _productRepo.UpdateData(viewModel.Product);
                        AllProducts = _productRepo.GetAllData();
                        MessageBox.Show($"{oldName} with ID {viewModel.Product.Id} has been updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("No product has been selected");
                }
            });
        }

    }
}
