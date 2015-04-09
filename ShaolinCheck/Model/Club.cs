using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShaolinCheck.Annotations;

namespace ShaolinCheck
{
    class Club : INotifyPropertyChanged
    {
        private string _name;
        private SingletonCommon _sCommon;
        private List<Team> _teamList;

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value; OnPropertyChanged(); }
        }

        public int Id { get; set; }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged();
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
            LoadTeams();

        }

        public async void LoadTeams()
        {
            try
            {
                if (_sCommon.SelectedClub != null)
                {
                    var tmplist = await GetAllTeams();

                    foreach (var team in tmplist)
                    {
                        if (team.Club.Equals(_sCommon.SelectedClub.Id))
                        {
                            TeamList.Add(team);
                        }
                    }
                    _sCommon.TeamList = TeamList;
                }
            }
            catch (HttpRequestException)
            {

                LoadTeams();
            }

        }

        public async Task<List<Team>> GetAllTeams()
        {
            WSContext wsContext = new WSContext();
            var temp = await wsContext.GetAllTeams();
            return new List<Team>(temp);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
