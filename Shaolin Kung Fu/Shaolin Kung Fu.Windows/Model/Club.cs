using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shaolin_Kung_Fu.Annotations;
using Shaolin_Kung_Fu.Common;

namespace Shaolin_Kung_Fu
{
    class Club
    {
        private string _name;
        private SingletonCommon _sCommon;
        private List<Team> _teamList;

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value;  }
        }

        public int Id { get; set; }
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

        //public string Address { get; set; }

        public Club(string name, int id /*string address*/)
        {
            Name = name;
            Id = id;
            _sCommon = SingletonCommon.Instance;
            TeamList = new List<Team>();
           

        }

        
        

       
    }
}
