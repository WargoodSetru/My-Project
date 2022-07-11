using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Project_Database
{
    public class DeleteObjectDatebase
    {

        public void DeleteBook(List<User> b, int id) // Удаление книги из списка
        {
            Console.ReadLine();
            var itemToDelete = b.Where(x => x.Id == id).Select(x => x).First();
            b.Remove(itemToDelete);
        }

    }
}
