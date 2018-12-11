using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poklington
{
    class Program
    {

        public static int GCD(int x, int y) 
        {
            int t;
            while (y != 0)
            {
                t = y;
                y = x % y;
                x = t;
            }
            return x;
        }

        //n - натуральное число. пусть n-1 имеет простой делитель q, причем q>sqrt(n) - 1
        //если найдется такое число a, что 
        //1. a^(n-1) = 1 (mod n)
        //2. gcd(n, a^((n-1)/q) -1) = 1 
        //n простое

        static void Main(string[] args)
        {
            int iN; //наше число
            int iQ = 0; //простой делитель  
            bool bOne = false;
            bool bTwo = false;
            Console.WriteLine("Enter number for testing: ");

            iN = int.Parse(Console.ReadLine());

            --iN; //n-1

            for (int q = 1; q <= iN; q++) //ищем простые делители   
            {
                if (iN % q == 0)
                {
                    bool simple = true;
                    for (int j = 2; j <= q / 2; j++)
                        if (q % j == 0)
                        {
                            iQ = q;
                            simple = false;
                            int a = q;
                            while (a % j == 0)
                            {
                                a /= j;
                                if (a == 1)
                                {
                                    simple = true;
                                    break;
                                }
                            }
                            break;
                        }
                    float fN = (float)Math.Sqrt((iN + 1)) - 1; //корень из n-1
                    if ((simple) && q > fN && q != iN)
                    {
                        iQ = q;
                    }
                }
            }

            for (int a = 2; a < iN; ++a) //работа с условием 1
            {
                int fA = 1;
                for (int i = 0; i < iN; i++)
                {
                    fA *= a;
                    fA %= (iN + 1);
                }
                
                if (fA == 1)
                {
                    bOne = true;
                }
                if (iQ == 0) //при отсутствии простых делителей число объявляется составным
                {
                    Console.WriteLine("N - sostavnoe\n");

                    return;
                }

                float fNQ = (iN - 1) / (float)(iQ); //работа с условием 2
                                                    
                int iANQ = (int)Math.Pow(a, fNQ) - 1;

                if (GCD(iN + 1, iANQ) == 1)
                {
                    bTwo = true;

                    break;
                }
            }

            if (bOne == true && bTwo == true)
                Console.WriteLine("N - prostoe");
            else
                Console.WriteLine("N - sostavnoe");

        }
    }
}
