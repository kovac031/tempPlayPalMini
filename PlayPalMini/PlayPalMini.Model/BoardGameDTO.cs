using PlayPalMini.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayPalMini.Model
{
    public class BoardGameDTO : IBoardGame
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; } 
        public double AvgRating { get; set; }
    }
}
