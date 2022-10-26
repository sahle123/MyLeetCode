using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

// Tags: DFS
class Result
{

    /*
     * Complete the 'countGroups' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts STRING_ARRAY related as parameter.
     */

    public static int countGroups(List<string> related)
    {
        int result = 0;
        
        // Converting to List<string> to jagged array.
        // Assuming our array will be square.
        int[,] matrix = new int[related.Count, related.Count];
        
        int k = 0;
        foreach(string s in related)
        {            
            for(int j = 0; j < s.Length; j++)
            {
                matrix[k, j] = int.Parse(s[j].ToString());
            }
            k++;
        }
        
        bool[] searched = new bool[related.Count];
        
        for(int i = 0; i < matrix.GetLength(0); i++)
        {
            if(searched[i])
                continue;
            // Console.WriteLine("Matrix length: " + matrix.GetLength(0).ToString());
            // Console.WriteLine("Matrix length: " + matrix.GetLength(1).ToString());
            dfs(matrix, searched, i, matrix.GetLength(0));
            result++;
        }
        
        return result;
    }
    
    private static void dfs(int[,] matrix, bool[] searched, int i, int length)
    {
        searched[i] = true;
        for(int j = 0; j < length; j++)
        {
            Console.WriteLine(i.ToString() + ", " + j.ToString());
            
            if(matrix[i, j] == 1 && !searched[j])
            {
                dfs(matrix, searched, j, length);
            }
        }
    }

}

// class Solution
// {
//     public static void Main(string[] args)
//     {
//         TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

//         int relatedCount = Convert.ToInt32(Console.ReadLine().Trim());

//         List<string> related = new List<string>();

//         for (int i = 0; i < relatedCount; i++)
//         {
//             string relatedItem = Console.ReadLine();
//             related.Add(relatedItem);
//         }

//         int result = Result.countGroups(related);

//         textWriter.WriteLine(result);

//         textWriter.Flush();
//         textWriter.Close();
//     }
// }