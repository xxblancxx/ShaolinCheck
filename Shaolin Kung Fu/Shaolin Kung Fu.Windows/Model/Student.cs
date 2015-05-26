using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shaolin_Kung_Fu
{
    class Student
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public int Team { get; set; }
        public Student(string name, int id)
        {
            Name = name;
            Id = id;
        }
    }
}
