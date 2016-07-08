using System;

public class Calculation
{
    public static double PI = 3.14159;
    public static double PLANCK_CONSTANT = 6.62606896e-34;

    public static double ReducePlanck()
    {
        return PLANCK_CONSTANT / (2 * PI);
    }
}
class Startup
{
    static void Main()
    {
        Console.WriteLine(Calculation.ReducePlanck());
    }
}