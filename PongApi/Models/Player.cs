using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PongApi.Models
{
    public class Player
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int Score { get; set; }  
    }
}
