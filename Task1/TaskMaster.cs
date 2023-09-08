using System.Diagnostics;

namespace Task1;

public class TaskMaster
{
    public int[] N7(int[] arr1, int[] arr2)
    {
        var ans = new int[arr1.Length + arr2.Length];
        var (p1, p2, k) = (0, 0, 0);

        while (p1 < arr1.Length && p2 < arr2.Length)
        {
            if (arr1[p1] < arr2[p2]) ans[k++] = arr1[p1++];
            else ans[k++] = arr2[p2++];
        }

        while (p1 < arr1.Length) ans[k++] = arr1[p1++];
        while (p2 < arr2.Length) ans[k++] = arr2[p2++];

        return ans;
    }
    
    public  List<List<int[]>> GenerateTestsN7(int c, int start, int offset)
    {
        var tests = new List<List<int[]>>(c);
        var rnd = new Random();
        for (var i = 0; i < c; i++)
        {
            tests.Add(new List<int[]>()
            {
                Util.GenerateRandomSortedArray(start),
                Util.GenerateRandomSortedArray(rnd.Next(0, start))
            });

            start += offset;
        }

        return tests;
    }

    public Dictionary<long, long> PassTests(List<List<int[]>> tests)
    {
        var res = new Dictionary<long, long>();
        var sw = new Stopwatch();

        foreach (var t in tests)
        {
            sw.Start();
            N7(t[0], t[1]);
            sw.Stop();
            
            res.Add(Math.Max(t[0].Length, t[1].Length), sw.ElapsedTicks);
        }

        return res; 
    }

}