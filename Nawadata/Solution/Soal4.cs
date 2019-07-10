using System;
using System.Collections.Generic;
using System.Text;

namespace Nawadata
{
    class Soal4
    {
        public Soal4()
        {
            Console.Write("Masukkan Jumlah Bilangan: ");
            int jumlah = int.Parse(Console.ReadLine());

            int i = 2; // bilangan bulat prasyarat

            //int[] OEIS = { 2, 3, 4, 6, 7, 11, 18, 34, 38, 43, 55, 64, 76, 94, 103, 143, 206, 216, 306, 324, 391, 458, 470, 827, 1274, 3276, 4204, 5134, 7559, 12676, 14898, 18123, 18819, 25690, 26459, 41628, 51387, 71783, 80330, 85687, 88171, 97063, 123630, 155930, 164987, 234760, 414840, 584995, 702038, 727699, 992700, 1201046, 1232255, 2312734, 3136255, 4235414, 6090515, 11484018, 11731850, 11895718 };

            Console.WriteLine("Output: ");
            while (jumlah > 0)
            {

                // amicable number eq. as https://en.wikipedia.org/wiki/Thabit_number
                double p = 3 * Math.Pow(2, (i - 1)) - 1;
                double q = 3 * Math.Pow(2, i) - 1;
                double r = 9 * Math.Pow(2, 2 * i - 1) - 1;

                if (IsPrime(r) ){
                    double a1 = Math.Pow(2, i) * p * q;
                    double a2 = Math.Pow(2, i) * r;

                    jumlah--;
                    jumlah--;
                    Console.WriteLine(String.Format("{0} amicable dengan {1}", a1, a2));
                    if (jumlah > 0)
                        Console.WriteLine(String.Format("{0} amicable dengan {1}", a2, a1));
                }
                i++;


            }
        }

        public static bool IsPrime(double number)
        {
            if (number <= 1) return false;
            if (number == 2) return true;
            if (number % 2 == 0) return false;

            var boundary = (int)Math.Floor(Math.Sqrt(number));

            for (int i = 3; i <= boundary; i += 2)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}
