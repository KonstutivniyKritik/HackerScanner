using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


internal class Analiser
{


    string[] Adresses =
        {"C:/Analise/check/1.txt",
         "C:/Analise/check/2.txt",
         "C:/Analise/check/3.txt",
         "C:/Analise/check/4.txt" };

    public int NumberOfFile { get; set; } = 4;

    public static FileToAnalise[] FilesToAnalise;

    /*      Soft Version
    public Analiser()
    {
        Repeat: //GoTo метка
        Console.WriteLine("Введите количество анализируемых файлов:");
        NumberOfFile = Convert.ToInt32(Console.ReadLine());
        Adresses = new string[NumberOfFile];
        Console.Clear();
        Console.WriteLine($"Количество анализируемых файлов = {NumberOfFile}" +
            $"\n Укажите расположение файлов:");
        for (int i = 0; i < NumberOfFile; i++)
        {
            Console.Write($"Файл {i + 1}: ");
            Adresses[i] = Console.ReadLine();

            string path = Adresses[i];

            FileInfo fileInfo = new(path);
            if (fileInfo.Exists)
            {
                Console.WriteLine($"Файл {i + 1}");
                Console.WriteLine($"Имя файла: {fileInfo.Name}");
                Console.WriteLine($"Время создания: {fileInfo.CreationTime}");
                Console.WriteLine($"Размер: {fileInfo.Length} Байт");
            }
            else
            {
                BC.ColorConsolePrint("Файл не найден", "Red");
                i--;
            }

        }

        Console.Clear();
        Console.WriteLine("Файлы для анализа:");
        for (int i = 0; i < NumberOfFile; i++)
        {
            string path = Adresses[i];
            Console.WriteLine($"Файл {i + 1}");
            FileInfo fileInfo = new(path);
            Console.WriteLine($"Имя файла: {fileInfo.Name}");
        }
        Console.WriteLine("Все верно? (1 - да, 2 - нет)");
        int Choose = Convert.ToInt32(Console.ReadLine());
        if (Choose == 1)
        {
            FilesToAnalise = new FileToAnalise[NumberOfFile];
            for ( int i = 0; i < NumberOfFile; i++)
            {
                FilesToAnalise[i] = new FileToAnalise(GetFilePath(i));
            }
            BC.ColorConsolePrint("Анализатор создан.", "Green");
        }
            
        else
        {
            Console.Clear();
            goto Repeat;
        }
           
        
    */

    public Analiser()
    {
        FilesToAnalise = new FileToAnalise[NumberOfFile];
        for (int i = 0; i < NumberOfFile; i++)
        {
            Console.WriteLine($"File {i}. Path {GetFilePath(i)}");
            FilesToAnalise[i] = new FileToAnalise(GetFilePath(i));
        }
            
    }
    public string GetFilePath(int Index)
    {
        try
        {
            return Adresses[Index];
        }
        catch
        {
            return "Out of index";
        }
    }

    public void Process(int MinWordSize, int MaxWordSize)
    {
        bool[] CheckArray = new bool[NumberOfFile];
        CheckArray[0] = true;
        int StartIndex = 0;
        string FileZero = Adresses[0];

        byte[]? bytes = File.ReadAllBytes(FileZero);
        string BinaryFileString = Program.ToBinary(bytes);
        Console.WriteLine("File zero in binary:");
        Console.WriteLine(BinaryFileString);

        try
        {
            while (true)
            {
                string ToFind = BinaryFileString.Substring(StartIndex, MinWordSize);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"\tTry {ToFind}");
                Console.ResetColor();
                //Отправляем в массив файлов для анализа
                for (int i = 1; i < NumberOfFile; i++)
                {
                    CheckArray[i] = FilesToAnalise[i].SearchString(ToFind);

                    if (CheckArray[i] == false)
                    {
                        ToFind = "";
                        StartIndex += 10;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\tNAH\n");
                        Console.ResetColor();
                        break;
                    }
                    
                    Console.WriteLine($"Found {ToFind} in file {i}");
                    

                    if (i == NumberOfFile - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"\tFound {ToFind}\n");
                        Console.ResetColor();
                        StartIndex += 10;
                        break;
                        //File.AppendAllText("C:/analise/outlog.log", sb.ToString());
                    }
                    

                }               
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine("\nEnd Of analise. See resaults in C:/analise/Ouput.log");
        }
    }
}

