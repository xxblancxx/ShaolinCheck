namespace _4._5._1Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kgpython_shaolin.Registration")]
    public partial class Registration
    {
        public int Id { get; set; }

        public int Student { get; set; }

        [Column(TypeName = "date")]
        public DateTime TimeStamp { get; set; }

        public virtual Student Student1 { get; set; }
    }
}
