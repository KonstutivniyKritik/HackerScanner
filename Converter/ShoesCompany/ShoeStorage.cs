using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Converter.ShoesCompany
{
    internal class ShoeStorage<T> where T : Shoes
    {
        T[]? Array;

        public ShoeStorage(params T[] Arr)
        {
            Array = Arr;
        }

        public void AddToStorage(params T[] Arr)
        {
            int Lenght = Arr.Length + Array.Length;
            T[] Buffer = Array;
            Array = new T[Lenght];
            Array = Buffer;

            int i = 0;
            foreach (T n in Arr)
            {
                i++;
                Array[Array.Length + i] = n;
            } 
            
        }

        public void DeleteFromStorage(int StartIndex, int NumberOfElements)
        {
            if (Array == null)
            {
                Console.WriteLine("Массив пуст. Операцию удаления недоступна");
                return;
            }

            if (StartIndex < 0 || StartIndex > Array.Length)
            {
                Console.WriteLine("Невозможные индекс начала");
                return;
            }
                
            int DeletedCount = 0;
            for (int i = 0; i < NumberOfElements; i++)
            {
                if (i + StartIndex < Array.Length)
                    DeletedCount++;
                else
                {
                    break;
                }   
            }

            int EndIndex = StartIndex + DeletedCount;

            T[] Buffer = new T[Array.Length - DeletedCount];
            int BufferCount = 0;
            for (int i = 0; i < Array.Length; i++)
            {
                if (i > StartIndex || i < EndIndex)
                    continue;
                else
                {
                    Buffer[BufferCount] = Array[i];
                    BufferCount++;
                }
            }

            Array = new T[Buffer.Length];
            Array = Buffer;
        }

        public void GetShoeInfo(int Index)
        {
            T Show = Array[Index];
            Show.PrintInfo();
        }


    }
}
