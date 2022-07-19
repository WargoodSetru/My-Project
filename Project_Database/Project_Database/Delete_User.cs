using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{

    internal class Delete_User
    {

        public  void DeleteUser()
        {
            Application_Context ConnectDatabase = new Application_Context();//Подлкючаем базу данных
            

            //Console.WriteLine("Введите ID пользователя для удаления");
     

            User ObjectUser = new User();
            ConnectDatabase.DatabaseProject_Database.Remove(ObjectUser);// Добавляем элементы в базу данных
            ConnectDatabase.SaveChanges();// Сохраняем изменения в базе данных
            Console.WriteLine("Объекты успешно удалены");



            return;

        }


    }

}



