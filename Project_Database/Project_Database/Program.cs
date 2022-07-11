using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_Database;



using (ApplicationContext database = new ApplicationContext())
{
    // создаем два объекта User





    string RandomId = Guid.NewGuid().ToString("N");

    




    Console.WriteLine("Введите свое имя");
    string name = Console.ReadLine();
    Console.WriteLine("Введите свой возраст");
    int age = Int32.Parse(Console.ReadLine());
    User ObjectUser = new User { Name = name, Age = age, Id = RandomId };

  




    // добавляем их в бд
    database.Users.Add(ObjectUser);
    database.SaveChanges();
    Console.WriteLine("Объекты успешно сохранены");

    // получаем объекты из бд и выводим на консоль
    var users = database.Users.ToList();
    Console.WriteLine("Список объектов:");
    foreach (User @object in users)
    {
        Console.WriteLine($"{@object.Id}.{@object.Name} - {@object.Age}");
    }


    
}

