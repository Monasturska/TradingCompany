using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    [TestClass]
    public class UnitTestCategory
    {
        
        ICategoryDAL products = new CategoryDAL("test");


        [TestMethod]
        public void TestMethod_AddNewValue()
        {

            Category temp = new Category();
            string nameM = "fruit2";
            temp.TypeProduct = nameM;

            products.AddObj(temp);
            var tempObj = products.GetProducts().Find(x => x.TypeProduct == nameM);
            Assert.IsNotNull(tempObj);
        }

        [TestMethod]
        public void TestMethod_RemoveValue()
        {
            Category temp = new Category();
            string nameM = "sweets";
            temp.TypeProduct = nameM;

            var tempObj = products.GetProducts().Find(x => x.TypeProduct == nameM);
            products.DeleteObject(tempObj.IDCat, true);
            var tempObjDel = products.GetProducts().Find(x => x.TypeProduct == nameM);
            Assert.IsNull(tempObjDel);
        }
        [TestMethod]
        public void TestMethod_GetObject()
        {
            Category temp = new Category();
            string nameM = "daily product";
            temp.TypeProduct = nameM;
            temp.IDCat = 1;//current

            Category exepObj = products.GetObj(temp.IDCat);
            Assert.AreEqual(exepObj.IDCat, temp.IDCat);
        }
    }

}