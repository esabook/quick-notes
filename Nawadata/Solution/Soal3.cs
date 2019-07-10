using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

class Soal3
{
    public Soal3()
    {

        Console.Write("Input: \n");
        var inputT = 0;
        if (int.TryParse(Console.ReadLine(), out inputT))
        {
            // pulling inputs
            String[] inputs = new String[inputT];
            for (int i = 0; i < inputT; i++)
            {
                Console.Write(String.Empty);
                inputs[i] = Console.ReadLine();
            }

            // show output
            Console.WriteLine("Output: ");
            ArrayList charUnik = new ArrayList();
            foreach (String s in inputs)
            {
                charUnik.Clear();

                // counting
                foreach (Char c in s.ToCharArray())
                {
                    if (!charUnik.Contains(c))
                    {
                        charUnik.Add(c);
                    }
                }

                // print
                Console.WriteLine(charUnik.Count);
            }

        }
    }
}

