using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Project_Database;




using (Application_Context ConnectDatabase = new Application_Context())

{

    Position_Txt PositionTxt = new Position_Txt();


    

    while (true)
    {
        var ListUser = ConnectDatabase.DatabaseProject_Database.ToList();
        Console.WriteLine("Зарегистрировано пользователей: " + ListUser.Count);
        PositionTxt.WriteAt("Меню приложения", 48, 0);
        PositionTxt.WriteAt("Записаться - Нажмите цифру (1) ", 43, 2);
        PositionTxt.WriteAt("Просмотреть список участников - Нажмите цифру (2) ", 33, 4);
        PositionTxt.WriteAt("Выйти - Нажмите цифру (3) ", 43, 6);
        PositionTxt.WriteAt("Удалить данные (4)", 47, 8);
        PositionTxt.WriteAt("Ввод: ", 0, 10);



        string Menu = Console.ReadLine();

        Console.Clear();

        switch (Menu)
        {
            case "1":
                Create_User user = new Create_User();
                User ObjectUser = user.CreateUser();

                if (ObjectUser == null)
                {
                    continue;
                }
                Console.Clear();
                Console.WriteLine($"Проверьте введенные вами данные\n" + "Имя: " + ObjectUser.Name + "\nФамилия: " + ObjectUser.SurName + "\nВозраст: " + ObjectUser.Age);
                Console.WriteLine("");
                Console.WriteLine("Отрпавить данные?\nДа    (1)\nНет   (Нажмите любую клавишу для отмены действия)\nРедактировать данные?    (3)");

                //SendUserDatebase - Выбор пользователя на сохранение данных
                string SendUserDatebase = Console.ReadLine();
                Console.Clear();
                if (SendUserDatebase == "1")
                {
                    // добавляем их в бд
                    ConnectDatabase.DatabaseProject_Database.Add(ObjectUser);// Добавляем элементы в базу данных
                    ConnectDatabase.SaveChanges();// Сохраняем изменения в базе данных
                    Console.WriteLine("Объекты успешно сохранены");
                    Console.WriteLine($"Ваш ID ({ObjectUser.Id.Substring(0, 4)}) Запишите его");
                    Console.WriteLine("");
                    Console.WriteLine("Нажмите любую клавишу для продолжения");
                    Console.ReadLine();
                    Thread.Sleep(1000);
                    Console.Clear();
                }

                else
                {
                    Console.Clear();
                    continue;
                }
                break;

            case "2":
                //получаем объекты из бд и выводим на консоль
                var Users = ConnectDatabase.DatabaseProject_Database.ToList();
                Console.WriteLine("Список Участников:");


                if (Users.Count > 0)//  Count > 0твечает за кол-во элементов в массиве
                {
                    foreach (User @object in Users)
                    {
                        Console.WriteLine("__________________________ ");
                        Console.WriteLine($"ID({@object.Id.Substring(0, 4)})." + "Имя: " + @object.Name + "\nФамилия: " + @object.SurName + "\nВозраст: " + @object.Age);
                    }
                }
                else
                {
                    Console.WriteLine(" Список пуст");
                }

                Console.WriteLine("Для продолжения нажмите ENTER");
                Console.ReadLine();
                Console.Clear();
                break;

            case "3":
                Environment.Exit(0);


                break;


            case "4":

                Delete_User.DeleteUser();
               

                break;


            default:
                Console.WriteLine("Невернное введенное значение!");
                continue;
        }
    }
}
























//// Создание пользователей
//string RandomId = Guid.NewGuid().ToString("N");
//    Console.WriteLine("Введите свое имя");
//    string name = Console.ReadLine();
//    Console.WriteLine("Введите свой возраст");
//    int age = Int32.Parse(Console.ReadLine());
//    User ObjectUser = new User { Name = name, Age = age, Id = RandomId };

//    // добавляем их в бд
//    ConnectDatabase.Users.Add(ObjectUser);
//    ConnectDatabase.SaveChanges();
//    Console.WriteLine("Объекты успешно сохранены");

//    // получаем объекты из бд и выводим на консоль
//    var users = ConnectDatabase.Users.ToList();
//    Console.WriteLine("Список объектов:");
//    foreach (User @object in users)
//    {
//        Console.WriteLine($" ID({@object.Id.Substring(0, 4)}). {@object.Name} - {@object.Age}");
//    }
//}

