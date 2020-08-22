using System;
using System.Collections.Generic;
using System.Text;
using Module_6_task_8.Entities;
using Module_6_task_8.UI;

namespace Module_6_task_8.MenuElements
{
    public class Battle : ElementMenu
    {
        public Battle()
        {
            Title = "Battle";
            Description = "run army battle";
            Key = '3';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            do
            {
                storage.Army1.Attack(storage.Army2);
                storage.Army2.Attack(storage.Army1);
            }
            while (storage.Army1.CheckAlive() && storage.Army2.CheckAlive());

            string result;

            if (storage.Army1.CheckAlive())
            {
                result = $"{storage.Army1.Name} WIN!";
            }
            else
            {
                result = $"{storage.Army2.Name} WIN!";
            }

            if (!storage.Army1.CheckAlive() && !storage.Army2.CheckAlive())
            {
                result = "Draw!";
            }

            storage.Log.Add(result);
            storage.Log.Print();
            menu.Active = false;
        }
    }
}
