using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServiceManager.IServise
{
    public interface IServiceSupplier
    {
        List<Supplier> GetProducts();
        void AddObj(Supplier tempObj);
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        Supplier GetObj(int idT);
        Supplier ChangeValueObj(int id, string newName);
    }
}
