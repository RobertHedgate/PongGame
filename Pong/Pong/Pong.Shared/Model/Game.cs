namespace Pong.Model
{
    using Pong.ViewModels;

    public class Game : BaseVm
    {
        public Ball Ball { get; set; }
        public Court Court { get; set; }
        public Player Player { get; set; }
        public Player RemotePlayer { get; set; }
    }
}