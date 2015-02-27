using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Pong.Model;

namespace Pong.ViewModels
{
    public class BaseVm : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public BaseVm()
        {
            Server.Socket.On("players", PlayerMessage);
            Server.Socket.On("players", PlayerMessage);
            Server.Socket.On("players", PlayerMessage);
            Server.Socket.On("players", PlayerMessage);
            Server.Socket.On("players", PlayerMessage);
            Server.Socket.On("players", PlayerMessage);


        }

        private void PlayerMessage(object data)
        {
        }
    }
}
