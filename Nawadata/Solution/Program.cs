using System;

namespace Nawadata
{
    class Program
    {
        static void Main(string[] args)
        {
            String soal = "" +
                "1) 1 2 hop!\n" +
                "2) Sort berdasarkan posisi\n" +
                "3) Kamus Panda\n" +
                "4) Angka Amicable\n" +
                "5) Rentang Terbesar\n" +
                "6) Struktur Total\n";

            String pertanyaan = "Ketik angka untuk menguji soal (1 sampai 6): ";
            Console.WriteLine(soal);
            while (true)
            {

                Console.WriteLine(Environment.NewLine);

                Console.Write(pertanyaan);

                var inputNum = 0;
                int.TryParse(Console.ReadLine(), out inputNum);

                switch (inputNum)
                {
                    case 1:
                        new Soal1();
                        break;
                    case 2:
                        new Soal2();
                        break;
                    case 3:
                        new Soal3();
                        break;
                    case 4:
                        new Soal4();
                        break;
                    case 5:
                        new Soal5();
                        break;
                    case 6:
                        new Soal6();
                        break;
                }

            }
        }
    }
}

