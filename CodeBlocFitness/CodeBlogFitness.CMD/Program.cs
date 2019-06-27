using CodeBlogFitness.BL.Model;
using System;
using CodeBlogFitness.BL.Controller;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi Gnom");

            Console.WriteLine("Введите имя пользователя");
            var name = Console.ReadLine();

            var UserController = new UserController(name);
            if(UserController.IsNewUser)
            {
                Console.Write("Ввидите пол: ");
                var gender = Console.ReadLine();
                var birthDate = PasreDateTime();
                var weight = ParseDouble("вес");
                var height = ParseDouble("рост");

                UserController.SretNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine(UserController.CurrentUser);
            Console.ReadLine();
        }

        private static DateTime PasreDateTime()
        {
            DateTime birthDate;
            while (true)
            {
                Console.Write("Введите дату рождения (dd.MM.yyyy): ");
                if (DateTime.TryParse(Console.ReadLine(), out birthDate))
                {
                    break;
                }
                else
                {
                    Console.WriteLine($"Не верный формат даты: ");
                }
            }
         return birthDate;
        }

        private static double ParseDouble(string name)
        {
            while (true)
            {
                Console.Write($"Введите {name}:");
                if (double.TryParse(Console.ReadLine(), out double value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine($"Не верный формат {name}");
                }
            }
        }
    }
}
