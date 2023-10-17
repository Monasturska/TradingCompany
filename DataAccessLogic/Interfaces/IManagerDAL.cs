using DTO.Model;
using System.Collections.Generic;

namespace DataAccessLogic.Interfaces
{
    public interface IManagerDAL
    {
        List<Manager> GetProducts();
        List<Manager> GetProductsWithoutPassword();
        void AddObj(Manager tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Manager GetObj(string idT);

        //bool IsLogin(string email, string password);
        Manager GetObjById(int id);
    }
}
