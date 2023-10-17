using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DataAccessLogic.Interfaces;
using DTO.Model;

namespace DataAccessLogic.ADO
{
    public class ManagerDAL : IManagerDAL
    {

        List<Manager> managers;
        private string connectionStr;

        public ManagerDAL()
        {
            managers = new List<Manager>();
            connectionStr = "Data Source=DESKTOP-9IGAF08;Initial Catalog=ManagerSupplier;Integrated Security=True";
            ReadFromDataBase();
        }

        public void ReadFromDataBase()
        {
            managers.Clear();
            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select PersonId,PersonName,Salt,Password,Email," +
                            "RowInsertTime,RowUpdateTime from Manager";

                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Manager tempManager = new Manager();
                            tempManager.ID = (int)reader["PersonId"];
                            tempManager.Name = (string)reader["PersonName"];
                            //tempManager.Salt = (Guid)reader["Salt"];
                            //tempManager.Password = (byte[])reader["Password"];
                            tempManager.Email = (string)reader["Email"];
                            tempManager.TimeInsert = (DateTime)reader["RowInsertTime"];
                            tempManager.TimeUpdate = (DateTime)reader["RowInsertTime"];
                            managers.Add(tempManager);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }
        }

        public void AddObj(Manager tempObj)
        {
            managers.Add(tempObj);
            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Manager (PersonName,Salt,Password,Email,RowInsertTime,RowUpdateTime) " +
                        "values(@perName,@salt,@password,@email,@timeInsert,@timeUpdate)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@perName", tempObj.Name);
                    //comm.Parameters.AddWithValue("@salt", tempObj.Salt);
                    //comm.Parameters.AddWithValue("@password", tempObj.Password);
                    comm.Parameters.AddWithValue("@email", tempObj.Email);
                    comm.Parameters.AddWithValue("@timeInsert", tempObj.TimeInsert);
                    comm.Parameters.AddWithValue("@timeUpdate", tempObj.TimeUpdate);
                    comm.ExecuteNonQuery();
                }
            }
        }

        public void DeleteObject(int id)
        {
            var tempObj = managers.Where(x => x.ID == id).SingleOrDefault();

            managers.Remove(tempObj);
            if (tempObj != null)
            {

                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {

                        connectionSql.Open();
                        comm.CommandText = "delete from Manager where PersonId=@persId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@persId", tempObj.ID);
                        comm.ExecuteNonQuery();

                    }
                }

            }
        }

        public Manager GetObj(string idT)
        {
            var tempObj = managers.Where(x => x.Email == idT).SingleOrDefault();

            return tempObj;
        }

        public List<Manager> GetProducts()
        {
            return managers;
        }

        public List<Manager> GetProductsWithoutPassword()
        {
            List<Manager> curMannagers = new List<Manager>();

            foreach (var person in managers)
            {
                curMannagers.Add(person.CopyElem());
            }
            return curMannagers;
        }

        public Manager GetObjById(int id)
        {
            var tempObj = managers.Where(x => x.ID == id).SingleOrDefault();
            return tempObj;
        }

        
        
    }
}
