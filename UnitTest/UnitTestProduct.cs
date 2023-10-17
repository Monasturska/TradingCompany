using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;
using DTO.Model;


namespace UnitTest
{
    [TestClass]
    public class UnitTestProduct
    {
        IProductDAL products = new ProductDAL("test");

         [TestMethod]
        public void TestMethod_MostExpensiveProduct()
        {
            int currentIdProduct = products.GetMostExpensiveObj();
            int exeptedIdProduct = 1;

            //assert
            Assert.AreEqual(currentIdProduct, exeptedIdProduct);

        }

         [TestMethod]
        public void TestMethod_AddNewValue()
        {

            Product temp = new Product();
            string nameM = "Pork";
            temp.NameObj = nameM;
            temp.CategoryID = 2;
            temp.PriceIn = 190;
            temp.PriceOut = 130;

            products.AddObj(temp);
            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsNotNull(tempObj);
        }
         [TestMethod]
        public void TestMethod_RemoveValue()
        {
            Product temp = new Product();
            string nameM = "ckolate";
            temp.NameObj = nameM;
            temp.CategoryID = 2;
            temp.PriceIn = 12;
            temp.PriceOut = 15;
            products.AddObj(temp);

            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            products.DeleteObject(tempObj.Id);
            var tempObjDel = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsNull(tempObjDel);
        }
    }
}
