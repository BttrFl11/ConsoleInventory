using System;

namespace ConsoleInventory.Debug
{
    public static class Debug
    {
        public static void Log(string message)
        {
            Console.WriteLine(message);
        }

        public static void Log()
        {
            Console.WriteLine();
        }

        public static void Log(float n)
        {
            Console.WriteLine(n.ToString());
        }
    }
}
