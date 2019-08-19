﻿using System;
using Task1;

namespace Practical_tasks
{
    class Program
    {
        public static bool IsTestingFinished;

        private static void Main()
        {
            Console.WriteLine("Практичнi завдання");

            while(!IsTestingFinished)
            {
                Console.WriteLine("Виберiть подальшi дiї \n" +
                    "1 - Перевiрити перше завдання\n" +
                    "2 - Перевiрити друге завдання\n" +
                    "0 - Завершити перевiрку\n" +
                    "clear - Очистити консоль\n");

                string index = Console.ReadLine();

                switch (index)
                {
                    case "1":
                        Console.Clear();
                        FirstTask.Check();
                        break;
                    case "2":
                        Console.Clear();
                        CheckSecondTask();
                        break;
                    case "0":
                        IsTestingFinished = true;
                        break;
                    case "clear":
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Немає такого варiанту!");
                        break;
                }
            }
        }


        public static void CheckSecondTask()
        {
            Console.WriteLine("Цей таск ще не реалiзований!");
        }


    } 
}