using System;
using System.Collections.Generic;

namespace Task3
{
    class ThirdTask
    {
        public static List<Person> persons = new List<Person>();
        
        public static void Check()
        {
            FirstPart();
        }

        private static void FirstPart()
        {
            GeneratePersons();

            Console.WriteLine("Всi персони створено. " +
                "Щоб вивести їхнi iмена та вiк натиснiть будь-яку клавiшу");
            Console.ReadKey();

            PrintPersonsData();


        }

        private static void GeneratePersons()
        {
            Random random = new Random();
            int count = random.Next(6, 8);

            Console.WriteLine($"Count = {count}");

            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Створення {i + 1}-ої персони.");
                AddPerson();
                Console.Clear();
            }
        }

        private static void PrintPersonsData()
        {
            foreach (var person in persons)
            {
                person.PrintName();
                person.PrintAge();
                Console.WriteLine("-----------------------------");
            }

            Console.ReadKey();
        }

        public static void AddPerson()
        {
            Console.Write("Введiть iм'я особи: ");
            string name = Console.ReadLine();

            Console.Write("Введiть вiк особи: ");
            int.TryParse(Console.ReadLine(), out int age);

            List<string> phoneNumbers = new List<string>();

            Random random = new Random();
            int count = random.Next(3, 5);

            for(var i = 0; i < count; i++)
            {
                Console.Write($"Введи {i+1}-й номер: ");
                phoneNumbers.Add(Console.ReadLine());
            }

            Person person = new Person()
            {
                Name = name,
                Age = age,
                PhoneNumbers = phoneNumbers
            };

            persons.Add(person);      
        }
    }
}
