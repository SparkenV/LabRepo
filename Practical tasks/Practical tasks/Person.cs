using System;
using System.Collections.Generic;
using System.Text;

namespace Task3
{
    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public IEnumerable<string> PhoneNumbers { get; set; }

        public void PrintName()
        {
            Console.WriteLine($"Iм'я персони - \"{Name}\"");
        }

        public void PrintAge()
        {
            Console.WriteLine($"Вiк персони - \"{Name}\"");
        }

        public void PrintPhoneNumbers()
        {
            foreach (var number in PhoneNumbers)
            {
                Console.WriteLine(number);
            }
        }
    }
}