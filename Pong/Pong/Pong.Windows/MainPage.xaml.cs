using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Data.Json;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using Quobject.EngineIoClientDotNet.ComponentEmitter;
using Quobject.SocketIoClientDotNet.Client;

namespace Pong
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Socket _socket;

        public MainPage()
        {
            this.InitializeComponent();

            DataContext = App.GameServer;
        }

        private void ConnectButton_OnClick(object sender, RoutedEventArgs e)
        {
            App.GameServer.Name = "Robert123";
            App.GameServer.LogIn();

            ////_socket = IO.Socket("http://localhost:3000");
            ////_socket.On(Socket.EVENT_CONNECT, () =>
            ////{
            ////    var i = 0;
            ////});
            ////return;
            //_socket = IO.Socket("http://jaywaypongserver.herokuapp.com");
            ////_socket = IO.Socket("http://10.0.112.126:3000");
            ////_socket = IO.Socket("http://169.254.80.80:3000");
            ////_socket = IO.Socket("http://10.0.100.10:3000");
            ////_socket = IO.Socket("http://localhost");
            ////_socket = IO.Socket("http://localhost:3000");
            ////_socket = IO.Socket("http://RobertHWork:3000");
            ////_socket = IO.Socket("http://10.0.100.16:3000");
            ////_socket = IO.Socket("http://10.0.112.126:3000");
            ////_socket.Connect();
            ////_socket.Open();

            //_socket.On("message", (data) =>
            //{
            //    var s = data;
            //});

            //_socket.On("players", (data) =>
            //{
            //    var s = data;
            //});

            //_socket.On("step", (data) =>
            //{
            //    var s = data;
            //});

            //_socket.On("winning", (data) =>
            //{
            //    var s = data;
            //});

            //try
            //{
            //    _socket.On(Socket.EVENT_CONNECT, () =>
            //    {

            //        try
            //        {
            //            //var obj = new JObject {{"playername", "RobertX122"}};
            //            //_socket.Emit("add player", obj);
            //            //var obj3 = new JObject { { "playername", "LarsHakanX" } };
            //            //_socket.Emit("add player", obj3);

            //            //var obj2 = new JObject { { "message", "Test" } };
            //            //_socket.Emit("message", obj2);
            //        }
            //        catch (Exception ex)
            //        {
            //        }
            //    });
            //}
            //catch (Exception exception)
            //{
            //}
        }

        private void DisconnectButton_OnClick(object sender, RoutedEventArgs e)
        {
            _socket.Disconnect();
        }
    }
}
