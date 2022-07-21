using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using Newtonsoft.Json;

namespace predicting_the_future
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Переменная Имя приложения
        /// </summary>
        private const string APP_NAME = "Predicting the future";
        /// <summary>
        /// Путь к файлу Json с предсказаниями
        /// </summary>
        private readonly string PREDICTION_CONFIG_PATH = $"{Environment.CurrentDirectory}\\PredictionsConfig.json";// Environment.CurrentDirectory - Определяем путь где находится файл
        /// <summary>
        /// Массив слов с предсказаниями
        /// </summary>
        private string[] _prediction;
        /// <summary>
        /// Рандомное значение
        /// </summary>
        private Random _random = new Random();
        public Form1()
        {
            InitializeComponent();
        }

        private async void bPredict_Click(object sender, EventArgs e)//   async  ассинхронность
        {
            bPredict.Enabled = false;//  Выключаем кнопку

            //  Запуск процесса в отдельном потоке 
            await Task.Run(() =>//  await  ассинхронность
             {
                 for (int i = 1; i <= 100; i++)
                 {
                     this.Invoke(new Action(() =>
                     {

                         UpdateProgressBar(i);
                         this.Text = $"{i}%";


                     }));
                     Thread.Sleep(20);
                 }
             });

            var index = _random.Next(_prediction.Length);//     Рандомное значение из массива по количеству элементов в нём

            var prediction = _prediction[index];

            MessageBox.Show($"{prediction}");


            //  Запуск процесса в отдельном потоке 
            
            progressBar1.Value = 0;//   Сбросим наш прогресс до 0 
            this.Text = APP_NAME;//     Присвоим нашей форме имя вместо % по завершению операции
            bPredict.Enabled = true;//      Включаем кнопку



        }
        /// <summary>
        /// Для красоты анимации бара процессов
        /// Добавляет полосу анимации в конце
        /// </summary>
        /// <param name="i"></param>
        private void UpdateProgressBar(int i)
        {
            if (i == progressBar1.Maximum)
            {
                progressBar1.Maximum = i + 1;   //Временно увеличьте максимальную
                progressBar1.Value = i + 1;     //Пройти мимо
                progressBar1.Maximum = i;       //Перезагрузить максимум
            }
            else
            {
                progressBar1.Value = i + 1;     //Пройти мимо 
            }
            progressBar1.Value = i;     //Перейти к правильному значению
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Text = APP_NAME;
            try
            {
                var data = File.ReadAllText(PREDICTION_CONFIG_PATH);//      Читаем текс по заданному пути

                _prediction = JsonConvert.DeserializeObject<string[]>(data);//  Помещяаем данные в массив _prediction из Json       

            }
            catch (Exception ex)//      Если файла Json нет программа выведет ошибку и закроется 
            {
                MessageBox.Show(ex.Message);//      Выводит ошибку если файла нет 
                Close();        //Закрытие программы
            }
            finally
            {
                if (_prediction == null)
                {
                    Close();
                }
                else if (_prediction.Length == 0)//     Если Json пустой срабоатает этот блок 
                {
                    MessageBox.Show("Предсказаний больше нет");
                    Close();
                }
            }
        }
    }
}

