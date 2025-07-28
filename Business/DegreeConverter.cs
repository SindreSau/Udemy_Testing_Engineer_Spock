namespace Business;

public class DegreeConverter
{
    public static double ToFahrenHeit(double celsius)
    {
        return (celsius * 9 / 5) + 32;
    }

    public static double ToCelsius(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}