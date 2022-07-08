using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class OutlogHandler
{
    string OutlogPath;
    public OutlogHandler()
    {
       if (Analiser.SoftOutlog != null)
          OutlogPath = Analiser.SoftOutlog;
       else
            OutlogPath = "C:/outlog.txt";
    }

    public void Handle()
    {
        string strN = "";
        string? strNplus1 = "";
        String HanlerOutLog = "";

        

        foreach (string line in System.IO.File.ReadLines(OutlogPath))
        {          
            strN = strNplus1;
            strNplus1 = line;

            if (strN == "")
                continue;

            
            String strNgetIndx = strN.Substring(strN.IndexOf('<') + 1, strN.IndexOf('>'));
            strNgetIndx = strNgetIndx.Substring(0, strNgetIndx.IndexOf('>'));
            int IndxN = Convert.ToInt32(strNgetIndx);
            

            String strNpuls1getIndx = strNplus1.Substring(strNplus1.IndexOf('<') + 1, strNplus1.IndexOf('>'));
            strNpuls1getIndx = strNpuls1getIndx.Substring(0, strNpuls1getIndx.IndexOf('>'));
            int IndxNplus1 = Convert.ToInt32(strNpuls1getIndx);

            Console.WriteLine(OutlogPath);
            Console.WriteLine(IndxNplus1 - IndxN);

            if (IndxNplus1 - IndxN != 10)
            {
                File.AppendAllText("C:/HandlerCheck.txt", $"Word Lenght {HanlerOutLog.Length} Found <{HanlerOutLog}> \n\n");
                Console.WriteLine("I wrote");
                HanlerOutLog = "";
                continue;
            }

            //строка имеет вид
            //Index <180> Found <00010100  .......  00011011  > 
            int DealingSubstring = strN.LastIndexOf('<');
            String strNgetSqnc = strN.Substring(strN.LastIndexOf('<') + 1, strN.LastIndexOf('>') - 1 - DealingSubstring);
            String strNplus1getSqnc = strNplus1.Substring(strNplus1.LastIndexOf('<') + 1, strNplus1.LastIndexOf('>') - 1 - DealingSubstring);
           
            if (HanlerOutLog == "")
                HanlerOutLog = strNgetSqnc + strNplus1getSqnc.Substring(strNplus1getSqnc.Length - 10);
            HanlerOutLog += strNplus1getSqnc.Substring(strNplus1getSqnc.Length - 10);
        }
    }      
}

