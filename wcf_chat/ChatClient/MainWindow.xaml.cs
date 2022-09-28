using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ChatClient.ServiceChat;

namespace ChatClient
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, IServiceChatCallback
    {
        bool isConnected = false;
        ServiceChatClient client;
        int ID;
        public MainWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Событие при открытие окна: 
        /// Когда открывается окно приложение создается клиент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Подключаемся
        /// </summary>
        void ConnectUser()
        {

            if (!isConnected)
            {
                client = new ServiceChatClient(new System.ServiceModel.InstanceContext(this));
                ID = client.Connect(tbUserName.Text);
                tbUserName.IsEnabled = false;// Не меняем значение имени
                bConnDiscon.Content = " Отключение ";
                isConnected = true;
            }
        }
        /// <summary>
        /// Отключаемся
        /// </summary>
        void DisConnectUser()
        {
            if (isConnected)
            {
                client.DisConnect(ID);
                client = null;
                tbUserName.IsEnabled = true;//  Меняем значение имени
                bConnDiscon.Content = " Подключение ";
                isConnected = false;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (isConnected)
            {
                DisConnectUser();
            }
            else
            {
                ConnectUser();
            }
        }




        /// <summary>
        /// Событие при закрытие окна:
        /// Отключение пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DisConnectUser();
        }

        private void tbMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (client != null)
                {
                    client.SendMsg(tbMessage.Text, ID);
                    tbMessage.Text = string.Empty;
                }
            }
        }

        public void MsgCallback(string msg)
        {
            lbChat.Items.Add(msg);// добавления сообщения 
            lbChat.ScrollIntoView(lbChat.Items[lbChat.Items.Count - 1]);// Для скрола за сообщениями 
        }
    }
}
