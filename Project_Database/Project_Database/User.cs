using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Database
{

    public class User
    {
        /// <summary>
        /// Идентификатор
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// Фамилия
        /// </summary>
        public string? SurName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
    }

    //public class adduser : User
    //{
    //    public adduser()
    //    {

    //        // Создание пользователей
    //        string RandomId = Guid.NewGuid().ToString("N");

    //        Console.WriteLine("Введите имя");
    //        string name = Console.ReadLine();

    //        Console.WriteLine("Введите фамилию");
    //        string surname = Console.ReadLine();

    //        Console.WriteLine("Введите свой возраст");
    //        int age = Int32.Parse(Console.ReadLine());

    //        User ObjectUser = new User { Name = name, SurName = surname, Age = age, Id = RandomId };

    //    }
    //}

}








