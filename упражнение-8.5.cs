using System;
using System.IO;

class Program
{
    public static void SearchMail(ref string s)
    {
        int index = s.IndexOf('#');

        if (index != -1)
        {
            s = s.Substring(index + 1);
        }
    }

    static void Main()
    {
        string inputFile = "входнойФайл.txt";
        string outputFile = "выходнойФайл.txt";

        string[] lines = File.ReadAllLines(inputFile);

        using (StreamWriter writer = new StreamWriter(outputFile))
        {
            foreach (string line in lines)
            {
                string mail = line;

                SearchMail(ref mail);

                writer.WriteLine(mail);
            }
        }

        Console.WriteLine("Адреса электронной почты записаны в файл");
    }
}
