using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Create_User
    {

        public string name;

        /// <summary>
        /// Создание пользователя 
        /// </summary>
        public User CreateUser()
        {

            // Создание пользователей
            string RandomId = Guid.NewGuid().ToString("N");

            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();

            Console.WriteLine("Введите фамилию");
            string surname = Console.ReadLine();

            Console.WriteLine("Введите свой возраст");
            int age = Int32.Parse(Console.ReadLine());

            User ObjectUser = new User { Name = name, SurName = surname, Age = age, Id = RandomId };
            return ObjectUser;//    Возвращаем значение с переменной

        }
    }
}

