using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLogic.ADO
{
    public class ProductDAL : IProductDAL
    {
        List<Product> products;
        private string connectionStr;

        public ProductDAL(string test1 = "")
        {
            products = new List<Product>();
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
            products.Clear();
            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select ProductId, ProductName, PriceIn, PriceOut," +
                          " CategoryId, SupplierId,RowInsertTime,RowUpdateTime from Product";


                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Product tempProduct = new Product();
                            tempProduct.Id = (int)reader["ProductId"];
                            tempProduct.NameObj = (string)reader["ProductName"];
                            tempProduct.PriceIn = (int)reader["PriceIn"]; ;
                            tempProduct.PriceOut = (int)reader["PriceOut"];
                            tempProduct.CategoryID = (int)reader["CategoryId"];
                            tempProduct.SupplierID = (int)reader["SupplierId"];
                            var timeInsert = reader["RowInsertTime"];
                            tempProduct.RowInsertTime = (DateTime)timeInsert;
                            var timeUpdate = reader["RowInsertTime"];
                            tempProduct.RowUpdateTime = (DateTime)timeUpdate;
                            products.Add(tempProduct);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
        }
        public List<Product> GetProducts()
        {
            return products;

        }
        public void AddObj(Product tempObj)
        {
            products.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Product(ProductName, PriceIn, PriceOut," +
                      " CategoryId, SupplierId, RowInsertTime,RowUpdateTime) values(@fname,@priceInn, @priceOutt, @categor,@supp,@timeInsert,@timeUpdate)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@fname", tempObj.NameObj);
                    comm.Parameters.AddWithValue("@priceInn", tempObj.PriceIn);
                    comm.Parameters.AddWithValue("@priceOutt", tempObj.PriceOut);
                    comm.Parameters.AddWithValue("@categor", tempObj.CategoryID);
                    comm.Parameters.AddWithValue("@supp", tempObj.SupplierID);
                    comm.Parameters.AddWithValue("@timeInsert", tempObj.RowInsertTime);
                    comm.Parameters.AddWithValue("@timeUpdate", tempObj.RowUpdateTime);
                    int rowAffected = comm.ExecuteNonQuery();
                }
            }
        }

        public void DeleteObject(int id)
        {
            var tempObj = products.Where(x => x.Id == id).SingleOrDefault();

            products.Remove(tempObj);
            if (tempObj != null)
            {

                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {

                        connectionSql.Open();
                        comm.CommandText = "delete from Product where ProductId=@productId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@productId", tempObj.Id);
                        comm.ExecuteNonQuery();

                    }
                }

            }
        }
        public int GetMostExpensiveObj()
        {
            int max = 0;
            int idExpPod = -1;
            foreach (var product in products)
            {
                if (max < product.PriceIn)
                {
                    max = product.PriceIn;
                    idExpPod = product.Id;
                }
            }
            return idExpPod;
        }
        public Product GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].Id == idT)
                {
                    index = i;
                }
            }
            return products[index];
        }

        public Product ChangeValueObj(int id, string newName)
        {
            var tempObj = products.Where(x => x.Id == id).SingleOrDefault();
            foreach (var cat in products)
            {
                if (id == cat.Id)
                {
                    cat.ChangeObjName(newName);
                }
            }
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "update Product set ProductName=@newNameTemp, RowUpdateTime=@timeUpdate where ProductId=@productId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@timeUpdate", DateTime.Now);
                    comm.Parameters.AddWithValue("@productId", tempObj.Id);
                    int row = comm.ExecuteNonQuery();
                }
            }
            return tempObj;

        }
    }
}

