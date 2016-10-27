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
                Console.WriteLine("Нажмите 0 для остановки слежения");
                while (Console.Read() != '0');
                ChangesStorage Changes = ChangesStorage.GetInstance();
                Changes.SaveToFile(@"D:\changes.xml", @"D:\backup-files.xml");
            }
            else
            {
                Console.WriteLine("Введите дату и время: ");
                DateTime time; ;
                while (!DateTime.TryParse(Console.ReadLine(), out time))
                {
                    Console.WriteLine("Неверный формат даты и времени!");
                }

                Console.WriteLine("-----------------------------------------------");
                RollBackHandler.RollBackOnTime(time);
                Console.WriteLine("Откат изменений произведен успешно");
            }
        }
    }
}
