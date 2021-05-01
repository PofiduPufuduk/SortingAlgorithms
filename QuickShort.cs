using System;
using System.Collections.Generic;

#region En
/* Cost of splitting up the arrays: O(n)
   In how many steps does it go down to a single element number? O(log2 n)
   Average expected performance O(n) = n log2n
   Worst case : O(n^2)*/
#endregion

#region TR
/* Dizilerin parçalanma maliyeti : O(n)

 O(log2 n) durumunda tek elema inecektir.

 Ortalama olarak beklenen performans O(n) = n log2n yani algoritmsa n log2n olacak şekilde performans beklenir. 
 Bu algoritmanın beklenen performansı n log2n olma durumu durumu tartışmaya açıktır

 Algoritmanın en iyi durumu küçük bir optimize ile O(n) olacaktır. Klasik QuickShort ile O(n) durumu ortaya çıkmaz!. 
 Algoritmanın en kötü durumu sıralanmış bir listeyi tekrar sıralamaya çalıştığında ortaya çıkar. Yani en kötü durumu = O(n^2) */
#endregion
class QuickSort
{
    static int Partition(List<int> list, int low, int high)
    {
        //1. Select a pivot point. 
        int pivot = list[high];

        int lowIndex = (low - 1);

        //2. Reorder the collection.
        for (int j = low; j < high; j++)
        {
            if (list[j] <= pivot)
            {
                lowIndex++;

                int temp = list[lowIndex];
                list[lowIndex] = list[j];
                list[j] = temp;
            }
        }

        int temp1 = list[lowIndex + 1];
        list[lowIndex + 1] = list[high];
        list[high] = temp1;

        return lowIndex + 1;
    }

    static void Sort(List<int> list, int low, int high)
    {
        if (low < high)
        {
            int partitionIndex = Partition(list, low, high);

            //3. Recursively continue sorting the array
            Sort(list, low, partitionIndex - 1);
            Sort(list, partitionIndex + 1, high);
        }
    }

    public static List<int> RandomList(int n)
    {
        Random random = new();
        List<int> list = new();

        for (int i = 0; i < n; i++)
        {
            list.Add(random.Next(1, 100));
        }

        return list;
    }

    public static int EnterNum()
    {
        string num;
        int n;
        Console.WriteLine("Please enter 32bit int number : ");
        num = Console.ReadLine();
        n = Int32.Parse(num);

        return n;
    }
    public static void Main()
    {
        int n = EnterNum();
        List<int> list = RandomList(n);

        Console.WriteLine("Before QuickSort");
        foreach (var x in list)
        {
            Console.WriteLine(x);
        }

        Sort(list, 0, list.Count - 1);

        Console.WriteLine("After QuickSort");
        foreach (var x in list)
        {
            Console.WriteLine(x);
        }
        Console.ReadKey();
    }
}