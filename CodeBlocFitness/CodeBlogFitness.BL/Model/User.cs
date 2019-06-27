using System;

namespace CodeBlogFitness.BL.Model
{/// <summary>
/// Пользователь 
/// </summary>
  [Serializable]
    public class User
    {
        #region
        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Дата рождения
        /// </summary>
        public DateTime BirthDate { get; set; }
        /// <summary>
        /// Вес
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост
        /// </summary>
        public double Height { get; set; }

        // DataTime nowData = DataTime.Today;
        // int age = nowData.Year - birthDate.Year;
        // if(birthDate > NowDate.AddYears(-age)) age --; 

        public int Age { get { return DateTime.Now.Year - BirthDate.Year; } }

        #endregion
        /// <summary>
        /// Создать нового пользователя
        /// </summary>
        /// <param name="name">Имя</param>
        /// <param name="gender">Пол</param>
        /// <param name="birtDate">Дата рождения</param>
        /// <param name="weight"> Вес</param>
        /// <param name="height">Рост</param>
        public User(string name, 
                    Gender gender, 
                    DateTime birtDate, 
                    double weight, 
                    double height)
        {
            #region Проверка кода

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым", nameof(name));
            }
            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть пустой", nameof(gender));
            }
            if(birtDate == DateTime.Parse("01.01.1900") || birtDate >= DateTime.Now )
            {
                throw new ArgumentException("Невозможная дата рождения", nameof(birtDate));
            }
            if(weight <=0)
            {
                throw new ArgumentException("Вес не может быть меньше или равен 0", nameof(weight));
            }
            if(height <=0)
            {
                throw new ArgumentException("Рост не может быть меньше или равен 0", nameof(height));
            }
            #endregion
            Name = name;
            Gender = gender;
            BirthDate = birtDate;
            Weight = weight;
            Height = height; 
        }


        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пла не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " " + Age;
        }
    }
}
