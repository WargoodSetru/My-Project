using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace Project_Database
{
    /// <summary>
    /// Взаимодействие с базой данных
    /// </summary>
    public class ApplicationContext : DbContext
    {
        /// <summary>
        /// Создание базы данных
        /// Вводим название базы данных
        /// Set<User> - подключаем класс пользователей
        /// </summary>
        public DbSet<User> DatabaseProject_Database => Set<User>();
        /// <summary>
        /// Подключение бд
        /// </summary>
        public ApplicationContext() => Database.EnsureCreated();
        /// <summary>
        /// Сохраняем бд в папку Source с названиме Project_Database.db
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Project_Database.db");
        }
    }
}

