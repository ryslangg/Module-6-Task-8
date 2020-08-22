using System;
using System.Collections.Generic;
using System.Text;

namespace Module_6_task_8.Entities
{
   public class Attack
    {
        private  Unit _attacker;
        private static  Random _rand = new Random();
        private Log _log = null; 

        public Attack(Unit attacker, Log log = null)
        {
            _attacker = attacker;

            if( log != null )
            {
                _log = log;
            }
        }

        private void _addToLog(string message)
        {
            if(_log != null)
            {
                _log.Add(message);
            }
        }


        protected bool _checkMiss(Unit target) 
        {            
            int evasionChance = _rand.Next(0,100);
            return evasionChance <= target.Evasion;
        }

        protected bool _checkTryeStrike()
        {
            int TryeStrikeChance = _rand.Next(0, 100);
            return TryeStrikeChance <= _attacker.Accuracy;
        }

        protected bool _checkSuccessStrike(Unit target)
        {
            return (!_checkMiss(target) || _checkTryeStrike());
        }

        public void Do(Unit target)
        {
            if(_attacker.CheckAlive())
            {
                _log.Separator();
                _addToLog($"{_attacker.Name} strikes {target.Name}");

                if (_checkSuccessStrike(target))
                {
                    int damage = _rand.Next(_attacker.DamageLow, _attacker.DamageMax);
                    _addToLog($"{damage}DMG");
                    _addToLog($"{target.Armor} blocked");
                    damage -= target.Armor;
                    target.TakeDamage(damage);

                    if (target.CheckAlive())
                    {
                        _addToLog($"{target.Name}({target.Health}HP)");
                    }
                }
                else
                {
                    _addToLog("The blow went by!");
                }
                _log.Separator();
            }
            
        }
    }
}
