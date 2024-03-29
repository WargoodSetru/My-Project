﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    /// <summary>
    /// Поведение сервиса: 
    /// Single - Все клиенты которые будут подлючены к нашему хосту буду работать с нашим сервисом(для чата это хорошо)
    /// Persessiom - Как только клинет подключился для него создается новая сессия, при отключение уничтожается
    /// PerCall - При каждом обращение клиаента будет создан новый сервис, а после использования удалён
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]

    public class ServiceChat : IServiceChat
    {
        /// <summary>
        /// Список пользователей 
        /// </summary>
        List<ServerUser> users = new List<ServerUser>();
        int nextId = 1;// для генерации ID

        /// <summary>
        /// Метод подключения: 
        /// Передаем имя для подключения
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public int Connect(string name)
        {
            ServerUser user = new ServerUser()
            {
                ID = nextId,
                Name = name,
                operationContext = OperationContext.Current

            };

            nextId++;// Увеличиваем ID на 1 с каждым новым user

            SendMsg(user.Name + " " + " Подключился к чату! ", 0);
            users.Add(user);//Добавляем нового пользователя в список 
            return user.ID;
        }

        /// <summary>
        ///Удаление пользователя по ID 
        /// </summary>
        /// <param name="id"></param>
        public void DisConnect(int id)
        {
            var user = users.FirstOrDefault(x => x.ID == id);//     ищем пользователя по ID в списке 
            if (user != null)// Если переменой которую мы ищем не будет, пользователь будет равен null
            {
                users.Remove(user);// Удаляем пользователя из списка
                SendMsg(user.Name + " " + " Покинул чат ", 0);
            }

        }

        public void SendMsg(string msg, int id)
        {
            foreach (var item in users)
            {
                string answer = DateTime.Now.ToShortTimeString();// Время сообщения

                var user = users.FirstOrDefault(x => x.ID == id);//     ищем пользователя по ID в списке 
                if (user != null)// Если переменой которую мы ищем не будет, пользователь будет равен null
                {
                     answer += " : " + " - " + user.Name + " ";// Добавим в времени сообщеня имя usera
                }
                answer += msg;
                item.operationContext.GetCallbackChannel<IServerChatCallback>().MsgCallback(answer);
            }
        }
    }
}
