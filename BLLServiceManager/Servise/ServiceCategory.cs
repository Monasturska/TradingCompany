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
    public class ServiceCategory : IServiceCategory
    {
        readonly private ICategoryDAL _categories;
        public ServiceCategory(ICategoryDAL categories)
        {
            _categories = categories;
        }
        public void AddObj(Category temp)
        {
            _categories.AddObj(temp);
        }
        public Category ChangeValueObj(int id, string name)
        {
            return _categories.ChangeValueObj(id, name);
        }
        public void DeleteObject(int id, bool op)
        {
            _categories.DeleteObject(id, op);
        }

        public List<Category> GetCategoriesBlocked()
        {
            return _categories.GetCategoriesBlocked();
        }

        public Category GetObj(int id)
        {
            return _categories.GetObj(id);
        }
        public List<Category> GetProducts()
        {
            return _categories.GetProducts();
        }
        public void ReadFromDataBase()
        {
            _categories.ReadFromDataBase();
        }
    }
}
