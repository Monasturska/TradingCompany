using DTO.Model;
using System.Collections.Generic;

namespace DataAccessLogic.Interfaces
{
    public interface IProductDAL
    {
        List<Product> GetProducts();
        void AddObj(Product tempObj);
        void DeleteObject(int id);
        void ReadFromDataBase();
        Product GetObj(int idT);
        int GetMostExpensiveObj();
        Product ChangeValueObj(int id, string newName);
    }
}