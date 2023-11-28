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
            temp.Id = -1;
            
            temp.NameObj = "ch";
            temp.CategoryID = 2;
            temp.SupplierID = 1;
            temp.PriceIn = 100;
            temp.PriceOut = 130;
            temp.RowInsertTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;


            var nameM = temp.NameObj;
            products.AddObj(temp);
            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsTrue(nameM == tempObj.NameObj);
        }
         [TestMethod]
        public void TestMethod_RemoveValue()
        {
            Product temp = new Product();
            temp.Id = -1;

            temp.NameObj = "ch1";
           
            temp.CategoryID = 2;
            temp.SupplierID = 1;

            temp.PriceIn = 12;
            temp.PriceOut = 15;
            temp.RowInsertTime = DateTime.Now;
            temp.RowUpdateTime = DateTime.Now;
            products.AddObj(temp);

            var nameM = temp.NameObj;
            var tempObj = products.GetProducts().Find(x => x.NameObj == nameM);
            products.DeleteObject(tempObj.Id);
            var tempObjDel = products.GetProducts().Find(x => x.NameObj == nameM);
            Assert.IsNull(tempObjDel);
        }
    }
}
