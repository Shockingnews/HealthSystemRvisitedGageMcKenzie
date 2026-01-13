using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystemRvisitedGageMcKenzie
{
    internal class Program
    {
        static void Main(string[] args)
        {

        }
    }


    class Health
    {
        int _CurrentHealth;
        int _MaxHealth;
        public float GetHealth() 
        {
            return _CurrentHealth;
        }
        public void TakeDamage(int damage)
        {
            _CurrentHealth = _CurrentHealth - damage;
        }
        public void Restore()
        {
            _CurrentHealth = _MaxHealth;
        }

        public void Heal(int heal)
        {
            _CurrentHealth = _CurrentHealth + heal;
        }
        public Health(int maxHealth)
        {
            _MaxHealth = maxHealth;
            _CurrentHealth = maxHealth;

        }
    }

    class Player
    {
        Health _health = new Health(100);
        Health _shield = new Health(50);
        string _name;


        

        void TakeDamage(int damage)
        {
            if (_shield.GetHealth() > 0 )
            {
                 = _shield.GetHealth() - damage;
            }

        }
        string GetStatusString()
        {

        }
    }
}
