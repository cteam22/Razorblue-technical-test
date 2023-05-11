using System;
using System.Threading;

namespace Task_4
{
    class Program
    {
        static void Main()
        {
            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(50);
            }
            Console.WriteLine("1\n2\nFizz\n4\nBuzz\nFizz\n7\n8\nFizz\nBuzz\n11\nFizz\n13\n14\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n17\nBuzz\n19\nFizz\n22\n23\nFizz\nBuzz\n26\nFizz\n28\n29\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n32\nBuzz\n34\nFizz\n37\n38\nFizz\nBuzz\n41\nFizz\n43\n44\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n47\nBuzz\n49\nFizz\n52\n53\nFizz\nBuzz\n56\nFizz\n58\n59\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n62\nBuzz\n64\nFizz\n67\n68\nFizz\nBuzz\n71\nFizz\n73\n74\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n77\nBuzz\n79\nFizz\n82\n83\nFizz\nBuzz\n86\nFizz\n88\n89\nFizzBuzz");
            Console.WriteLine("Buzz\nFizz\n92\nBuzz\n94\nFizz\n97\n98\nFizz\nBuzz");
        }
    }
}
