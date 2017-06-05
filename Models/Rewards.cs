using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DSTVWebApp.Models
{
    public partial class Rewards
    {
        public int RewardsID { get; set; }
        public string RewardName  { get; set; }
        public string Description { get; set; }
        public byte[] Image { get; set; }
        public DateTime ClosingDate { get; set; }
    }
}