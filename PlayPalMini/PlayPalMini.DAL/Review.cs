namespace PlayPalMini.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Review")]
    public partial class Review
    {
        public Guid Id { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string Title { get; set; }

        [Column(TypeName = "text")]
        public string Comment { get; set; }

        public int Rating { get; set; }

        public Guid BoardGameId { get; set; }

        public virtual BoardGame BoardGame { get; set; }
    }
}
