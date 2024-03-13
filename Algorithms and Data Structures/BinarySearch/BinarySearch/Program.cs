namespace BinarySearch;

internal class Program
{
    static string BinarySearch(int[] list , int value)
    {
        int FirstValue = 0;
        int lastValue = list.Length - 1;
        int middle;
        
        while(FirstValue <= lastValue)
        {
            middle = (FirstValue + lastValue) / 2;

            if (list[middle] == value)
            return ($"valor encontrado na posição {middle}°");
            

            if (list[middle] < value)
            FirstValue = middle + 1;

            if (list[middle] > value )
            lastValue = middle - 1;
        }
        return("NONE");


    }
    static void Main(string[] args)
    {
        int[] Arr = new int[] { 10, 20, 30, 40, 50, 60, 70 };
        string result = BinarySearch(Arr, 50);
        Console.Write(result);
    }
}
