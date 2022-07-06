using System.Text;
using System;
public class Program
{
     static void Main(string[] args)
    {
        Analiser A = new();
        A.Process(MinWordSize: 50,80);
    }

    void LearningStaff(string FilePath)
    {
        byte[]? bytes = File.ReadAllBytes(FilePath);
        Console.WriteLine(ToBinary(bytes));
    }

    public static String ToBinary(Byte[] data)
    {
        return string.Join("  ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }
    public static byte[] ConvertToByteArray(string str, Encoding encoding)
    {
        return encoding.GetBytes(str);
        
    }

    public static void HexReader(string path)
    {
        // Read the file into <bits>
        var fs = new FileStream(path, FileMode.Open);
        var len = (int)fs.Length;
        var bits = new byte[len];
        fs.Read(bits, 0, len);
        // Dump 16 bytes per line
        for (int ix = 0; ix < len; ix += 16)
        {
            var cnt = Math.Min(16, len - ix);
            var line = new byte[cnt];
            Array.Copy(bits, ix, line, 0, cnt);
            // Write address + hex + ascii
            Console.Write("{0:X6}  ", ix);
            Console.Write(BitConverter.ToString(line));
            Console.Write("  ");
            //Convert non-ascii characters to .
            for (int jx = 0; jx < cnt; ++jx)
                if (line[jx] < 0x20 || line[jx] > 0x7f) line[jx] = (byte)'.';
            Console.WriteLine(Encoding.ASCII.GetString(line));
        }
        Console.ReadLine();
    }

    

    void CheckFindAlg()
    {
        int StartIndex = 0;
        string path = "C:/analise/check/Checknormal";
        string ToFind = "ali";

        while (true)
        {
            string TryFoundString = path.Substring(StartIndex, 3);
            if (TryFoundString == ToFind)
            {
                Console.WriteLine(1);
                Console.WriteLine(StartIndex);
                Console.WriteLine($"{TryFoundString} = {ToFind}");
                break;
            }
            else
                StartIndex++;
        }
    }
}



    

    

