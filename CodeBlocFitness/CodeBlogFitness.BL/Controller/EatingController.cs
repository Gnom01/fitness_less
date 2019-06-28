using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
   public class EatingController : ControllerBase
    {
        private const string FOOD_FILE_NAME = "foods.dat";
        private const string EATING_FILE_NAME = "eatings.dat";
        private readonly User user;

        public List<Food> Foods { get; }

        public Eating Eating { get; }

        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentException("Пользоваетль не может быть пустой", nameof(user));
            Foods = GetAllFoods();
            Eating = GetEating();
        }
       
        public void Add(Food food, double weight)
        {
            var product = Foods.SingleOrDefault(f => f.Name == food.Name);
            if(product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
            }
        }

        public List<Food> GetAllFoods()
        {
            return Load<List<Food>>(FOOD_FILE_NAME) ?? new List<Food>();
        }

        public Eating GetEating() 
        {
           return Load<Eating>(EATING_FILE_NAME) ?? new Eating(user);
        }

        private void Save()
        {
            Save(FOOD_FILE_NAME, Foods);
            Save(EATING_FILE_NAME, Eating);
        }
    }
}
