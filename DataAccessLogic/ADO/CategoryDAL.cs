using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLogic.ADO
{
    public class CategoryDAL : ICategoryDAL
    {
        List<Category> categories;
        private string connectionStr;
        List<Product> product;
        public CategoryDAL(string test1 = "")
        {
            categories = new List<Category>();
            product = new List<Product>();
            if (test1 == "test")
            {
                connectionStr = "Data Source=DESKTOP-9IGAF08;Initial Catalog=UTestManagerSupplier;Integrated Security=True";
            }
            else
            {
                connectionStr = "Data Source=DESKTOP-9IGAF08;Initial Catalog=ManagerSupplier;Integrated Security=True";
            }
            ReadFromDataBase();
        }
        public void ReadFromDataBase()
        {
            categories.Clear();

            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select CategoryId,CategoryName,IsBlocked,RowInsertTime,RowUpdateTime from Category";

                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Category tempCategory = new Category();
                            tempCategory.IDCat = (int)reader["CategoryId"];
                            tempCategory.TypeProduct = (string)reader["CategoryName"];
                            tempCategory.IsBlocked = (bool)reader["IsBlocked"];
                            var timeInsert = reader["RowInsertTime"];
                            tempCategory.RowInsertTime = (DateTime)timeInsert;
                            var timeUpdate = reader["RowInsertTime"];
                            tempCategory.RowUpdateTime = (DateTime)timeUpdate;
                            categories.Add(tempCategory);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
        }
        public void AddObj(Category tempObj)
        {
            categories.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Category (CategoryName,IsBlocked,RowInsertTime,RowUpdateTime) " +
                        "values(@categoryName,@block,@timeInsert,@timeUpdate)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@categoryName", tempObj.TypeProduct);
                    comm.Parameters.AddWithValue("@block", tempObj.IsBlocked);
                    comm.Parameters.AddWithValue("@timeInsert", tempObj.RowInsertTime);
                    comm.Parameters.AddWithValue("@timeUpdate", tempObj.RowUpdateTime);
                    comm.ExecuteNonQuery();
                }
            }
        }
        public void DeleteObject(int id, bool op)
        {
            var tempObj = categories.Where(x => x.IDCat == id).SingleOrDefault();
            bool option = !(op);
            if (tempObj != null)
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();

                        comm.CommandText = "update Category set IsBlocked=@option where CategoryId=@categId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@option", option);
                        comm.Parameters.AddWithValue("@categId", tempObj.IDCat);
                        comm.ExecuteNonQuery();
                    }
                }
            }
            foreach (var cat in categories)
            {
                if (id == cat.IDCat)
                {
                    cat.ChangeBlockValue(option);
                }
            }
        }
        public List<Category> GetProducts()
        {
            return categories;
        }

        public Category GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < categories.Count; i++)
            {
                if (categories[i].IDCat == idT)
                {
                    index = i;
                }
            }
            return categories[index];
        }
        public Category ChangeValueObj(int id, string newName)
        {
            var tempObj = categories.Where(x => x.IDCat == id).SingleOrDefault();
            foreach (var cat in categories)
            {
                if (id == cat.IDCat)
                {
                    cat.ChangeObjName(newName);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Category set CategoryName=@newNameTemp, RowUpdateTime=@timeUpdate where CategoryId=@categorId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@timeUpdate", DateTime.Now);
                    comm.Parameters.AddWithValue("@categorId", tempObj.IDCat);
                    int row = comm.ExecuteNonQuery();
                }
            }
            return tempObj;
        }

        public List<Category> GetCategoriesBlocked()
        {
            List<Category> categoriesBocked = new List<Category>();
            foreach (Category cat in categories)
            {
                if (cat.IsBlocked == true)
                {
                    categoriesBocked.Add(cat);
                }
            }
            return categoriesBocked;
        }
    }
}
