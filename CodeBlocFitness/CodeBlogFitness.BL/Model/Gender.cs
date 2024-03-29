﻿using System;


namespace CodeBlogFitness.BL.Model
{/// <summary>
 /// Пол.
 /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Создать новый пол
        /// </summary>
        /// <param name="name"> Имя пола </param>
        public Gender (string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пла не может быть пустым или null", nameof(name));
            }
            Name = name;

        }
        /// <summary>
        /// Присвоения значения стринга
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return Name; ;
        }
    }
}
