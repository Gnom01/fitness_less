using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        public List<User>Users { get; }
        public User CurrentUser { get; }
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"></param>
       public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть null", nameof(userName));
            }

            Users = GetUsersData();

            CurrentUser = Users.SingleOrDefault(u => u.Name == userName);

            if(CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;
                Save();
            }

        }

        /// <summary>
        /// Получить список пользователя 
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        private List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("using.dat", FileMode.OpenOrCreate))
            {
                //if(fs.Position == 0)
                //{
                //    return new List<User>();
                //}
                //else 
                if (fs.Length > 0 && formatter.Deserialize(fs) is List<User> Users)
                {
                    return Users;
                }
               else
                {
                    return new List<User>();
                }
            }
        }
        public void SretNewUserData(string genderNamie, DateTime birthDate, double weight = 1, double height = 1 )
        {
            // Проверка
            CurrentUser.Gender = new Gender(genderNamie);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;
            Save();
        }
        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("using.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, Users);
            }
        }  
    }
}
