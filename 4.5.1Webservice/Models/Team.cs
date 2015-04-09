namespace _4._5._1Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kgpython_shaolin.Team")]
    public partial class Team
    {
        public Team()
        {
            Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int Club { get; set; }

        public virtual Club Club1 { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}
