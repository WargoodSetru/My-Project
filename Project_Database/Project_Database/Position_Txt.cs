using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Project_Database
{   
    /// <summary>
    /// Установка позиции текста (left/top)
    /// </summary>
    internal class Position_Txt
    {
        protected static int origRow;
        protected static int origCol;

    /// <summary>
    /// вывод текста по позициям
    /// </summary>
    /// <param name="s"> Текст </param>
    /// <param name="x"> Расстояние от края </param>
    /// <param name="y"> Расстояние от вверха</param>
        public void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
           
        }
        
    }
}
