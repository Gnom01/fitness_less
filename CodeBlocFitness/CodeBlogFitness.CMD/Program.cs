﻿using CodeBlogFitness.BL.Model;
using System;
using CodeBlogFitness.BL.Controller;
using System.Globalization;
using System.Resources;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var culture = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("CodeBlogFitness.CMD.Languages.Massages", typeof(Program).Assembly);
            Console.WriteLine(resourceManager.GetString("Hello" , culture));

            Console.WriteLine(resourceManager.GetString("EnterName", culture));
            var name = Console.ReadLine();

            var UserController = new UserController(name);
            var eatingController = new EatingController(UserController.CurrentUser);

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
            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("Е - ввести прием пищи");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Food, foods.Weight);
                foreach (var item in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{item.Key} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Food Food, double Weight)  EnterEating()
        {
            Console.WriteLine("Введите имя продукта: ");
            var food = Console.ReadLine();

            var calories = ParseDouble("калорийность");
            var prot = ParseDouble("белки");
            var fats = ParseDouble("житы");
            var carbs = ParseDouble("углеводы");
            var weight = ParseDouble("вес порции");
            var product = new Food(food, calories, prot, fats, carbs);

            return (Food: product, Weight:weight);
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
