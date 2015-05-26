using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaolinCheck.Common;

namespace Shaolin_Kung_Fu
{
    class StartViewModel : ViewModel
    {
        private RelayArgCommand<Club> _selectClubCommand;
        public RelayArgCommand<Club> SelectClubCommand
        {
            get
            {
                _selectClubCommand = new RelayArgCommand<Club>(SetSelectedObject);
                return _selectClubCommand;
            }
            set { _selectClubCommand = value; }
        }
        public override void SetSelectedObject(Object club)
        {
            Club c = (Club)club;
            SCommon.SelectedClub = c;
        }

        public void GetAllFromDatabase()
        {
            LoadClubs();
            LoadTeams();
            LoadStudents();
            LoadRegistrations();
        }

        public StartViewModel()
        {
            GetAllFromDatabase();
        }
        private async void LoadClubs()
        {
            SCommon.ClubList = await WsContext.GetAllClubs();
        }
        private async void LoadTeams()
        {
            SCommon.TeamList = await WsContext.GetAllTeams();
        }
        private async void LoadStudents()
        {
            SCommon.StudentList = await WsContext.GetAllStudents();
        }
        private async void LoadRegistrations()
        {
            SCommon.RegistrationList = await WsContext.GetAllRegistrations();
        }


    }
}
