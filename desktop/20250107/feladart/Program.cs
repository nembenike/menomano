/*
Linq electric boogaloo
Berényi Bence 11.D
2025.01.07
 */

class Program
{
    static void Main()
    {
        // 1.
        List<int> numbers = new List<int>();

        // 2.
        for (int i = 1; i <= 10; i++)
        {
            numbers.Add(i);
        }

        // 3.
        int Square(int num) => num * num;

        // 4.
        List<int> squaredNumbers = numbers.Select(Square).ToList();

        // 5.
        int Sum(List<int> list) => list.Sum();

        // 6.
        List<int> GetEvenNumbers(List<int> list) => list.Where(x => x % 2 == 0).ToList();

        // 7.
        List<int> MultiplyBy(List<int> list, int multiplier) => list.Select(x => x * multiplier).ToList();

        // 8.
        List<T> MergeLists<T>(List<T> list1, List<T> list2)
        {
            List<T> merged = new List<T>();
            int maxLength = Math.Max(list1.Count, list2.Count);
            for (int i = 0; i < maxLength; i++)
            {
                if (i < list1.Count) merged.Add(list1[i]);
                if (i < list2.Count) merged.Add(list2[i]);
            }
            return merged;
        }

        // 9.
        int MaxElement(List<int> list) => list.Max();

        // 10.
        int MinElement(List<int> list) => list.Min();

        // 11.
        bool AreAllEven(List<int> list) => list.All(x => x % 2 == 0);

        // 12.
        List<T> EverySecondElement<T>(List<T> list) => list.Where((x, index) => index % 2 == 0).ToList();

        // 13.
        List<T> ReverseList<T>(List<T> list) => list.AsEnumerable().Reverse().ToList();

        // 14.
        List<string> Capitalize(List<string> list) => list.Select(str => char.ToUpper(str[0]) + str.Substring(1).ToLower()).ToList();

        // 15.
        List<string> LongerThanFive(List<string> list) => list.Where(str => str.Length > 5).ToList();

        Console.WriteLine("Számok: " + string.Join(", ", numbers));
        Console.WriteLine("Számok négyzetei: " + string.Join(", ", squaredNumbers));
        Console.WriteLine("Összeg: " + Sum(numbers));
        Console.WriteLine("Páros számok: " + string.Join(", ", GetEvenNumbers(numbers)));
        Console.WriteLine("Minden elem páros? " + AreAllEven(numbers));
        Console.WriteLine("Lista megfordítva: " + string.Join(", ", ReverseList(numbers)));
    }
}
