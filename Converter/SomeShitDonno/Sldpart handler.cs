using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Sldpart_handler
{


    public Sldpart_handler(string PathToFile)
    {
        Console.WriteLine("Создание обработчика файлов формата SLDPRT..." +
            "\nПроверка файла...");
        if (CheckFile(PathToFile))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Проверка пройдена успешно." +
            "\nОбработчик создан.");
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Файл несоответствует формату.");
        }
            
    }

    private static bool CheckFile(string PathToFile)
    {
        int StringTrimmedLenght = PathToFile.Length - 6;

        string TrimmedPath = PathToFile.Substring(StringTrimmedLenght);

        if (TrimmedPath == "SLDPRT")
            return true;
        else
            return false;

    }
}

