using System;

class Program
{
    public static string Reverse(string text)
    {
        string result = "";

        for (int i = text.Length - 1; i >= 0; i--)
        {
            result += text[i];
        }

        return result;
    }

    static void Main()
    {
        Console.WriteLine("Введите строку:");
        string text = Console.ReadLine();

        string result = Reverse(text);

        Console.WriteLine("Строка наоборот: " + result);
        
        if (result == Reverse(text))
        {
            Console.WriteLine("Строка усешно перевернута");
        }
    }
}