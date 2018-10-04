using System;

namespace HelperClass
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] bytes = args[0].ToBytes("utf8");

            for (int i = 0; i < bytes.Length; i++)
            {
                Console.Write($"{bytes[i]} ");
            }

        }
    }
}
