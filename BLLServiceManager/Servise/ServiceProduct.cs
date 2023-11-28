using BLLServiceManager.IServise;
using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServiceManager.Servise
{
    public class ServiceProduct : IServiceProduct
    {
        readonly private IProductDAL _products;

        public ServiceProduct(IProductDAL products)
        {
            _products = products;
        }
        public void AddObj(Product temp)
        {
            _products.AddObj(temp);
        }

        public Product ChangeValueObj(int id, string name)
        {
            return _products.ChangeValueObj(id, name);
        }

        public void DeleteObject(int id)
        {
            _products.DeleteObject(id);

        }

        public Product GetObj(int id)
        {
            return _products.GetObj(id);
        }

        public List<Product> GetProducts()
        {
            return _products.GetProducts();
        }

        public void ReadFromDataBase()
        {
            _products.ReadFromDataBase();
        }
    }
}
