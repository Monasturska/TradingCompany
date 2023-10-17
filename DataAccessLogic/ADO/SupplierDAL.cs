using DataAccessLogic.Interfaces;
using DTO.Model;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccessLogic.ADO
{
    public class SupplierDAL : ISupplierDAL
    {
        List<Supplier> suppliers;
        private string connectionStr;
        List<Category> categories;

        public SupplierDAL(string test1 = "")
        {
            suppliers = new List<Supplier>();
            categories = new List<Category>();

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
            suppliers.Clear();
            try
            {
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();
                        comm.CommandText = "select SupplierId, SupplierName, ArrivingTime, RowUpdateTime, IsBlocked from Supplier";


                        SqlDataReader reader = comm.ExecuteReader();
                        while (reader.Read())
                        {
                            Supplier tempSupplier = new Supplier();
                            tempSupplier.Id = (int)reader["SupplierId"];
                            tempSupplier.NameSupplier = (string)reader["SupplierName"];
                            
                            tempSupplier.ArrivingTime = Convert.ToDateTime(reader["ArrivingTime"]);
                            tempSupplier.RowUpdateTime = (DateTime)reader["RowUpdateTime"];
                            
                            suppliers.Add(tempSupplier);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error during read from databased: {ex.Message}");
            }

        }
        public void AddObj(Supplier tempObj)
        {
            suppliers.Add(tempObj);

            using (SqlConnection connectionSql = new SqlConnection(connectionStr))
            {
                using (SqlCommand comm = connectionSql.CreateCommand())
                {
                    connectionSql.Open();
                    comm.CommandText = "insert into Supplier (SupplierName,ArrivingTime,RowUpdateTime, IsBlocked) " +
                      "values(@supplierName,@dataArriving,@timeUpdate,@block)";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@supplierName", tempObj.NameSupplier);
                    
                    comm.Parameters.AddWithValue("@dataArriving", tempObj.ArrivingTime);
                    comm.Parameters.AddWithValue("@timeUpdate", tempObj.RowUpdateTime);
                    comm.Parameters.AddWithValue("@block", tempObj.IsBlocked);
                    //int rowAffected = comm.ExecuteNonQuery();
                    comm.ExecuteNonQuery();


                }
            }
        }
        public void DeleteObject(int id, bool op)
        {

            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            bool option = !(op);
            if (tempObj != null)
            {
                //suppliers.Remove(tempObj);
                using (SqlConnection connectionSql = new SqlConnection(connectionStr))
                {
                    using (SqlCommand comm = connectionSql.CreateCommand())
                    {
                        connectionSql.Open();

                        comm.CommandText = "update Supplier set IsBlocked = @option where SupplierId = @supplierId";
                        comm.Parameters.Clear();
                        comm.Parameters.AddWithValue("@option", option);
                        comm.Parameters.AddWithValue("@supplierId", tempObj.Id);
                        //int rowAffected = comm.ExecuteNonQuery();
                        comm.ExecuteNonQuery();

                    }
                }
            }
            foreach (var s in suppliers)
            {
                if (id == s.Id)
                {
                    s.ChangeBlockValue(option);
                }
            }

        }

        public List<Supplier> GetProducts()
        {
            return suppliers;
        }
        public Supplier GetObj(int idT)
        {
            int index = -1;
            for (int i = 0; i < suppliers.Count; i++)
            {
                if (suppliers[i].Id == idT)
                {
                    index = i;
                }
            }
            //index -= 1;
            return suppliers[index];
        }


        public Supplier ChangeValueObj(int id, string newName)
        {
            var tempObj = suppliers.Where(x => x.Id == id).SingleOrDefault();
            foreach (var cat in suppliers)
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
                    comm.CommandText = "update Supplier set SupplierName=@newNameTemp, RowUpdateTime=@newTime where SupplierId=@suplId";
                    comm.Parameters.Clear();
                    comm.Parameters.AddWithValue("@newNameTemp", newName);
                    comm.Parameters.AddWithValue("@newTime", DateTime.Now);
                    comm.Parameters.AddWithValue("@suplId", tempObj.Id);
                    int row = comm.ExecuteNonQuery();

                }
            }
            return tempObj;
        }

        public List<Supplier> GetSuppliersBlocked()
        {
            List<Supplier> suppliersesBocked = new List<Supplier>();
            foreach (Supplier s in suppliers)
            {
                if (s.IsBlocked == true)
                {
                    suppliersesBocked.Add(s);
                }
            }
            return suppliersesBocked;
        }
    }
}

