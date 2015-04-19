using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using ShaolinCheck.Annotations;
using ShaolinCheck.Common;

namespace ShaolinCheck
{
    class ViewModel : INotifyPropertyChanged
    {
        private List<Club> _clubList;
        private RelayArgCommand<Club> _selectClubCommand;
        private SingletonCommon _sCommon;
        private RelayArgCommand<Team> _selectTeamCommand;
        private RelayArgCommand<Student> _selectStudentCommand;

        public MessageDialog msgDialog { get; set; }
        public WSContext WsContext { get; set; }

        public RelayArgCommand<Student> SelectStudentCommand
        {
            get
            {
                _selectStudentCommand = new RelayArgCommand<Student>(SetSelectedStudent);
                return _selectStudentCommand;
            }
            set { _selectStudentCommand = value; }
        }

        public RelayArgCommand<Team> SelectTeamCommand
        {
            get
            {
                _selectTeamCommand = new RelayArgCommand<Team>(SetSelectedTeam);
                return _selectTeamCommand;
            }
            set { _selectTeamCommand = value; }
        }

        public SingletonCommon SCommon
        {
            get { return _sCommon; }
            private set { _sCommon = value; OnPropertyChanged(); }
        }

        public List<Club> ClubList
        {
            get { return _clubList; }
            set { _clubList = value; OnPropertyChanged(); }
        }

        public void SetSelectedClub(Club c)
        {
            _sCommon.TeamList = new List<Team>();
            _sCommon.SelectedClub = c;

        }

        public Task<ObservableCollection<Registration>> GetRegistrations()
        {
               var regList = WsContext.GetAllRegistrations();
                return regList;
           
        }
        public async void SetSelectedStudent(Student s)
        {
            _sCommon.SelectedStudent = s;
            var alreadyRegisteredList = new List<Registration>();
            try
            {
                var RegList = await GetRegistrations();
                foreach (var reg in RegList)
                {
                    if (reg.Student.Equals(_sCommon.SelectedStudent.Id) && reg.TimeStamp.Date.Equals(DateTime.Today))
                    {
                        alreadyRegisteredList.Add(reg);
                    }
                }
                if (alreadyRegisteredList.Count.Equals(0))
                {
                    msgDialog = new MessageDialog("Vælg handling nedenunder", "Hej " + _sCommon.SelectedStudent.Name);

                    //Register button
                    UICommand rgButton = new UICommand("Mød Ind");
                    rgButton.Invoked = ClickrgButton;
                    msgDialog.Commands.Add(rgButton);

                    //Cancel button
                    UICommand cancelButton = new UICommand("Annuller");
                    cancelButton.Invoked = ClickcancelButton;
                    msgDialog.Commands.Add(cancelButton);

                    await msgDialog.ShowAsync();
                }
                else
                {
                    msgDialog = new MessageDialog("Du er allerede registreret, god træning!",
                        "Hej " + _sCommon.SelectedStudent.Name);
                    await msgDialog.ShowAsync();
                }

            }
            catch (TaskCanceledException)
            {
                new MessageDialog("Der mangler desværre internetforbindelse").ShowAsync();
                
            }
            catch (HttpRequestException)
            {
                new MessageDialog("Der mangler desværre internetforbindelse").ShowAsync();
            }
          
        }

        private void ClickcancelButton(IUICommand command)
        {
            //cancel, nothing happens.
        }
        private void ClickrgButton(IUICommand command)
        {
            // Register the student

            if (_sCommon.SelectedStudent != null)
            {
                WsContext.CreateRegistration(new Registration(_sCommon.SelectedStudent.Id));
            }
        }

        public void SetSelectedTeam(Team t)
        {
            _sCommon.TeamList = new List<Team>();
            _sCommon.SelectedTeam = t;
        }
        public RelayArgCommand<Club> SelectClubCommand
        {
            get
            {
                _selectClubCommand = new RelayArgCommand<Club>(SetSelectedClub);
                return _selectClubCommand;
            }
            set { _selectClubCommand = value; }
        }

        public async void LoadClubs()
        {
            try
            {
                ClubList = await GetAllClubs();
            }
            catch (HttpRequestException)
            {
                LoadClubs();
            }

        }

        public async Task<List<Club>> GetAllClubs()
        {
            var temp = await WsContext.GetAllClubs();
            return new List<Club>(temp);
        }
        public ViewModel()
        {
            WsContext = new WSContext();
            _sCommon = SingletonCommon.Instance;
            LoadClubs();

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
