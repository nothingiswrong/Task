namespace Task1;


public static class Util
{
    
    public static int[] N7(int[] arr1, int[] arr2)
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

    public static int[] GenerateRandomSortedArray(int size)
    {
        var rnd = new Random();
        var arr = new int[size];
        
        for (var i = 0; i < size; i++) arr[i] = rnd.Next();
        Array.Sort(arr);
        
        return arr;
    }
    
    public static void WarmUp<T, K>(int c, Func<T, T, K> f, T t1, T t2)
    {
        for (var i = 0; i < c; i++) f(t1, t2);
    }

    public static List<List<int[]>> GenerateTestsN7(int c, int start, int offset)
    {
        var tests = new List<List<int[]>>(c);
        var rnd = new Random();
        for (var i = 0; i < c; i++)
        {
            tests.Add(new List<int[]>()
            {
                GenerateRandomSortedArray(start),
                GenerateRandomSortedArray(rnd.Next(0, start))
            });

            start += offset;
        }

        return tests;
    }


}