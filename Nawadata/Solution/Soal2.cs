using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Soal2
{
    public Soal2() {
        Console.WriteLine("Masukkan kata: ");
        String input = Console.ReadLine();
        
        // limit 100 char
        input = input.Substring(0, input.Length > 100 ? 100 : input.Length);
        // remove space
        input = input.Replace(" ", "");
        List<Char> strs = input.ToCharArray().ToList();

        // collecting
        for (int head = 0; head < strs.Count-1; head++) {
            for (int tail = head+1; tail < strs.Count; tail++) {

                if (strs[head].Equals(strs[tail])){
                    strs.Insert(head + 1, strs[tail]);
                    strs.RemoveAt(tail+1);
                    head++;
                }
            }
        }

        // output
        Console.WriteLine("Output:");
        String joined = String.Concat(strs.ToArray());
        Console.Write(joined);
    }

}
