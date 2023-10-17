using System;
using DTO.Model;
using DataAccessLogic.ADO;
using DataAccessLogic.Interfaces;

namespace TradingCompany.EditorHelper
{
    class Command
    {
        ICategoryDAL categories = null;
        ISupplierDAL suppliers = null;
        IProductDAL products = null;
        public Command()
        {
            categories = new CategoryDAL();
            suppliers = new SupplierDAL();
            products = new ProductDAL();
        }

        public void AddProductWithCategory()
        {
            Console.Write("\nChoose the id of category to add new  product after pressing enter:");
            int category = Convert.ToInt32(Console.ReadLine());
            bool optionCyc = true;
            do
            {
                try
                {
                    Product temp = new Product();
                    Console.Write("Input name of product: ");
                    string nameM = Console.ReadLine();
                    temp.NameObj = nameM;

                    Console.Write("Input priceIn: ");
                    string priceStr = Console.ReadLine();
                    temp.PriceIn = (Convert.ToInt32(priceStr));

                    Console.Write("Input priceout: ");
                    string priceStrOut = Console.ReadLine();
                    temp.PriceOut = (Convert.ToInt32(priceStrOut));
                    temp.RowInsertTime = DateTime.Now;
                    temp.RowUpdateTime = DateTime.Now;
                    Console.Write("Input the supplier of the product:");
                    int supplierTempId = Convert.ToInt32(Console.ReadLine());
                    bool isExistC = false;
                    bool isExistS = false;
                    foreach (Category categoryTemp in categories.GetProducts())
                    {
                        if (categoryTemp.IDCat == category)
                        {
                            isExistC = true;
                            temp.CategoryID = category;
                        }


                    }
                    foreach (var supplierTemp in suppliers.GetProducts())
                    {
                        if (supplierTemp.Id == supplierTempId)
                        {
                            isExistS = true;
                            temp.SupplierID = supplierTempId;
                        }
                    }
                    if (isExistS == true && isExistC == true)
                    {
                        products.AddObj(temp);
                        Console.WriteLine("sucessfully added a product!\n");
                        Console.ReadKey();
                    }
                    else if (isExistS == false && isExistC == true)
                    {
                        Console.WriteLine("There isn't the category to add product!\n");
                        Console.ReadKey();
                    }
                    else if (isExistS == true && isExistC == false)
                    {
                        Console.WriteLine("There isn't the supplier to add product!\n");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("There aren't the supplier and category to add product!\n");
                        Console.ReadKey();
                    }

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.WriteLine("\t\t\t\tError 404!\n\t\t\tIncorrect option!");
                    Console.ReadKey();

                }
                Console.WriteLine("\t\tTo add one more product to database please enter 'more'\n"
                                              + "\t\t   in another way enter 'nope': ");
                string answer = Console.ReadLine();

                if (answer == "more")
                {
                    optionCyc = true;
                }
                else { optionCyc = false; }
            } while (optionCyc);
            Console.ReadKey();

        }

        public void AddCategory()
        {
            Console.Write("\nInput new name for categories:");
            string categoryStr = Console.ReadLine();

            Category categoryTemp = new Category();
            categoryTemp.TypeProduct = categoryStr;
            //categoryTemp.IsBlocked = true;
            categoryTemp.RowInsertTime = DateTime.Now;
            categoryTemp.RowUpdateTime = DateTime.Now;
            categories.AddObj(categoryTemp);

            Console.WriteLine("sucessfully add the category!\n");
            Console.ReadKey();

        }

        public void AddSupplier()
        {
            Console.Write("\nInput new name of supplier:");
            string supplierName = Console.ReadLine();
            Supplier supplier = new Supplier();
            supplier.NameSupplier = supplierName;
            supplier.ArrivingTime = DateTime.Now;
            supplier.RowUpdateTime = DateTime.Now;
            suppliers.AddObj(supplier);

            Console.WriteLine("sucessfully add the supplier!\n");
            Console.ReadKey();

        }

