using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Module_6_task_8.Entities
{
    public class Army:Unit
    {

        private List<Unit> _units = new List<Unit>();
        private Log _log;
        public override int DamageLow
        {
            get
            {
                return _units.Sum(unit => unit.DamageLow);
            }
            protected set { }
        }
        public override int DamageMax
        {
            get
            {
                return _units.Sum(unit => unit.DamageMax);
            }
            protected set { }
        }
        public override int Evasion
        {
            get
            {
                return _units.Sum(unit => unit.Evasion) / _units.Count;
            }
            protected set { }
        }
        public override int Accuracy
        {
            get
            {
                return _units.Sum(unit => unit.Accuracy) / _units.Count;
            }
            protected set { }
        }
        public override int Armor
        {
            get
            {
                return _units.Sum(unit => unit.Armor);
            }
            protected set { }
        }
        public override int Health 
        { 
            get {
                int h = _units.Sum(unit => unit.Health);
                return h;
            }
            protected set { }
        }

        public Army(string name, List<Unit> units = null, Log log = null) :base(name, null, log)
        {
            Name = name;
            _attack = new Attack(this,log);
            _log = log;

            if( units != null )
            {
                _units = units;
            }
        }

        public override void TakeDamage(int damage)
        {
            if(CheckAlive())
            {
                Unit unit = _units.First();
                int lastHealth = unit.Health;
                unit.TakeDamage(damage);

                if (!unit.CheckAlive())
                {
                    _log.Add($"{unit.Name} died!");
                    _units.Remove(unit);
                }
                damage -= lastHealth;

                if (damage > 0)
                {
                    TakeDamage(damage);
                }
            }
            

        }

        public override bool CheckAlive()
        {
            return _units.Count > 0;
        }

        public int UnitsCount()
        {
            return _units.Count;
        }

        public string UnitsInfo()
        {
            string info = "";

            foreach(Unit unit in _units)
            {
                info += "-------------------------\r\n";
                info += $"Name:{unit.Name}\r\n";
                info += $"HP:{unit.Health}\r\n";
                info += $"Damage:{unit.DamageLow}-{unit.DamageMax}\r\n";
                info += $"Evasion:{unit.Evasion}\r\n";
                info += $"Accuracy:{unit.Accuracy}\r\n";
                info += $"Armor:{unit.Armor}\r\n";
                info += "-------------------------\r\n";
            }

            return info;
        }
    }
}
