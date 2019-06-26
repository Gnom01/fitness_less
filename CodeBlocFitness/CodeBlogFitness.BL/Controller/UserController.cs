﻿using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

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
       private readonly User User;
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"></param>
       public UserController(string userName, string genderName, DateTime birdthDay, double weight, double height)
        {
            //TODO: Проверка
            var gender = new Gender(genderName);
            User = new User(userName, gender, birdthDay, weight, height);
        }
        /// <summary>
        /// Получить данные пользователя 
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("using.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
                // TODO: что делать если пользователя не прочитали
            }
        }

        /// <summary>
        /// Сохранить данные пользователя
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("using.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }
        
    }

}
