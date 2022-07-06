using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


internal class BC
{

    static public void ColorConsolePrint(string OutText, string Color)
    {
        switch (Color)
        {
            case "Red":
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(OutText);
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "Green":
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(OutText);
                Console.ForegroundColor = ConsoleColor.White;
                break;
            case "Yellow":
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(OutText);
                Console.ForegroundColor = ConsoleColor.White;
                break;
        }
    }

}

