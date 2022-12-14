using ECommerce.DataAccess.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Domain.ViewModels
{
    internal class AddProductViewModel:BaseViewModel
    {
        private Product product;

        public Product Product
        {
            get { return product; }
            set { product = value;OnPropertyChanged(); }
        }

        public AddProductViewModel()
        {
            Product = new Product();
        }

    }
}
