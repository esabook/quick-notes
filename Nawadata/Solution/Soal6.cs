using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Nawadata
{
    class Soal6
    {
        Dictionary<char, int> operasi = new Dictionary<char, int>{
            { '+', 0}, // penjumlahan
            { '-', 1}, // pengurangan
            { '#',2}}; // dummy

        public Soal6()
        {
            Console.WriteLine("Masukkan bilangan:");
            int input = int.Parse(Console.ReadLine());

            int[] deretAngka = { 3, 4, 5, 6, 7 };

            Console.WriteLine("Output:");
            String deretAngkaTemp = String.Join("", deretAngka.Select(o => "+" + o));
            printResultLineIfMatch(input, deretAngkaTemp);

            String nextderetAngkaTemp = bruteForcingOperator(deretAngkaTemp);
            
            while (deretAngkaTemp != nextderetAngkaTemp)
            {
                printResultLineIfMatch(input, nextderetAngkaTemp);
                nextderetAngkaTemp = bruteForcingOperator(nextderetAngkaTemp);
            }
           

        }

        /**
         * 
         */
        void printResultLineIfMatch(int input, String deretAngka) {
            String processedStrQueue = deretAngka.Replace("#", "");

            int checkRes = int.Parse(new DataTable().Compute( processedStrQueue , null).ToString());
            if (input == checkRes) {
                Console.WriteLine(processedStrQueue);
            }
        }

        /**
        * 
        */
        String bruteForcingOperator(String input) {
            // ex. +1+2+3, +1-23
            char[] temp = input.ToCharArray();

            for (int j = temp.Length-1; j > 0; j--) {
                char currentOperator = temp[j];
                if (operasi.ContainsKey(currentOperator)) {
                    int currentOperatorId = operasi.GetValueOrDefault(currentOperator, 0);

                    // increment operator, + to -; - to combine; combine to +;
                    // change to +1+2-3, +12+3
                    int nextOperatorId = (currentOperatorId + 1) % 3;
                    char nextOperator = operasi.FirstOrDefault(o => o.Value == nextOperatorId).Key;
                    temp[j] = nextOperator;

                    if (nextOperatorId != 0) {
                        break;
                    }
                }
            }

            return String.Join("", temp);
        }

    }
}
