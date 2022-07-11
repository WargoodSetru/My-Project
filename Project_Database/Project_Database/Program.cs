﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_Database;



    using (ApplicationContext db = new ApplicationContext())
    {
        // создаем два объекта User
        User tom = new User { Name = "Tom", Age = 33 };
        User alice = new User { Name = "Alice", Age = 26 };


        // добавляем их в бд
        db.Users.Add(tom);
        db.Users.Add(alice);
        db.SaveChanges();
        Console.WriteLine("Объекты успешно сохранены");

        // получаем объекты из бд и выводим на консоль
        var users = db.Users.ToList();
        Console.WriteLine("Список объектов:");
        foreach (User u in users)
        {
            Console.WriteLine($"{u.Id}.{u.Name} - {u.Age}");
        }

        db.Users.Add(tom);
    Console.WriteLine(tom.ToString);
    }