        public void RemoveProduct()
        {

            Console.Write("\nInput the id to remove element:");
            int id = Convert.ToInt32(Console.ReadLine());
            products.DeleteObject(id);

            Console.WriteLine("sucessfully remove the product!\n");
            Console.ReadKey();

        }

        public void RemoveCategory()
        {
            Console.Write("\nInput the id to remove category of some product:");
            int id = Convert.ToInt32(Console.ReadLine());
            categories.DeleteObject(id, false);
            foreach (Product elem in products.GetProducts())
            {
                if (id == elem.CategoryID)
                {
                    elem.CategoryID = 5;
                }
            }
            Console.WriteLine("sucessfully remove the category!\n");
            Console.ReadKey();
        }

        public void RemoveSupplier()
        {

            Console.Write("\nInput the id to remove supplier:");
            int index = Convert.ToInt32(Console.ReadLine());
            suppliers.DeleteObject(index, false);
            
            foreach (Product elem in products.GetProducts())
            {
                if (index == elem.SupplierID)
                {
                    elem.SupplierID = 4;
                }
            }
            
            Console.WriteLine("sucessfully remove the supplier!\n");
            Console.ReadKey();
           

        }
        public void ShowTheMostExpensiveProduct()
        {
            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");

            Console.WriteLine(products.GetObj(products.GetMostExpensiveObj()).InfoString());
            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");
            Console.ReadKey();
        }

        public void EditNameCategory()
        {
            Console.Write("\nInput the id to edit category of some product:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new name of category to choosen one:");
            string name = Console.ReadLine();
            categories.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the category!\n");
            Console.ReadKey();
        }
        public void EditNameProduct()
        {
            Console.Write("\nInput the id to edit name of one product:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new name to one choosen product:");
            string name = Console.ReadLine();
            products.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the product!\n");
            Console.ReadKey();
        }
        public void EditNameSupplier()
        {
            Console.Write("\nInput the id to edit the name of supplier:");
            int index = Convert.ToInt32(Console.ReadLine());

            Console.Write("\nInput new person's name:");
            string name = Console.ReadLine();
            suppliers.ChangeValueObj(index, name);

            Console.WriteLine("sucessfully change name of the suppplier!\n");
            Console.ReadKey();
        }

        public void WriteOneCategoryTypeProduct()
        {
            Console.Write("\nChoose the id of category to show all product of it:");
            int idCat = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("---------------------------------------------"
                      + "----------------------------------------------"
                      + "--------------------------");
            foreach (Product elem in products.GetProducts())
            {
                if (elem.CategoryID == idCat)
                {
                    Console.WriteLine(elem.InfoString());
                }
            }

            Console.WriteLine("---------------------------------------------"
                      + "----------------------------------------------"
                      + "--------------------------");
            Console.ReadKey();
        }
        public void WriteBlockedProduct()
        {

            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");
            foreach (var category in categories.GetProducts())
            {
                if (category.IsBlocked == true)
                {
                    foreach (var product in products.GetProducts())
                    {
                        if (category.IDCat == product.CategoryID)
                        {
                            product.InfoString();
                        }
                    }

                }
            }

            Console.WriteLine("---------------------------------------------"
                     + "----------------------------------------------"
                     + "--------------------------");
            Console.ReadKey();
        }
        public void WriteProduct()
        {
            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");
            foreach (Product elem in products.GetProducts())
            {
                Console.WriteLine(elem.InfoString());
            }
            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");

            Console.ReadKey();
        }
        public void WriteCategory()
        {

            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");
            foreach (Category elem in categories.GetProducts())
            {
                Console.WriteLine(elem.InfoString());
            }

            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");
            Console.ReadKey();
        }
        public void WriteSupplier()
        {

            Console.WriteLine("---------------------------------------------"
                       + "----------------------------------------------"
                       + "--------------------------");
            foreach (Supplier elem in suppliers.GetProducts())
            {
                Console.WriteLine(elem.InfoString());
            }

            Console.WriteLine("---------------------------------------------"
                       + "--------------------------------------------------------"
                       + "--------------------------");
            Console.ReadKey();
        }


    }
}