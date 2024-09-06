namespace IEnumerableGenerator;

public static class YieldProgram
{
    public static void YieldProgramMain()
    {
        foreach (var number in GetNumbers())
        {
            Console.WriteLine(number);  // Prints 1, 2, 3, 4, 5
        }

        foreach (var number in GetNumbersWithStop(3))
        {
            Console.WriteLine(number);  // Prints 1, 2 and then stops
        }
    }
    public static IEnumerable<int> GetNumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            yield return i;  // Returns one number at a time
        }
    }
    public static IEnumerable<int> GetNumbersWithStop(int stopAt)
    {
        for (int i = 1; i <= 5; i++)
        {
            if (i == stopAt)
                yield break;  // Ends the iteration early

            yield return i;
        }
    }
}
