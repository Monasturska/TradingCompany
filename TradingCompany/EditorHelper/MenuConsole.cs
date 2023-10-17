using System;

namespace TradingCompany.EditorHelper
{
    public class MenuConsole
    {
        public static void Introdusing()
        {
            Console.WriteLine("\t\t\t\tWELCOME to the menu!)\n" +
                         "\t\t\t\tNow we are ready to start! ");
            Console.ReadKey();
        }
        public static void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\tAdmin menu."
            + "\n\t\t\t\t\t1. Do smth with products."
            + "\n\t\t\t\t\t2. Do actions with categories."
            + "\n\t\t\t\t\t3. Do actions with suppliers."
            + "\nYour choice:");
        }


        public static void ShowProductMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t\tProduct setting:"
            + "\n\t\t\t\t1. Show infomation of all products."
            + "\n\t\t\t\t2. Show infomation(w/ price) of one category products."
            + "\n\t\t\t\t3. Change value of product."
            + "\n\t\t\t\t4. Add a new product of one category."
            + "\n\t\t\t\t5. Remove a product."
            + "\n\t\t\t\t6. Show the most expensive product."
            + "\n\t\t\t\t7. Back.");
        }

        public static void ShowCategoryMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t\tCategory setting:"
            + "\n\t\t\t\t1. Show all categories of products."
            + "\n\t\t\t\t2. Change value(name) of one category."
            + "\n\t\t\t\t3. Add a new category."
            + "\n\t\t\t\t4. Remove one category."
            + "\n\t\t\t\t5. Back.");
        }
        public static void ShowSupplierMenu()
        {
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\tSupplier setting:"
            + "\n\t\t\t\t1. Show all suppliers."
            + "\n\t\t\t\t2. Change value(name) of one supplier."
            + "\n\t\t\t\t3. Add a new person."
            + "\n\t\t\t\t4. Remove one supplier."
            + "\n\t\t\t\t5. Back.");
        }

    }
}
