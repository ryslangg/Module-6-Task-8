using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_task_8.Entities
{
    public class Unit
    {
        public virtual string Name { get; protected set; }
        public virtual int Health { get; protected set; } = 100;
        public virtual int DamageLow { get; protected set; } = 10;
        public virtual int DamageMax { get; protected set; } = 20;
        public virtual int Evasion { get; protected set; } = 10;
        public virtual int Accuracy { get; protected set; } = 10;
        public virtual int Armor { get; protected set; } = 1;
        protected Attack _attack;

        public Unit(string name, Dictionary<string, int> AttributesValues = null, Log log = null)
        {
            Name = name;
            _attack = new Attack(this, log);
            _setAttribute(AttributesValues);
        }

        private void _setAttribute(Dictionary<string, int> AttributesValues = null)
        {
            if (AttributesValues != null)
            {
                foreach (KeyValuePair<string, int> AttributeValue in AttributesValues)
                {
                    switch (AttributeValue.Key)
                    {
                        case "Health":
                            Health = AttributeValue.Value;
                            break;
                        case "Accuracy":
                            Accuracy = AttributeValue.Value;
                            break;
                        case "Armor":
                            Armor = AttributeValue.Value;
                            break;
                        case "DamageLow":
                            DamageLow = AttributeValue.Value;
                            break;
                        case "DamageMax":
                            DamageMax = AttributeValue.Value;
                            break;
                        case "Evasion":
                            Evasion = AttributeValue.Value;
                            break;
                    }
                }
            }
        }

        public void Attack(Unit target)
        {
            _attack.Do(target);
        }

        virtual public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
            {
                Health = 0;
            }
        }

        virtual  public bool CheckAlive()
        {
            return Health > 0;
        }
    }
}
