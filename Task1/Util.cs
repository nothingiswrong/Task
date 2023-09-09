namespace Task1;


public static class Util
{
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
    

}