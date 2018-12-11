using System;
using System.Numerics;

namespace TestRabMil
{
    class MainClass
    {
        public static bool Test_Miller_Rabin(ulong n)
        {
            // если n == 2 или n == 3 - эти числа простые, возвращаем true
            if (n == 2 || n == 3)
                return true;
            // если n < 2 или n четное - возвращаем false
            if (n % 2 == 0 || n < 2)
            {
                return false;
            }

            BigInteger x = 0;

            ulong r1 = 2;
            ulong r2 = n - 2;
            ulong a;

            ulong r = (ulong)(Math.Log(n) / Math.Log(2));

            // представим n − 1 в виде (2^s)·t, где t нечётно, это можно сделать последовательным делением n - 1 на 2
            ulong s = 0;
            ulong t = n - 1;

            while (t != 0 && t % 2 == 0)
            {
                s++;
                t /= 2;
            }

            Random rand = new Random();

            for (ulong i = 0; i < r; i++)
            {
                //a = r1 + ((ulong)rand.Next() % (r2 - r1));

                a = (ulong)rand.Next((int)r1, (int)r2);

                // x ← a^t mod n, вычислим с помощью возведения в степень по модулю
                x = BigInteger.ModPow(a, t, n);

                // если x == 1 или x == n − 1, то перейти на следующую итерацию цикла
                if (x == 1 || x == n - 1)
                {
                    continue;
                }

                //повторяем s-1 раз
                for (ulong j = 0; j < s - 1; j++)
                {

                    x = BigInteger.ModPow(a, 2, n);

                    // если x == 1, то вернуть "составное"
                    if (x == 1)
                        return false;

                    // если x == n − 1, то перейти на следующую итерацию внешнего цикла
                    if (x == n - 1)
                        break;
                }

                if (x == n - 1)
                    continue;

                return false;
            }

            // вернуть "вероятно простое"
            return true;
        }
        static void Main(string[] args)
        {
            ulong n;

            ulong.TryParse(Console.ReadLine(), out n);

            if (Test_Miller_Rabin(n))
                Console.WriteLine("Possibly primary!");
            else
                Console.WriteLine("Composite!");
            Console.ReadKey();
        }
    }
}
