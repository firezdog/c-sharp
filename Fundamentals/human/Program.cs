using System;

namespace human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human cloud = new Human("Cloud", 100, 100, 100, 100);
            Human sephiroth = new Human("Sephiroth", 9999, 9999, 9999, 9999);
            cloud.attack(sephiroth);
        }
    }

    public class Human {
        public string name;
        public int strength;
        public int intelligence;
        public int dexterity;
        public int health;

        public Human(string nomen){
            name = nomen;
            strength = 3;
            intelligence = 3;
            dexterity = 3;
            health = 100;

        }

        public Human(string nomen, int vim, int wit, int speed, int vigor) {
            name = nomen;
            strength = vim;
            intelligence = wit;
            dexterity = speed;
            health = vigor;
        }

        public void attack(object opp) {
            if (opp is Human) {
                Human theOpp = opp as Human;
                theOpp.health -= 5 * strength;
            }
        }

    }

}
