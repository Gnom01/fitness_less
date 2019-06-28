using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlogFitness.BL.Model
{
    [Serializable]
    public class Food
    {
        public string Name { get; }
        /// <summary>
        /// Белки
        /// </summary>
        public double Proteins { get; set; }
        /// <summary>
        /// Жиры
        /// </summary>
        public double Fats { get; set; }
        /// <summary>
        /// Угливоды
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Колории за 100гр. продукта
        /// </summary>
        public double Calories { get; }


        public Food (string name): this (name, 0, 0, 0, 0) { }
    
        public Food (string name, double proteins, double fats, double carbohydrates, double calories)
        {//TODO: проверка
            Name = name;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Carbohydrates = carbohydrates / 100.0;
            Calories = calories / 100.0;
        }
        public override string ToString()
        {
            return Name;
        }
    }

}
