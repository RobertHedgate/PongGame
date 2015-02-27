using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Pong.Model;
using Quobject.SocketIoClientDotNet.Client;

namespace Pong.ViewModels
{
    public class MainPageVm : BaseVm
    {
        public MainPageVm()
        {
            Server.Socket = IO.Socket("http://jaywaypongserver.herokuapp.com");
            Server.Socket.On(Socket.EVENT_CONNECT, () => { });
            Server.Socket.On("players", (data) =>
            {
                var s = data;
            });

        }

        public string Name { get; set; }

        public void LogIn()
        {
            var obj = new JObject {{"playername", Name}};
            Server.Socket.Emit("add player", obj);
        }
    }
}
