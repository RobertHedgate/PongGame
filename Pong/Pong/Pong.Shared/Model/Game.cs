namespace Pong.Model
{
    using Pong.ViewModels;

    public class Game : BaseVm
    {
        public Ball Ball { get; set; }
        public Court Court { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Paddle PaddleA { get; set; }
        public Paddle PaddleB { get; set; }
    }
}