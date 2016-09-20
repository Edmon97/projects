using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using SignalRChat.Models;

namespace SignalRChat.Hubs
{
    public class ChatHub : Hub
    {
        static List<User> Users = new List<User>();
        static List<string> Messages = new List<string>();

        public void Hello()
        {
            Clients.All.hello();
        }

        // Отправка сообщений
        public void Send(string name, string message)
        {
            Messages.Add(name + ": " + message);
            Clients.Caller.addMessage(name, message);
            Clients.AllExcept(Context.ConnectionId).addNewMessage();
        }

        public void GetLastMessages(int number)
        {
            List<string> last_messages = Messages.Skip(Math.Max(0, Messages.Count - number)).ToList();
            Clients.Caller.ShowLastMessages(last_messages);
        }

        // Подключение нового пользователя
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;


            if (!Users.Any(x => x.ConnectionId == id))
            {
                Users.Add(new User { ConnectionId = id, Name = userName });

                // Посылаем сообщение текущему пользователю
                Clients.Caller.onConnected(id, userName, Users);

                // Посылаем сообщение всем пользователям, кроме текущего
                Clients.AllExcept(id).onNewUserConnected(id, userName);
            }
        }

        // Отключение пользователя
        public override System.Threading.Tasks.Task OnDisconnected(bool stopCalled)
        {
            var item = Users.FirstOrDefault(x => x.ConnectionId == Context.ConnectionId);
            if (item != null)
            {
                Users.Remove(item);
                var id = Context.ConnectionId;
                Clients.All.onUserDisconnected(id, item.Name);
            }

            return base.OnDisconnected(stopCalled);
        }
    }
}