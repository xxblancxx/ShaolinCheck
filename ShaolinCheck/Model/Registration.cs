using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaolinCheck
{
    class Registration
    {
        public int Id { get; set; }
        public DateTime TimeStamp { get; set; }

        public Student Student { get; set; }

        public Registration(Student student, int id)
        {
            Id = id;
            TimeStamp = DateTime.Now;
            Student = student;
        }
    }
}
