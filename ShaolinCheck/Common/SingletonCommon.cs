using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShaolinCheck.Annotations;

namespace ShaolinCheck
{
    class SingletonCommon : INotifyPropertyChanged
    {
        private static SingletonCommon instance = new SingletonCommon();
        private Club _selectedClub;
        private List<Team> _teamList;
        private List<Student> _studentList;
        public bool ClubListLoaded { get; set; }
        public Team SelectedTeam { get; set; }

        public List<Team> TeamList
        {
            get { return _teamList; }
            set { _teamList = value; OnPropertyChanged(); }
        }

        public List<Student> StudentList
        {
            get { return _studentList; }
            set { _studentList = value; OnPropertyChanged(); }
        }

        public Club SelectedClub
        {
            get { return _selectedClub; }
            set { _selectedClub = value; OnPropertyChanged();}
        }
        
        public Student SelectedStudent { get; set; }
        public static SingletonCommon Instance
        {
            get { return instance; }
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
