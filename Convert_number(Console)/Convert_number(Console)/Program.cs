using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
	class Program
	{
		static void Main(string[] args)
		{

            while (true)
            {
				try
				{

				Found:
					Console.WriteLine("Введите число: ");
					int user_number = Convert.ToInt32(Console.ReadLine());// Вводим данные с клавиатуры и конвертируем в число
					Console.Clear();

					while (true)
					{

						Console.WriteLine($"Введенные вами данные: {user_number}\n");
						Console.WriteLine("Выбериет систему счисления\n- Двоичная.1\n- Восьмеричная.2\n- Десятичная.3\n- 16-ричная.4\n- Поменять число.5\n- Выход из программы.6");
						string choice = Console.ReadLine();
						Console.Clear();
						switch (choice)
						{
							case ("1"):

								var convert_user2 = Convert.ToString(user_number, 2);
								Console.WriteLine($"Результат Двоичная: {convert_user2}\n");

								break;

							case ("2"):
								var convert_user8 = Convert.ToString(user_number, 8);
								Console.WriteLine($"Результат Восьмеричная: {convert_user8}\n");
								break;

							case ("3"):
								var convert_user10 = Convert.ToString(user_number, 10);
								Console.WriteLine($"Результат Десятичная: {convert_user10}\n");
								break;

							case ("4"):
								var convert_user16 = Convert.ToString(user_number, 16);
								Console.WriteLine($"Результат 16-ричная: {convert_user16}\n");
								break;

							case ("5"):
								goto Found;
								break;


							case ("6"):
								Environment.Exit(0);
								break;

							default:
								Console.WriteLine("Такого значения не существует! Попробуйте ввести заново\n");
								break;
						}

					}
				}
				catch
				{
					Console.WriteLine("Ошибка!  Попробуйте ввести заново\n");
					Thread.Sleep(2000);
					Console.Clear();
				}
			}
		}
        
		}
	}