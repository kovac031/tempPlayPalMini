using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayPalMini.MVC.Models
{
    public class BoardGameView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double AvgRating { get; set; }
    }
}