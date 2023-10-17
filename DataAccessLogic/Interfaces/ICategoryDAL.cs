using DTO.Model;
using System.Collections.Generic;

namespace DataAccessLogic.Interfaces
{
    public interface ICategoryDAL
    {
        List<Category> GetProducts();
        List<Category> GetCategoriesBlocked();
        void AddObj(Category tempObj);
        void DeleteObject(int id, bool op);
        void ReadFromDataBase();
        Category GetObj(int idT);
        Category ChangeValueObj(int id, string newName);
    }
}
