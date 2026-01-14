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
            Player player = new Player(name: "Gage", maxHealth: 100, maxSheild: 50);
            player.TakeDamage(100);
        }
    }


    class Health
    {
        public int _CurrentHealth;
        public int _MaxHealth;
        public float GetHealth() 
        {
            return _CurrentHealth;
        }
        public void TakeDamage(int damage)
        {
            
            if(damage < 0)
            {
                Console.WriteLine("can't deal nagative numbers");
            }
            else
            {
                _CurrentHealth = _CurrentHealth - damage;
                if (_CurrentHealth < 0)
                {
                    _CurrentHealth = 0;
                }
            }
                
        }
        public void Restore()
        {
            _CurrentHealth = _MaxHealth;
        }

        public void Heal(int heal)
        {
            if(heal > 0)
            {
                _CurrentHealth = _CurrentHealth + heal;
                if(_CurrentHealth > _MaxHealth)
                {
                    _CurrentHealth = _MaxHealth;
                }
            }
            else { Console.WriteLine("Can't have negavtive healing"); }
            
        }
        public Health(int maxHealth)
        {
            _MaxHealth = maxHealth;
            _CurrentHealth = maxHealth;

        }
    }

    class Player
    {

        Health _health;
        Health _shield;
        // 
        public string Name { get; private set; }
        public int excessDamage;


        

        void TakeDamage(int damage)
        {
            if (_shield._CurrentHealth > 0 )
            {
                if (damage > _shield._CurrentHealth) 
                {
                    excessDamage = damage - _shield._CurrentHealth;
                    
                    _shield._CurrentHealth = 0;
                }
                else
                {
                    _shield._CurrentHealth = _shield._CurrentHealth - damage;
                }
                    
            }
            if (_shield._CurrentHealth == 0)
            {
                if(excessDamage!= 0)
                {
                    _health._CurrentHealth -= excessDamage;
                    excessDamage = 0;
                }
                else
                {
                    _health._CurrentHealth -= damage;
                }
            }
                 
           

        }
        public string GetStatusString()
        {
            if (_health._CurrentHealth <= 0)
            {
                _health._CurrentHealth = 0;
                return "dead";
            }
            else
            {
                return "Alive";
            }
                
        }
        public Player(string name, int maxHealth,int maxSheild)
        {
            Name = name;
            _health = new Health(maxHealth);
            _shield = new Health(maxSheild);
        }

    }
}
