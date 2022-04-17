using System;

namespace BoxOfT
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Box<string> box = new Box<string>();
            
            box.Add("1");
            box.Add("2");
            box.Add("3");

            

            box.Remove();

            box.Print();
            
            Console.WriteLine("************************************************");
            box.Remove();
            box.Print();

        }
    }
}
