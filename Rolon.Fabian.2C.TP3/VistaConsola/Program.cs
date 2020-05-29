using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VistaConsola
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("{0}", random.Next(0, 4));
            }

            Console.ReadKey();
        }
    }
}
