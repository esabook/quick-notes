using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Nawadata
{
    class Soal5
    {
        public Soal5()
        {
            Console.WriteLine("Input: ");
            int T = int.Parse(Console.ReadLine());

            List<MyKV> inputs = new List<MyKV>();
            do
            {
                int totalSubset = int.Parse(Console.ReadLine());
                List<String> anggotaSubset = Console.ReadLine().Split(" ").ToList();
                var c = anggotaSubset.Select(o => int.Parse(o)).ToArray();
                inputs.Add(new MyKV(totalSubset, c));
                T--;
            } while (T > 0);

            Console.WriteLine("Output:");
            foreach (var d in inputs)
            {

                List<int> candidateResult = collectWCandidate(d.value);
                int res = 0;
                for (int j = 0; j < candidateResult.Count-1; j++)
                {
                    res = candidateResult[j];
             
                    int nextVal = candidateResult[j + 1];
                    bool isSequence = res == nextVal - 1;
                    bool isEqual = res == nextVal;

                    if (isEqual || isSequence)
                    {
                        res = nextVal;
                    }
                    else {
                        break;

                    }
                }

                Console.WriteLine(res);


            }
        }

        public static List<int> collectWCandidate(int[] d)
        {
            List<int> storedResult = new List<int>();
            storedResult.AddRange(d.Select(o => o));

            // pasangan minimal = 2; mis 1 dan 100
            for (int pasangan = 2; pasangan <= d.Length; pasangan++)
            {

                IEnumerable<int[]> can = CombinationsRosettaWoRecursion(d, pasangan);
                foreach (int[] kandidat in can)
                {

                    int jumlah = 0;
                    foreach (int j in kandidat)
                    {
                        jumlah += j;
                    }
                    if (jumlah != 1 && !storedResult.Contains(jumlah))
                    {
                        storedResult.Add(jumlah);
                    }


                }

                //    for (int indexAnggotaPasangan = 0; indexAnggotaPasangan < 2; )
            }
            storedResult.Sort();
            return storedResult;
        }

        public static IEnumerable<T[]> CombinationsRosettaWoRecursion<T>(T[] array, int m)
        {
            if (array.Length < m)
                throw new ArgumentException("Array length can't be less than number of selected elements");
            if (m < 1)
                throw new ArgumentException("Number of selected elements can't be less than 1");
            T[] result = new T[m];
            foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
            {
                for (int i = 0; i < m; i++)
                {
                    result[i] = array[j[i]];
                }
                yield return result;
            }
        }

        // Enumerate all possible m-size combinations of [0, 1, ..., n-1] array
        // in lexicographic order (first [0, 1, 2, ..., m-1]).
        private static IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    yield return (int[])result.Clone(); // thanks to @xanatos
                                                        //yield return result;
                    break;
                }
            }
        }



    }

    class MyKV
    {
        public int total;
        public int[] value;

        public MyKV(int total, int[] value)
        {
            this.total = total;
            this.value = value;
        }
    }
}
