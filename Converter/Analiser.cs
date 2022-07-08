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
    int? SoftWordSize;
    static public string? SoftOutlog;
    int? BitShift = 10;

    public Analiser(Setup setup)
    {
        if (setup == Setup.Soft)
        {
            Repeat: //GoTo метка
            Console.WriteLine("Введите количество анализируемых файлов:");
            try
            {
                NumberOfFile = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.Clear();
                goto Repeat;
            }
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

            Console.WriteLine("Set minimum word size by letters. \n" +
                              "Example: Word <<Properties>> Word size = 10");
            SoftWordSize = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Set Byte Shift. Skip if there no byte shift in file");
            try { BitShift = Convert.ToInt16(Console.ReadLine()); }
            catch { BitShift = 0; };
            Console.WriteLine("Set ouput log file path");
            SoftOutlog = Console.ReadLine();

        }

        //Hard setup continue below
        //Dont touch
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

    public void Process(int MinWordSize)
    {

        bool[] CheckArray = new bool[NumberOfFile];
        CheckArray[0] = true;
        int StartIndex = 0;
        string FileZero = Adresses[0];
        string HardOutlog = "C:/outlog.txt";

        byte[]? bytes = File.ReadAllBytes(FileZero);
        string BinaryFileString = Program.ToBinary(bytes);
        //Console.WriteLine("File zero in binary:");
        //Console.WriteLine(BinaryFileString);

        if (SoftWordSize != null)
            MinWordSize = (int)SoftWordSize * 10;
        if (SoftOutlog != null)
            HardOutlog = SoftOutlog;
        if (BitShift != null)
            StartIndex = (int)BitShift;

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
                    CheckArray[i] = FilesToAnalise[i].SearchString(ToFind, (int)BitShift);

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
                        File.AppendAllText(HardOutlog, $"Index <{StartIndex}> Found <{ToFind}> \n");
                        break;
                         
                    }
                }               
            }
        }
        catch(Exception ex)
        {
            //Console.WriteLine($"Исключение: {ex.Message}");
            //Console.WriteLine($"Метод: {ex.TargetSite}");
            //Console.WriteLine($"Трассировка стека: {ex.StackTrace}");
            File.AppendAllText(HardOutlog, $"Index <000> Found <00000000  00000000  00000000  00000000 > ");
            Console.WriteLine($"\nEnd Of analise. See resaults in {HardOutlog}");
        }
    }

        public enum Setup
    {
        Hard,
        Soft
    }
}

