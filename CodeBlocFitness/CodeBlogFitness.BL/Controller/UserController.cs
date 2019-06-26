
using CodeBlogFitness.BL.Model;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    class UserController
    {
        /// <summary>
        /// Пользователь приложения
        /// </summary>
        private readonly User User;
        /// <summary>
        /// Создание нового контроллера
        /// </summary>
        /// <param name="user"></param>
       public UserController(User user)
        {
            this.User = user ?? throw new ArgumentNullException("Пользователь не может быть Null ",nameof(user));
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
        /// <summary>
        /// Получить данные пользователя 
        /// </summary>
        /// <returns>Пользователь приложения</returns>
        public User Load()
        {
            var formatter = new BinaryFormatter();
            using (var fs = new FileStream("using.dat", FileMode.OpenOrCreate))
            {
                return formatter.Deserialize(fs) as User;
            }
        }
    }

}
