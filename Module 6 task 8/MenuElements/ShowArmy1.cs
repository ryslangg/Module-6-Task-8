using System;
using System.Collections.Generic;
using System.Text;
using Module_6_task_8.Entities;
using Module_6_task_8.UI;

namespace Module_6_task_8.MenuElements
{
    public class ShowArmy1 : ElementMenu
    {
        public ShowArmy1()
        {
            Title = "Show army 1";
            Description = "Show soldiers list";
            Key = '1';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            InOut.Alert(storage.Army1.UnitsInfo());
        }
    }
}
