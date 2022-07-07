using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


internal class Analiser
{
    //hard setup start

    //set files path down below
    string[] Adresses =
        {"C:/Analise/0.SLDPRT",
         "C:/Analise/1.SLDPRT",
         "C:/Analise/2.SLDPRT",
         "C:/Analise/3.SLDPRT" };

    //set number of files down below
    public int NumberOfFile { get; set; } = 4;

    //hard setup end

    public static FileToAnalise[] FilesToAnalise;

    //Soft setup

    public Analiser(Setup setup)
    {
        if (setup == Setup.Soft)
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
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Файл не найден", "Red");
                    Console.ResetColor();
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
                for (int i = 0; i < NumberOfFile; i++)
                {
                    FilesToAnalise[i] = new FileToAnalise(GetFilePath(i));
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Анализатор создан.");
                Console.ResetColor();
            }

            else
            {
                Console.Clear();
                goto Repeat;
            }

            Console.WriteLine();
        }
        else
        {
            FilesToAnalise = new FileToAnalise[NumberOfFile];
            for (int i = 0; i < NumberOfFile; i++)
            {
                Console.WriteLine($"File {i}. Path {GetFilePath(i)}");
                FilesToAnalise[i] = new FileToAnalise(GetFilePath(i));
            }
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
        //Console.WriteLine("File zero in binary:");
        //Console.WriteLine(BinaryFileString);

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
                        File.AppendAllText("C:/analise/outlog.log", $"Wordl lenght <{MinWordSize}> Index <{StartIndex}> Found <{ToFind}> \n");
                        break;
                         
                    }
                    

                }               
            }
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Исключение: {ex.Message}");
            Console.WriteLine($"Метод: {ex.TargetSite}");
            Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            //Console.WriteLine("\nEnd Of analise. See resaults in C:/analise/Ouput.log");
        }
    }

        public enum Setup
    {
        Hard,
        Soft
    }
}

