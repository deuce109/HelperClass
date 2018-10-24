using System;

namespace HelperClass
{
    class Program
    {
        static void Main(string[] args)
        {

            byte[] bytes = args[0].ToByteArray();

            Console.WriteLine(bytes.GetHashBytes(Helper.HashAlgorithms.SHA256, 10).ToString("base64"));

        }
    }
}
