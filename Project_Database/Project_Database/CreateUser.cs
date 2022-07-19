using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Database
{
    public class Create_User
    {
        /// <summary>
        /// Создание пользователя 
        /// </summary>
        
        public User CreateUser()
        {
            Position_Txt PositionTxt = new Position_Txt();


            // Создание пользователей
            string RandomId = Guid.NewGuid().ToString("N");

            Console.Write("Введите имя: ");
            string name = Console.ReadLine();

            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();

            while (true)
            {
                Console.Write("Введите свой возраст: ");
                try
                {
                    int age = Int32.Parse(Console.ReadLine());
                    User ObjectUser = new User { Name = name, SurName = surname, Age = age, Id = RandomId };
                    return ObjectUser;//    Возвращаем значение с переменной
                }
                catch (Exception)
                {
                    Console.Clear();
                    Console.WriteLine("Неправильно введён возраст");
                    Console.WriteLine("Ввести заново (1)\nОтменить дейсвтия (Нажмите любую клавишу)");
                    string ErorAge = Console.ReadLine();
                    Console.Clear();

                    if (ErorAge == "1")
                    {

                        continue; // Код ниже выполнятся не будет благодаря (continue) и мы вернемся в начало цикла while

                    }

                    else
                    {     
                        Console.WriteLine("Отмена действия");
                        Thread.Sleep(1000);
                        Console.Clear();
                        return null;                       
                    }
                }
            }
        }
    }
}
    


