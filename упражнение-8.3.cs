using System;
using System.IO;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите имя файла:");
        string file = Console.ReadLine();

        if (!File.Exists(file))
        {
            Console.WriteLine("Файл не существует");
            return;
        }

        string text = File.ReadAllText(file);
        string result = text.ToUpper();

        File.WriteAllText("выходнойФайл.txt", result);

        Console.WriteLine("Файл успешно обработан");
    }
}
