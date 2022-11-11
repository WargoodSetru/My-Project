using System;

namespace FromNTo10
{
    class Program
    {
     
        static void Main(string[] args)
        {
      string ConvertTo2(string num, int round = 5)
            {
                string result = ""; //Результат
                int left = 0; //Целая часть
                string right = "0"; //Дробная часть
                string[] temp1 = num.Split(new char[] { '.', ',' }); //Нужна для разделения целой и дробной частей
                left = Convert.ToInt32(temp1[0]);
                //Проверяем имеется ли у нас дробная часть
                if (temp1.Count() > 1)
                {
                    right = num.Split(new char[] { '.', ',' })[1]; //Дробная часть
                }
                //Алгоритм перевода целой части в двоичную систему
                while (true)
                {
                    result += left % 2; //В ответ помещаем остаток от деления. В конце программы мы перевернём строку, так как в обратном порядке записываются остатки
                    left = left / 2; //Так как Left целое число, то при делении например числа 2359 на 2, мы получим не 1179,5 а 1179
                    if (left == 0)
                        break;
                }
                result = new string(result.ToCharArray().Reverse().ToArray()); //Реверсирование строки

                //Прокеряем есть ли у нас дробная часть, можно было бы проверить и так if(temp1.count()>1)
                if (Convert.ToInt32(right) == 0)
                    return result;

                //Добавляем разделить целой части от дробной
                result += '.';

                int count = right.ToString().Count(); // Нам нужно знать кол-во цифр, при превышении которого дописывается единичка
                int INTright = Convert.ToInt32(right);

                for (int i = 0; i < round; i++)
                {
                    /*Умножаем число на 2 и проверяем, стало ли оно больше по количеству цифр, если да,
                    то в результат идёт "1" и первая цифра у right удаляется */
                    INTright = INTright * 2;
                    if (INTright.ToString().Count() > count)
                    {
                        string buf = INTright.ToString();
                        buf = buf.Remove(0, 1);
                        INTright = Convert.ToInt32(buf);

                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }
                return result;
            }
            string ConvertTo8(string num, int round = 5)
            {
                string result = ""; //Результат
                int left = 0; //Целая часть
                string right = "0"; //Дробная часть
                string[] temp1 = num.Split(new char[] { '.', ',' }); //Нужна для разделения целой и дробной частей
                left = Convert.ToInt32(temp1[0]);
                //Проверяем имеется ли у нас дробная часть
                if (temp1.Count() > 1)
                {
                    right = num.Split(new char[] { '.', ',' })[1]; //Дробная часть
                }
                //Алгоритм перевода целой части в двоичную систему
                while (true)
                {
                    result += left % 8; //В ответ помещаем остаток от деления. В конце программы мы перевернём строку, так как в обратном порядке записываются остатки
                    left = left / 8; //Так как Left целое число, то при делении например числа 2359 на 2, мы получим не 1179,5 а 1179
                    if (left == 0)
                        break;
                }
                result = new string(result.ToCharArray().Reverse().ToArray()); //Реверсирование строки

                //Прокеряем есть ли у нас дробная часть, можно было бы проверить и так if(temp1.count()>1)
                if (Convert.ToInt32(right) == 0)
                    return result;

                //Добавляем разделить целой части от дробной
                result += '.';

                int count = right.ToString().Count(); // Нам нужно знать кол-во цифр, при превышении которого дописывается единичка
                int INTright = Convert.ToInt32(right);

                for (int i = 0; i < round; i++)
                {
                    /*Умножаем число на 2 и проверяем, стало ли оно больше по количеству цифр, если да,
                    то в результат идёт "1" и первая цифра у right удаляется */
                    INTright = INTright * 8;
                    if (INTright.ToString().Count() > count)
                    {
                        string buf = INTright.ToString();
                        buf = buf.Remove(0, 1);
                        INTright = Convert.ToInt32(buf);

                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }
                return result;
            }
            string ConvertTo16(string num, int round = 5)
            {
                string result = ""; //Результат
                int left = 0; //Целая часть
                string right = "0"; //Дробная часть
                string[] temp1 = num.Split(new char[] { '.', ',' }); //Нужна для разделения целой и дробной частей
                left = Convert.ToInt32(temp1[0]);
                //Проверяем имеется ли у нас дробная часть
                if (temp1.Count() > 1)
                {
                    right = num.Split(new char[] { '.', ',' })[1]; //Дробная часть
                }
                //Алгоритм перевода целой части в двоичную систему
                while (true)
                {
                    result += left % 16; //В ответ помещаем остаток от деления. В конце программы мы перевернём строку, так как в обратном порядке записываются остатки
                    left = left / 16; //Так как Left целое число, то при делении например числа 2359 на 2, мы получим не 1179,5 а 1179
                    if (left == 0)
                        break;
                }
                result = new string(result.ToCharArray().Reverse().ToArray()); //Реверсирование строки

                //Прокеряем есть ли у нас дробная часть, можно было бы проверить и так if(temp1.count()>1)
                if (Convert.ToInt32(right) == 0)
                    return result;

                //Добавляем разделить целой части от дробной
                result += '.';

                int count = right.ToString().Count(); // Нам нужно знать кол-во цифр, при превышении которого дописывается единичка
                int INTright = Convert.ToInt32(right);

                for (int i = 0; i < round; i++)
                {
                    /*Умножаем число на 2 и проверяем, стало ли оно больше по количеству цифр, если да,
                    то в результат идёт "1" и первая цифра у right удаляется */
                    INTright = INTright * 16;
                    if (INTright.ToString().Count() > count)
                    {
                        string buf = INTright.ToString();
                        buf = buf.Remove(0, 1);
                        INTright = Convert.ToInt32(buf);

                        result += '1';
                    }
                    else
                    {
                        result += '0';
                    }
                }
                return result;
            }

            while (true)
            {
                Console.WriteLine("Введите число: ");
                string user_number = Console.ReadLine();
                string user1 = ConvertTo2(user_number, 2);
                string user2 = ConvertTo8(user_number, 8);
                Console.WriteLine("Результат");
                Console.WriteLine($"Двоичная - {user1}");
                Console.WriteLine($"Восьмеричная - {user2}");
                Console.ReadLine();
                Console.Clear();
            }

        }
        }

    }





