using System;
using System.Collections.Generic;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            Ninja ninja = new Ninja("Mr. Ninja");
            Wizard wizard = new Wizard("Mr. Wizard");
            Samurai samurai = new Samurai("Mr. Samurai");
            Human human = new Human("Mr. Human");
            object obj = new object();
            human.attack(obj);
            wizard.fire_attack(obj);
            ninja.steal(obj);
            samurai.death_blow(obj);
            Samurai.how_many();
            wizard.fire_attack(samurai);
            samurai.meditate();
        }
    }

    public class Human
    {
        public string name;

        //The { get; set; } format creates accessor methods for the field specified
        //This is done to allow flexibility
        public int health { get; set; }
        public int strength { get; set; }
        public int intelligence { get; set; }
        public int dexterity { get; set; }
        public int full_health { get; set; }
        public Human(string name)
        {
            this.name = name;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;
            full_health = health;
        }
        public Human(string name, int strength, int intelligence, int dexterity, int health)
        {
            this.name = name;
            this.strength = strength;
            this.intelligence = intelligence;
            this.dexterity = dexterity;
            this.health = health;
        }
        public void attack(object obj)
        {
            Human enemy = obj as Human;
            if(enemy == null)
            {
                Console.WriteLine("Humans can only attack other humans.");
            }
            else
            {
                enemy.health -= strength * 5;
            }
        }
    }
    public class Ninja : Human
    {
        public Ninja(string name) : base (name) {
            dexterity = 175;
        }
        public Ninja(string name, int strength, int intelligence, int dexterity, int health) : base(name,strength,intelligence, dexterity, health) {}
        public Ninja steal (object obj) {
            Human enemy = obj as Human;
            if (enemy == null) {
                Console.WriteLine("Ninjas can only steal from humans.");
            } else {
                attack(enemy);
                health += 10;
            }
            return this;
        }
        public Ninja escape () {
            health -= 15;
            return this;
        }
    }
    public class Wizard:Human 
    {
        public Wizard(string name) : base (name) {
            health = 50;
            full_health = health;
            intelligence = 25;
        }
        public Wizard(string name, int strength, int intelligence, int dexterity, int health) : base(name,strength,intelligence, dexterity, health) {}
        public Wizard heal() {
            if (health + 10 * intelligence < full_health) {
                health += 10 * intelligence;
            } else {
                health = full_health;
            }
            return this;
        }
        public Wizard fire_attack(object obj) {
            Human enemy = obj as Human;
            if (enemy == null) {
                Console.WriteLine("Fireballs can only be cast on humans.");
            } else {
                Random ayn = new Random();
                enemy.health -= ayn.Next(20,50);
            }
            return this;
        }
    }
    public class Samurai : Ninja
    {
        public static int instances = 0;
        public Samurai(string name) : base (name) {
            health = 200;
            full_health = health;
            instances++;
        }
        public Samurai(string name, int strength, int intelligence, int dexterity, int health) : base(name,strength,intelligence, dexterity, health) {
            instances++;
        }
        public Samurai death_blow (object obj)
        {
            Human enemy = obj as Human;
            if (enemy == null) {
                Console.WriteLine("Death blows only work against humans.");
            } else if (enemy.health > 49) {
                attack(enemy);
            } else {
                enemy.health = 0;
            }
            return this;
        }
        public Samurai meditate() {
            health = full_health;
            return this;
        }
        public static void how_many() {
            Console.WriteLine($"There is(are) {instances} samurai(s)");
        }
    }

}
