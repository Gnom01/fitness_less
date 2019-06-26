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

            Console.WriteLine("Введите пол. ");
            var gendet = Console.ReadLine();

            Console.WriteLine("Введите дату рождения ");
            var birtDate = DateTime.Parse(Console.ReadLine()); //TODO переписать 

            Console.WriteLine("Введите вес.");
            var weight = double.Parse(Console.ReadLine()); ;

            Console.WriteLine("Введите рост. ");
            var height = double.Parse(Console.ReadLine());

            var UserController = new UserController(name, gendet, birtDate, weight, height);
            UserController.Save();
        }
    }
}
