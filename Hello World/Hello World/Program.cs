using System;

namespace Hello_World
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Pick a number.");
            myNumber = Console.Readline();
            Console.WriteLine(myNumber * 50);
            Console.ReadLine();
        }
    }
}
