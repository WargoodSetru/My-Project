using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{

    internal class Delete_User
    {

        public  static void DeleteUser()
        {
            Application_Context ConnectDatabase = new Application_Context();//Подлкючаем базу данных
           
            var elementsDatebase = ConnectDatabase.DatabaseProject_Database.ToList();// Получаем данные с базы данных

            Console.WriteLine("Введите ID для удаления");

            foreach (var item in elementsDatebase)//    Перебираем базу данных и выводим на экран ID пользователей 
            {
                Console.WriteLine( "ID пользователей: " + item.Id);
                Console.WriteLine("");
            }


            Console.Write("Ввод: ");
            string userdelete = Console.ReadLine();
            Console.Clear();


            foreach (var item in elementsDatebase)//     Перебираем базу данных и удаляем введённых пользователей
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
                    Console.Clear();
                }
              
            }
            






        }


    }

}



