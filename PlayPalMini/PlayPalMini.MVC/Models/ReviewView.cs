using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlayPalMini.MVC.Models
{
    public class ReviewView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public Guid BoardGameId { get; set; }
    }
}