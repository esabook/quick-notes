using System;
using System.Collections;

public class Soal1
{
    public Soal1()
    {
        Console.Write("Input: \n");
        var inputT = 0;
        if (int.TryParse(Console.ReadLine(), out inputT))
        {
            // pulling inputs
            int[] inputs = new int[inputT];
            for (int i = 0; i < inputT; i++)
            {
                Console.Write(String.Empty);
                inputs[i] = int.Parse(Console.ReadLine());
            }

            // show output
            Console.WriteLine("Output:");
            foreach (int i in inputs)
            {
                // directly print to console
                if (i > 9) {
                    Console.WriteLine("what?");
                    continue;
                }

                //
                ArrayList list = new ArrayList();
                for (int segmen = 1; segmen <= i; segmen++)
                {
                    for (int pos = 1; pos <= i; pos++)
                    {
                     
                        if (pos == i)
                        {
                            list.Add("hop!");
                        }
                        else
                        {
                            list.Add(pos);
                        }
                    }
                }
                String joined = String.Join(" ", list.ToArray());
                Console.WriteLine(joined);
            }
        }
    }
}
