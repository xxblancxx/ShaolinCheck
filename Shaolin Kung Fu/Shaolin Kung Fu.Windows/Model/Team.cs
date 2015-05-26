using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shaolin_Kung_Fu;
using Shaolin_Kung_Fu.Annotations;
using Shaolin_Kung_Fu.Common;


namespace Shaolin_Kung_Fu
{
    class Team
    {
        private string _name;
        private SingletonCommon _sCommon;
        private List<Student> _studentList;

        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
               
            }
        }

        public SingletonCommon SCommon
        {
            get { return _sCommon; }
            set { _sCommon = value; }
        }

      
        public int Id { get; set; }
        public int Club { get; set; }
        public Team(string name, int id)
        {
            Name = name;
            Id = id;
        }

       
          

        

    }
}
