using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaolinCheck.Common;

namespace Shaolin_Kung_Fu
{
    class ClubViewModel : ViewModel
    {
        private RelayArgCommand<Team> _selectTeamCommand;

        public RelayArgCommand<Team> SelectTeamCommand
        {
            get
            {
                _selectTeamCommand = new RelayArgCommand<Team>(SetSelectedObject);
                return _selectTeamCommand;
            }
            private set { _selectTeamCommand = value; }
            
        }
        public override void SetSelectedObject(object obj)
        {
            Team t = (Team) obj;
            SCommon.SelectedTeam = t;
        }
    }
}
