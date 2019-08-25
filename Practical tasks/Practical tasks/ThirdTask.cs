using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class ThirdTask
    {
        public static List<Person> persons = new List<Person>();

        private const int COUNT_OF_STRINGS_ON_ONE_PAGE = 5;
        private const int MIN_COUNT_OF_STRING_IN_LIST = 1000;
        private const int MAX_COUNT_OF_STRING_IN_LIST = 1500;
        private const int LENGTH_OF_GENERATED_STRINGS = 4;

        public static void Check()
        {
            bool IsTestingFinished = false;

            while (!IsTestingFinished)
            {
                Console.WriteLine("Робота з третiм завданням \n" +
                    "1 - Перевiрити перше i другу частину\n" +
                    "2 - Перевiрити третю частину\n" +
                    "0 - Завершити перевiрку\n" +
                    "clear - Очистити консоль\n");

                string index = Console.ReadLine();

                switch (index)
                {
                    case "1":
                        Console.Clear();
                        FirstPart();
                        SecondPart();
                        break;
                    case "2":
                        Console.Clear();
                        ThirdPart();
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

        #region First Part
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

            for (var i = 0; i < count; i++)
            {
                Console.WriteLine($"Створення {i + 1}-ої персони.");
                persons.Add(CreatePerson());
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

        #endregion

        #region Second Part

        private static void SecondPart()
        {
            Console.Clear();
            Console.WriteLine("Введiть данi ще однiєї персони!");
            Person firstPerson = CreatePerson();

            Console.Clear();
            Console.WriteLine("Введiть данi ще однiєї персони!");
            Person secondPerson = CreatePerson();
            
            Console.Clear();
            persons.AddRange(new List<Person> { firstPerson, secondPerson });

            PrintPersonsNumbers();
        }

        private static void PrintPersonsNumbers()
        {
            for(var i = 0; i < persons.Count; i++)
            {
                Console.WriteLine($"Мобiльнi номери {i+1}-ої персони");
                persons[i].PrintPhoneNumbers();
                Console.WriteLine();
            }

            Console.ReadKey();
            Console.Clear();
        }

        #endregion

        #region Third Part

        public static void ThirdPart()
        {
            List<string> stringArray = GenerateList();

            stringArray = RemoveDuplicates(stringArray);

            stringArray = RemoveStringWhichIsStartedWithZ(stringArray);

            stringArray = ProcessTheList(stringArray);

            WorksWithPages(stringArray);

            Console.ReadKey();
        }

        private static List<string> GenerateList()
        {
            List<string> stringList = new List<string>();

            Random random = new Random();
            int count = random.Next(MIN_COUNT_OF_STRING_IN_LIST, MAX_COUNT_OF_STRING_IN_LIST);

            for (var i = 0; i < count; i++)
            {
                stringList.Add(GenerateString(LENGTH_OF_GENERATED_STRINGS, false));
            }

            return stringList;
        }

        public static string GenerateString(int length, bool upperCase)
        {
            StringBuilder sb = new StringBuilder();
            Random random = new Random();
            char symbol;
            for (int i = 0; i < length; i++)
            {
                symbol = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                sb.Append(symbol);
            }
            if (upperCase)
                return sb.ToString().ToUpper();
            return sb.ToString();
        }

        private static List<string> RemoveDuplicates(List<string> inputList)
        {
            List<string> duplicatesArray = new List<string>();

            List<string> temp = new List<string>(inputList);

            HashSet<string> unique = new HashSet<string>(temp);

            foreach (var value in unique)
            {
                temp.Remove(value);
            }

            foreach (var value in temp)
            {
                duplicatesArray.Add(value);
            }

            foreach (var value in duplicatesArray)
            {
                inputList.Remove(value);
            }

            return inputList;
        }

        private static List<string> RemoveStringWhichIsStartedWithZ(List<string> stringList)
        {
            List<string> clearedList = stringList;

            for (int i = stringList.Count - 1; i >= 0; i--)
            {
                if (stringList[i].StartsWith('Z'))
                {
                    clearedList.RemoveAt(i);
                }
            }

            return clearedList;
        }

        public static void WorksWithPages(List<string> inputList)
        {
            Console.WriteLine("Робота зi сторiнками");
            Console.Write("Введи номер сторiнки: ");
            int.TryParse(Console.ReadLine(), out int page);

            bool isViewingAvailable = true;

            while(isViewingAvailable)
            {
                PrintPage(inputList, page);

                Console.Write("Для продовдення натиснiть будь-яку кнопку...");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("Робота зi сторiнками");
                Console.Write("Введи номер сторiнки: ");
                int.TryParse(Console.ReadLine(), out page);

                isViewingAvailable = IsPageValidated(page, inputList.Count);
            }
        }

        private static void PrintPage(List<string> inputString, int page)
        {
            int startIndex = (page - 1) * COUNT_OF_STRINGS_ON_ONE_PAGE;
            for(var i = 0; i < COUNT_OF_STRINGS_ON_ONE_PAGE; i++)
            {
                Console.WriteLine(inputString[startIndex + i]);
            }
        }

        private static List<string> ProcessTheList(List<string> inputList)
        {
            inputList.Sort();
            inputList.Reverse();
            return inputList;
        }

        private static bool IsPageValidated(int page, int listLength)
        {
            if(page <= 0 || ((page - 1) * COUNT_OF_STRINGS_ON_ONE_PAGE) > listLength)
            {
                return false;
            }

            return true;
        }

        #endregion

        public static Person CreatePerson()
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

            return person;
        }
    }
}
