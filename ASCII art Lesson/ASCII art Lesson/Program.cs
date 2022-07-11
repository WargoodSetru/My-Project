using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ASCII_art_Lesson
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {


            var openFileDialog = new OpenFileDialog
            {
                Filter = "Images | *.bmp; *.png; *.jpg; *.JPEG"// Фильтр файлов для открытия
            };

            while (true)// Цикл программы
            {
                Console.ReadLine();

                if (openFileDialog.ShowDialog() != DialogResult.OK)//открываем картинку и проверяем результат
                    continue;// Если статус не ок, то программа начинается заново(Переходим в начало цикла)

                Console.Clear();//Чистим консоль
            }


        }
    }
}
