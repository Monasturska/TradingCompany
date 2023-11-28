using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLLServiceManager.IServise;
using DataAccessLogic.Interfaces;
using DTO.Model;

namespace BLLServiceManager.Servise
{
    public class ServiceSupplier : IServiceSupplier
    {
        readonly private ISupplierDAL _suppliers;
        public ServiceSupplier(ISupplierDAL suppliers)
        {
            _suppliers = suppliers;
        }
        public void AddObj(Supplier tempObj)
        {
            _suppliers.AddObj(tempObj);
        }

        public Supplier ChangeValueObj(int id, string newName)
        {
            return _suppliers.ChangeValueObj(id, newName);
        }

        public void DeleteObject(int id, bool op)
        {
            _suppliers.DeleteObject(id, op);
        }

        public Supplier GetObj(int idT)
        {
            return _suppliers.GetObj(idT);
        }

        public List<Supplier> GetProducts()
        {
            return _suppliers.GetProducts();
        }

        public void ReadFromDataBase()
        {
            _suppliers.ReadFromDataBase();
        }
    }
}
