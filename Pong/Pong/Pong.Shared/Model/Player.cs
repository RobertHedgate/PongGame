using Pong.ViewModels;

namespace Pong.Model
{
    public class Player : BaseVm
    {
        public string Name { get; set; }
        public string State { get; set; }
        public int Score { get; set; }
        public Paddle Paddle { get; set; }
    }
}