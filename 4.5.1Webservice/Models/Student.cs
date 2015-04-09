namespace _4._5._1Webservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("kgpython_shaolin.Student")]
    public partial class Student
    {
        public Student()
        {
            Registrations = new HashSet<Registration>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(25)]
        public string Name { get; set; }

        public int Team { get; set; }

        public virtual ICollection<Registration> Registrations { get; set; }

        public virtual Team Team1 { get; set; }
    }
}
