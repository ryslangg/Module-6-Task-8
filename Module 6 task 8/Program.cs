using Module_6_task_8.Buiders;
using Module_6_task_8.Entities;
using Module_6_task_8.MenuElements;
using Module_6_task_8.UI;
using System;
using System.Collections.Generic;

namespace Module_6_task_8
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.AddElement(new ShowArmy1());
            menu.AddElement(new ShowArmy2());
            menu.AddElement(new Battle());
            menu.AddElement(new Help());
            menu.AddElement(new Exit());

            UnitBuilder builder = new UnitBuilder();
            Storage storage = new Storage();
            storage.Log = new Log();

            storage.Army1 = new Army("South", new List<Unit>() 
            {
                builder.Random(),
                builder.Random(),
                builder.Random(),
                builder.Random(),
                builder.Random()
            }, storage.Log);

            storage.Army2 = new Army("Nord", new List<Unit>()
            {
                builder.Random(),
                builder.Random(),
                builder.Random(),
                builder.Random(),
                builder.Random()
            }, storage.Log);

            while (menu.Active)
            {

                Console.Clear();
                InOut.BlockyPrint(new string[] 
                { 
                    $"Army:{storage.Army1.Name}",
                    $"Units:{storage.Army1.UnitsCount()}",
                    $"Army:{storage.Army2.Name}",
                    $"Units:{storage.Army2.UnitsCount()}",
                });
                menu.Print();
                char keySymbol = Console.ReadKey(true).KeyChar;
                Console.Clear();
                menu.Run(keySymbol, ref storage);
            }
        }
    }
}
