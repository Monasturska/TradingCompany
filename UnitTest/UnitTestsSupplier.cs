using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTestsSupplier
    {


        ISupplierDAL products = new SupplierDAL("test");

         [TestMethod]
        public void TestMethod_AddNewValue()
        {

            Supplier tempSupplier = new Supplier();
            tempSupplier.Id = 1;
            string nameM = "MARIA";
            tempSupplier.NameSupplier = nameM;
            DateTime dateTime = new DateTime();
            tempSupplier.ArrivingTime = dateTime.Date;

            products.AddObj(tempSupplier);
            var tempObj = products.GetProducts().Find(x => x.NameSupplier == nameM);
            Assert.IsTrue(tempObj == tempSupplier);
        }
        //[TestMethod]
        public void TestMethod_RemoveValue()
        {

            Supplier tempSupplier = new Supplier();
            tempSupplier.Id = 3;
            string nameM = "YURA";
            tempSupplier.NameSupplier = nameM;
            DateTime dateTime = new DateTime();
            tempSupplier.ArrivingTime = dateTime.Date;

            var tempObj = products.GetProducts().Find(x => x.NameSupplier == nameM);
            products.DeleteObject(tempObj.Id, true);
            var tempObjDel = products.GetProducts().Find(x => x.NameSupplier == nameM);
            Assert.IsNull(tempObjDel);
        }
    }
}
