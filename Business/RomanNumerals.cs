using System.Diagnostics;

namespace Business;

public static class RomanNumerals
{
    private static readonly Dictionary<char, int> Numerals = new()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    public static int Parse(string numerals)
    {
        if (string.IsNullOrEmpty(numerals))
            return 0;

        var result = 0;

        for (var i = 1; i <= numerals.Length; i++)
        {
            var currentNumber = Numerals[numerals[i - 1]];

            if (i == numerals.Length)
            {
                result += currentNumber;
                break;
            }

            var nextNumber = Numerals[numerals[i]];

            if (currentNumber >= nextNumber)
                result += currentNumber;
            else
                result -= currentNumber;

        }

        return result;
    }

}