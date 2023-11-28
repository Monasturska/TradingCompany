using BLLServiceManager.Servise;
using DTO.Model;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestManagerBLL
{
    [TestFixture]
    internal class CategoryServiceTest
    {
        private ServiceCategory _serviceCategory;
        private Mock<ICategoryDAL> _category;

        [SetUp]
        public void Setup()
        {
            _category = new Mock<ICategoryDAL>(MockBehavior.Strict);
            _serviceCategory = new ServiceCategory(_category.Object);
        }

        [Test]
        public void GetCategories_List_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            List<Category> categoryCurrentArr = new List<Category>()
            {
                new Category{IDCat=5,TypeProduct="something",IsBlocked=false,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate},
                new Category{IDCat=6,TypeProduct="new prod",IsBlocked=false,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate}
            };
            List<Category> categoryResultArr = new List<Category>()
            {
                new Category{IDCat=5,TypeProduct="something",IsBlocked=false,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate},
                new Category{IDCat=6,TypeProduct="new prod",IsBlocked=false,RowInsertTime=timeInsert,RowUpdateTime=timeUpdate}
            };
            _category.Setup(category => category.GetProducts()).Returns(categoryCurrentArr);
            //Act
            List<Category> resultArr = _serviceCategory.GetProducts();
            bool isEqual = ClassHelper.AreEqualListCategory(categoryResultArr, resultArr);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }

        [Test]
        public void GetCategory_IntIn_Category_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Category categoryCurrent = new Category { IDCat = 5, TypeProduct = "something", IsBlocked = false, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            Category categoryResult = new Category { IDCat = 5, TypeProduct = "something", IsBlocked = false, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            _category.Setup(category => category.GetObj(5)).Returns(categoryCurrent);
            //Act
            Category resultItem = _serviceCategory.GetObj(5);
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
        [Test]
        public void GetCategory_IntString_ReturnCategory_AreEqual()
        {
            DateTime timeUpdate = DateTime.Now;
            DateTime timeInsert = DateTime.Now;
            //Arrange
            Category categoryCurrent = new Category { IDCat = 5, TypeProduct = "something", IsBlocked = false, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            Category categoryResult = new Category { IDCat = 5, TypeProduct = "something", IsBlocked = false, RowInsertTime = timeInsert, RowUpdateTime = timeUpdate };
            _category.Setup(category => category.ChangeValueObj(5, "newvalue")).Returns(categoryCurrent);
            //Act
            Category resultItem = _serviceCategory.ChangeValueObj(5, "newvalue");
            bool isEqual = resultItem.Equals(categoryResult);
            //Assert
            NUnit.Framework.Assert.IsTrue(isEqual);
        }
    }
}
