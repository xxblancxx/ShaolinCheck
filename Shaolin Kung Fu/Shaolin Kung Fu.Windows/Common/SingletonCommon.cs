using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Shaolin_Kung_Fu.Annotations;

namespace Shaolin_Kung_Fu
{
    class SingletonCommon : INotifyPropertyChanged
    {
        private static SingletonCommon _instance = new SingletonCommon();
        private ObservableCollection<Club> _clubList;
        private ObservableCollection<Team> _teamList;
        private ObservableCollection<Student> _studentList;
        private ObservableCollection<Registration> _registrationList;

        public Club SelectedClub { get; set; }
        public Team SelectedTeam { get; set; }
       // public Student SelectedStudent { get; set; }
        public ObservableCollection<Club> ClubList
        {
            get { return _clubList; }
            set
            {
                if (Equals(value, _clubList)) return;
                _clubList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Team> TeamList
        {
            get { return _teamList; }
            set
            {
                if (Equals(value, _teamList)) return;
                _teamList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Student> StudentList
        {
            get { return _studentList; }
            set
            {
                if (Equals(value, _studentList)) return;
                _studentList = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Registration> RegistrationList
        {
            get { return _registrationList; }
            set
            {
                if (Equals(value, _registrationList)) return;
                _registrationList = value;
                OnPropertyChanged();
            }
        }

        public static SingletonCommon Instance
        {
            get { return _instance; }
           private set {}
        }

        //private Constructor, only Instance can initialize.
        private SingletonCommon(){}

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
