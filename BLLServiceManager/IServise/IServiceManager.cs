using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLLServiceManager.IServise
{
    public interface IServiceManager
    {
        List<Manager> GetProducts();
        List<Manager> GetProductsWithoutPassword();
        void AddObj(Manager tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Manager GetObj(string idT);
        Manager GetObjById(int id);
        bool IsLogin(string Email, string Password);
    }
}
