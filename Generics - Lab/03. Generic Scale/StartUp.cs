using System;

namespace GenericScale
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            EqualityScale<int> equalityScale = new EqualityScale<int>(1,1);
            

            Console.WriteLine(equalityScale.AreEqual());
        }
    }
}
