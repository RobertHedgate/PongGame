using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using Newtonsoft.Json.Linq;
using Quobject.SocketIoClientDotNet.Client;

namespace Pong.Model
{
    public class Server : INotifyPropertyChanged
    {
        public static Socket Socket;

        public Server()
        {
            Socket = IO.Socket("http://jaywaypongserver.herokuapp.com");
            Socket.On(Socket.EVENT_CONNECT, () =>
            {
                var i = 0;
            });

            Socket.On("players", OnPlayers);

        }

        public void LogIn()
        {
            var obj = new JObject { { "playername", Name } };
            Socket.Emit("add player", obj);
        }

        private void OnPlayers(object obj)
        {
            var jObject = obj as JObject;
            if (jObject == null)
                return;

            Players = new ObservableCollection<Player>(jObject["players"].Select(token => new Player
            {
                Name = (string)token["name"],
                State = (string)token["state"],
                
            }));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Player> Players { get; set; }
        public String Name { get; set; }
    }
}
