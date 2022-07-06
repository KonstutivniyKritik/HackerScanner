using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class FileToAnalise
{
    public FileToAnalise(string Path) => FilePath = Path;

    string FilePath { get; set; }

    public void BooleanReadFile()
    {
        byte[]? bytes = File.ReadAllBytes(FilePath);

        StringBuilder sb = new StringBuilder();

        foreach (byte b in bytes)
        {
            sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
        }
    }

    public bool SearchString(string ToFind)
    {
        int StartIndex = 0;

        byte[]? bytes = File.ReadAllBytes(FilePath);
        string BinaryFileString = Program.ToBinary(bytes);

        try
        {
            while (true)
            {
                string TryFoundString = BinaryFileString.Substring(StartIndex, ToFind.Length);
                //Console.ForegroundColor = ConsoleColor.Yellow;
                //Console.WriteLine(TryFoundString);
                if (TryFoundString == ToFind)
                    return true;
                else
                    StartIndex += 10;
            }
        }
        catch
        {
            return false;
        }    
    }
}

