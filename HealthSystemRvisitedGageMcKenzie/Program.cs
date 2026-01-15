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
            bool alive = true;
            Random random = new Random();
            int num = random.Next(1, 21);

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Clear();
            

            Player player = new Player(name: name, maxHealth: 100, maxSheild: 50);
            Console.WriteLine(player.GetStatusString());
            Console.WriteLine("Press D for damage and H to heal");

            while (alive)
            {

                
                ConsoleKeyInfo input = Console.ReadKey(true);
                if (input.Key == ConsoleKey.D)
                {
                    player.TakeDamage(num);
                    Console.Clear();
                }
                if (input.Key == ConsoleKey.H)
                {
                    player._health.Heal(num);
                    Console.Clear();
                }
                if (player._health.CurrentHealth == 0)
                {
                    alive = false;
                    Console.Clear();

                }
                Console.WriteLine(player.GetStatusString());
                Console.WriteLine("Press D for damage and H to heal");
                
            }
            Console.Clear();
            Console.WriteLine(player.GetStatusString());
            Console.WriteLine("You Died");
            Console.ReadKey(true);
            
            
        }
    }


    class Health
    {
         public int CurrentHealth { get; private set; }
        
         public int MaxHealth { get; private set; }
        public float GetHealth() 
        {
            return CurrentHealth;
        }
        public void TakeDamage(int damage)
        {
            
            if(damage < 0)
            {
                Console.WriteLine("can't deal nagative numbers");
            }
            else
            {
                CurrentHealth = CurrentHealth - damage;
                if (CurrentHealth < 0)
                {
                    CurrentHealth = 0;
                }
            }
                
        }
        public void Restore()
        {
            CurrentHealth = MaxHealth;
        }

        public void Heal(int heal)
        {
            if(heal > 0)
            {
                CurrentHealth = CurrentHealth + heal;
                if(CurrentHealth > MaxHealth)
                {
                    CurrentHealth = MaxHealth;
                }
            }
            else { Console.WriteLine("Can't have negavtive healing"); }
            
        }
        public Health(int maxHealth)
        {
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;

        }
    }

    class Player
    {

        public Health _health { get; private set; }
        public Health _shield { get; private set; }
        // 

        public string Name { get;  set; }
        public int excessDamage;


        

        public void TakeDamage(int damage)
        {
            if (_shield.CurrentHealth > 0 )
            {
                if (damage > _shield.CurrentHealth) 
                {
                    excessDamage = damage - _shield.CurrentHealth;
                    _shield.TakeDamage(excessDamage);
                    
                    
                }
                else
                {
                    _shield.TakeDamage(damage);
                    
                }
                    
            }
            if (_shield.CurrentHealth == 0)
            {
                if(excessDamage!= 0)
                {
                    _health.TakeDamage(excessDamage);
                    
                    excessDamage = 0;
                }
                else
                {
                    _health.TakeDamage(damage);
                    
                }
            }
                 
           

        }
        public string GetStatusString()
        {
            if (_health.CurrentHealth <= 0)
            {
                //_health.CurrentHealth = 0;
                return $"Name: {Name} Health: {_health.CurrentHealth} Shield: {_shield.CurrentHealth} Status: Dead";
            }
            else
            {
                return $"Name: {Name} Health: {_health.CurrentHealth} Shield: {_shield.CurrentHealth} Status: Alive";
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
