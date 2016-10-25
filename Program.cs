using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackupSystem
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine("Выберите режим работы:");
            Console.WriteLine("1 - режим наблюдения");
            Console.WriteLine("2 - режим отката изменений");

            int mode;
            while (!int.TryParse(Console.ReadLine(), out mode))
            {
                Console.WriteLine("Неизвестный параметр режима работы");
            }
            
            if (mode == 1)
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Программа работает в режиме наблюдения...");
                Watcher.Start();
            }
            else
            {
                Console.WriteLine("-----------------------------------------------");
                Console.WriteLine("Производится откат изменений...");
            }
        }
    }
}
