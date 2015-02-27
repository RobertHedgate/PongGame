namespace Pong.Model
{
    using Windows.Foundation;
    using Pong.ViewModels;

    public class Ball : BaseVm
    {
        public Point Position { get; set; }
        public Point Speed { get; set; }
        public int Radius { get; set; }
    }
}