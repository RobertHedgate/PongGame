using System;
using System.Collections.Generic;
using System.Text;

namespace Pong.Model
{
    using Pong.ViewModels;

    public class Result : BaseVm
    {
        public string Winner { get; set; }
        public int Player1Points { get; set; }
        public int Player2Points { get; set; }
    }
}
