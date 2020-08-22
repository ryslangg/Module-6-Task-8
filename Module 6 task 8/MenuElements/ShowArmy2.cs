using System;
using System.Collections.Generic;
using System.Text;
using Module_6_task_8.Entities;
using Module_6_task_8.UI;

namespace Module_6_task_8.MenuElements
{
    public class ShowArmy2 : ElementMenu
    {
        public ShowArmy2()
        {
            Title = "Show army 2";
            Description = "Show soldiers list";
            Key = '2';
        }

        public override void Do(ref Storage storage, Menu menu)
        {
            InOut.Alert(storage.Army2.UnitsInfo());
        }
    }
}
