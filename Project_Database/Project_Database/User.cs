using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Database
{
    /// <summary>
    /// Ввод пользователей
    /// </summary>
    public class User
    {
        public int Id { get; set; }//   Идентификатор
        public string? Name { get; set; }// Имя
        public int Age { get; set; }//  Возраст
    }
}
