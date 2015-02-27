namespace Pong.Model
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Xml.Linq;
    using Windows.ApplicationModel.Core;
    using Windows.Foundation;
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Newtonsoft.Json.Linq;
    using Quobject.SocketIoClientDotNet.Client;

    public class Server : INotifyPropertyChanged
    {
        public static Socket Socket;

        public Server()
        {
            //Socket = IO.Socket("http://jaywaypongserver.herokuapp.com");
            Socket = IO.Socket("http://10.0.112.126:3000");
            Socket.On(Socket.EVENT_CONNECT, () =>
            {
                var i = 0;
            });

            ChatMessages = new ObservableCollection<ChatMessage>();

            Socket.On("players", async x => await OnPlayers(x));
            Socket.On("message", async x => await OnMessage(x));
            Socket.On("step", async x => await OnStep(x));
            Socket.On("winning", async x => await OnWinning(x));

        }

        private async Task OnWinning(object obj)
        {
            var jObject = obj as JObject;
            if (jObject == null)
                return;

            var result = new Result
            {
                Winner = (string)jObject["winner"],
                Player1Points = (int)jObject["player1Points"],
                Player2Points = (int)jObject["player2Points"]
            };
            if (result.Winner == Game.Player1.Name || result.Winner == Game.Player2.Name)
            {
                await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () => Result = result);
            }
        }

        private async Task OnStep(object obj)
        {
            var jObject = obj as JObject;
            if (jObject == null)
                return;

            var player1 = new Player
            {
                Name = (string) jObject["players"]["player1"]["name"],
                Score = (int)jObject["players"]["player1"]["score"]
            };

            var player2 = new Player
            {
                Name = (string)jObject["players"]["player2"]["name"],
                Score = (int)jObject["players"]["player2"]["score"]
            };

            var game = new Game
            {
                Ball = new Ball
                {
                    Position = new Point((int) jObject["ball"]["x"], (int) jObject["ball"]["y"]),
                    Speed = new Point((int) jObject["ball"]["x_speed"], (int) jObject["ball"]["x_speed"]),
                    Radius = (int) jObject["ball"]["radius"]
                },
                Court = new Court
                {
                    Size = new Size((double) jObject["bounds"]["width"], (double) jObject["bounds"]["height"])
                },
                PaddleA = new Paddle
                {
                    Rect =
                        new Rect((double) jObject["playerPaddle"]["x"], (double) jObject["playerPaddle"]["y"],
                            (double) jObject["playerPaddle"]["width"], (double) jObject["playerPaddle"]["height"])
                },
                PaddleB = new Paddle
                {
                    Rect =
                        new Rect((double) jObject["remotePlayerPaddle"]["x"],
                            (double) jObject["remotePlayerPaddle"]["y"], (double) jObject["remotePlayerPaddle"]["width"],
                            (double) jObject["remotePlayerPaddle"]["height"])
                },
                Player1 = player1,
                Player2 = player2
            };

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () => Game = game);
        }

        private async Task OnMessage(object obj)
        {
            var jObject = obj as JObject;
            if (jObject == null)
                return;

            var message = new ChatMessage
            {
                Name = (string) jObject["player"],
                Message = (string)jObject["message"]
            };

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () => ChatMessages.Add(message));
            ;
        }

        public void LogIn()
        {
            var obj = new JObject { { "playername", Name } };
            Socket.Emit("add player", obj);
        }

        public void Ready()
        {
            Socket.Emit("ready");
        }

        private async Task OnPlayers(object obj)
        {
            var jObject = obj as JObject;
            if (jObject == null)
                return;

            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(
                CoreDispatcherPriority.Normal, () =>
                Players = new ObservableCollection<Player>(jObject["players"].Select(token => new Player
                {
                    Name = (string)token["name"],
                    State = (string)token["state"],
                
                })));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Player> Players { get; set; }
        public ObservableCollection<ChatMessage> ChatMessages { get; set; }
        public string Name { get; set; }
        public Game Game { get; set; }
        public Result Result { get; set; }
    }
}
