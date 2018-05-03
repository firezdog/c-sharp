using System;

namespace Abstraction
{
    public abstract class Animal
    {
    public string[] characteristics {get; set;}
    
    //No reason making the constructor public since it can not be
    //Invoked other than from a class inheriting from this class
    protected Animal()
        {
            characteristics = new string[] { 
                "Multicellular", 
                "Eukaryotic Cell Structure",
                "Specialized Tissues",
                "Heterotrophs",
                "Nervous System" };
        }
    }
    public interface MustRun
    {
        int Run();
    }
    public class Goat : MustRun 
    {
        public int Run(){
            Console.WriteLine("The goat must run.");
            return 5;
        }
    }
    public class Bird
    {
        //Doesn't need to do anything, because it doesn't impelement CanRun.
    }
    public class Ostrich: Bird, MustRun {
        public int Run(){
            Console.WriteLine("Birds needn't run, but Ostriches are birds that must run.");
            return -10;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            MustRun obj1 = new Ostrich();
            MustRun obj2 = new Goat();
        }
    }
}
