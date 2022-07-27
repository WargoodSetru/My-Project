using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace wcf_chat
{
    [ServiceContract(CallbackContract = typeof(IServerChatCallback))]
    public interface IServiceChat
    {
        /// <summary>
        /// Подключение
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        int Connect(string name);

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
        void SendMsg(string msg, int id);
    }
    public interface IServerChatCallback
    {
        [OperationContract(IsOneWay = true)]
        void MsgCallback(string msg);
    }
}
