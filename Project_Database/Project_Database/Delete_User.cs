using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{

    internal class Delete_User
    {

        public static void DeleteUser()
        {
            Application_Context ConnectDatabase = new Application_Context();//Подлкючаем базу данных

            var elementsDatebase = ConnectDatabase.DatabaseProject_Database.ToList();// Получаем данные с базы данных

            Console.WriteLine("Введите ID для удаления");
            Console.WriteLine("");
            foreach (var item in elementsDatebase)//    Перебираем базу данных и выводим на экран ID пользователей 
            {
                Console.WriteLine(item.SurName + " " + item.Name + "|" + "ID пользователя: " + item.Id);
                Console.WriteLine("");
            }
            Console.Write("Ввод: ");
            string userdelete = Console.ReadLine();
            Console.Clear();


            foreach (var item in elementsDatebase)//     Перебираем базу данных и удаляем введённых пользователей
            {

                try
                {
                    if (item.Id == userdelete)
                    {
                        ConnectDatabase.DatabaseProject_Database.Attach(item);
                        ConnectDatabase.DatabaseProject_Database.Remove(item);
                        ConnectDatabase.SaveChanges();
                        Console.WriteLine("Идёт процесс удаления");
                        Thread.Sleep(1000);
                        Console.Clear();
                        Console.WriteLine("Пользователь был удалён");
                        Thread.Sleep(1000);

                    }
                    else
                    {
                        Console.WriteLine("Поиск ID: " + userdelete);

                        Thread.Sleep(2000);
                        Console.Clear();

                    }
                    
                }

                catch
                {
                    Console.WriteLine("ошибка");

                }
            }
            Console.WriteLine($"Пользователя с ID: {userdelete} | нет в текущей базе данных\nНажмите ENTER для продолжения использования программы");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
                  
                

       

  



