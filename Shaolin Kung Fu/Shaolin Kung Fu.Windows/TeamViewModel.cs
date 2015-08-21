using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Popups;
using ShaolinCheck.Common;

namespace Shaolin_Kung_Fu
{
    class TeamViewModel : ViewModel
    {
        private RelayArgCommand<Team> _selectStudentCommand;
        public Student SelectedStudent { get; set; }

        public ObservableCollection<Student> StudentList { get; set; }

       
        public RelayArgCommand<Team> SelectStudentCommand
        {
            get
            {
                _selectStudentCommand = new RelayArgCommand<Team>(SetSelectedObject);
                return _selectStudentCommand;
            }
            private set { _selectStudentCommand = value; }

        }

        public TeamViewModel()
        {
            StudentList = new ObservableCollection<Student>();
            foreach (var s in SCommon.StudentList)
            {
                if (s.Team.Equals(SCommon.SelectedTeam.Id))
                {
                    StudentList.Add(s);
                }
            }
        }
        public async override void SetSelectedObject(object obj)
        {
            Student student = (Student) obj;
            // stuff happens, and Andi is a huge throbbing Cawk
            SelectedStudent = student;
         //   SCommon.SelectedStudent = student;
            var alreadyRegisteredList = new List<Registration>();
            try
            {
                foreach (var reg in SCommon.RegistrationList)
                {
                    if (reg.Student.Equals(student.Id) && reg.TimeStamp.Date.Equals(DateTime.Today))
                    {
                        alreadyRegisteredList.Add(reg);
                    }
                }
                if (alreadyRegisteredList.Count.Equals(0))
                {
                    MsgDialog = new MessageDialog("Vælg handling nedenunder", "Hej " + student.Name);

                    //Register button
                    UICommand rgButton = new UICommand("Mød Ind");
                    rgButton.Invoked = ClickrgButton;
                    MsgDialog.Commands.Add(rgButton);

                    //Cancel button
                    UICommand cancelButton = new UICommand("Annuller");
                    cancelButton.Invoked = ClickcancelButton;
                    MsgDialog.Commands.Add(cancelButton);

                    if (student.Image == null)
                    {
                        UICommand pictureButton = new UICommand("Tilføj Billede");
                     //   pictureButton.Invoked = ClickPictureButton;
                        MsgDialog.Commands.Add(pictureButton);
                    }

                    await MsgDialog.ShowAsync();
                }
                else
                {
                    MsgDialog = new MessageDialog("Du er allerede registreret, god træning!",
                        "Hej " + student.Name);
                    await MsgDialog.ShowAsync();
                }

            }
            catch (TaskCanceledException)
            {

            }
            catch (HttpRequestException)
            {
            }
        }
        private void ClickcancelButton(IUICommand command)
        {
            //cancel, nothing happens.
        }
        private void ClickrgButton(IUICommand command)
        {
            // Register the student

            if (SelectedStudent != null)
            {
                WsContext.CreateRegistration(new Registration(SelectedStudent.Id));
            }
        }
    }
}
