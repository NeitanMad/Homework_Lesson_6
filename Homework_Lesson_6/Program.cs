using System;
using System.Diagnostics;
using System.Linq;

namespace Homework_Lesson_6
{
    class Program
    {
        static void Main(string[] args)
        {
            var processList = Process.GetProcesses(); // получаем массив процессов
            foreach (var proc in processList)
            {
                Console.WriteLine($"ID: {proc.Id} \t Name: {proc.ProcessName} ");
            }

            Console.Write("Введите Имя или ID процесса,который хотите завершить: ");
            string nameproc = Console.ReadLine();

            try // проверка по id
            {

                processList.First(i => i.Id.ToString() == nameproc).Kill();
                Console.WriteLine($"Поцесс {nameproc} завершен..");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"ID процесса: {nameproc} не найден!");
            }

            try // проверка по имени
            {
                processList.First(s => s.ProcessName.ToLower() == nameproc.ToLower()).Kill();
                Console.WriteLine($"Процесс {nameproc} завершен..");
            }
            catch (InvalidOperationException)
            {
                Console.WriteLine($"Имя процесса: {nameproc} не найдено!");
            }
        }
    }
}
