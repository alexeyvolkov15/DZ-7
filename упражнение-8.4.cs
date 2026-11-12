using System;

class Program
{
    public static bool CheckFormat(object value)
    {
        if (value is IFormattable)
        {
            IFormattable format = value as IFormattable;

            return format != null;
        }

        return false;
    }

    static void Main()
    {
        int number = 100;
        double dnumber = 10.5;
        string text = "Привет";
        bool trurh = true;

        Console.WriteLine(CheckFormat(number));
        Console.WriteLine(CheckFormat(dnumber));
        Console.WriteLine(CheckFormat(text));
        Console.WriteLine(CheckFormat(trurh));
    }
}
