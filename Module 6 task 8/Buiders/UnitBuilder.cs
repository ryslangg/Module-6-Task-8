using Module_6_task_8.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Module_6_task_8.Buiders
{
    class UnitBuilder
    {
        private Dictionary<string, int> _attributesValues;
        private Random _rand = new Random();

        public void Prepare()
        {
            _attributesValues = new Dictionary<string, int>();
        }

        private void _setValue(string name, int value)
        {
            if (_attributesValues == null)
            {
                Prepare();
            }
            _attributesValues[name] = value;
        }

        public void Health(int value)
        {
            _setValue("Health", value);
        }
        public void DamageLow(int value)
        {
            _setValue("DamageLow", value);
        }

        public void DamageMax(int value)
        {
            _setValue("DamageMax", value);
        }

        public void Evasion(int value)
        {
            _setValue("Evasion", value);
        }

        public void Accuracy(int value)
        {
            _setValue("Accuracy", value);
        }

        public void Armor(int value)
        {
            _setValue("Armor", value);
        }

        public void Clear()
        {
            _attributesValues = null;
        }

        public Unit Build( string UnitName)
        {
            return new Unit(UnitName, _attributesValues);
        }

        public Unit Random()
        {
            
            Health(_rand.Next(100,200));
            DamageLow(_rand.Next(10, 30));
            DamageMax(_rand.Next(30, 60));
            Evasion(_rand.Next(1, 40));
            Accuracy(_rand.Next(1, 30));
            Armor(_rand.Next(0, 25));
            Unit unit = Build($"Unit {_rand.Next(1000, 9999)}");
            Clear();
            return unit;
        }
    }
}
