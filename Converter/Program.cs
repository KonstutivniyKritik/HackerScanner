using System.Text;
using System;
public class Program
{
     static void Main(string[] args)
    {
        Analiser? A = new(Analiser.Setup.Soft);
        A.Process(MinWordSize: 100);
        OutlogHandler H = new();
        H.Handle();
       
        
    }

    public static string FileToBinaryString(string FilePath)
    {
        byte[]? bytes = File.ReadAllBytes(FilePath);
        return ToBinary(bytes);
    }

    public static String ToBinary(Byte[] data)
    {
        return string.Join("  ", data.Select(byt => Convert.ToString(byt, 2).PadLeft(8, '0')));
    }
}



    

    

