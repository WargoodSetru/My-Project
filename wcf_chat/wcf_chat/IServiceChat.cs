﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    // ПРИМЕЧАНИЕ. Можно использовать команду "Переименовать" в меню "Рефакторинг", чтобы изменить имя интерфейса "IServiceChat" в коде и файле конфигурации.
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        /// <summary>
        /// Подключение
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int Connect();
        /// <summary>
        /// Отключение
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        void DisConnect(int id);
        /// <summary>
        /// Принимает сообщение
        /// </summary>
        /// <param name="message"></param>
        [OperationContract(IsOneWay = true)]     // Если нам не нужно ждать ответа от сервера пишем (IsOneWay = true)
        void SendMessage(string message);
    }
    public interface IServerChatCallback
    {
        [OperationContract]
        void MessageCallback(string message);
    } 
}
