using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorizationOfFerma
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter an odd number n > 1: n = ");

            int n;
            n = int.Parse(Console.ReadLine());

            while (n % 2 == 0 || n < 1)
            {
                Console.Write("Your number is not odd or < 1. Enter a new one: n = ");
                n = int.Parse(Console.ReadLine());
            }

            //ищем наименьшее число, при котором x^2 - n является неотрицательным
            int x = (int)Math.Sqrt(n);
            //увеличиваем x на k=1,2,... пока не окажется точным квадратом
            for (int q = x; x <= n; x++)
            {               
                double y = Math.Sqrt(Math.Pow(x, 2) - n);

                //проверяем, является ли точным квадратом            
                if (Math.Pow(y, 2) == Math.Pow(Math.Sqrt(Math.Pow(x, 2) - n), 2) && (int)y == y)
                {
                    Console.WriteLine($"n^2 = (x-y)*(x+y) = a*b where a = {x-y} b = {x+y}");
                    return;
                }
            }
        }
    }
}
