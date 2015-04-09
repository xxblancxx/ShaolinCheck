using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ShaolinCheck.Annotations;

namespace ShaolinCheck
{
    class Team : INotifyPropertyChanged
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
                OnPropertyChanged();
            }
        }

        public SingletonCommon SCommon
        {
            get { return _sCommon; }
            set { _sCommon = value; }
        }

        public List<Student> StudentList
        {
            get { return _studentList; }
            set { _studentList = value;  OnPropertyChanged();}
        }

        public int Id { get; set; }
        public int Club { get; set; }
        public Team(string name, int id)
        {
            Name = name;
            Id = id;
            StudentList = new List<Student>();
            _sCommon = SingletonCommon.Instance;
            LoadStudents();
           
        }

        public async void LoadStudents()
        {
            try
            {
                if (_sCommon.SelectedTeam != null)
                {
                    var tmplist = await GetAllStudents();

                    foreach (var student in tmplist)
                    {
                        if (student.Team.Equals(_sCommon.SelectedTeam.Id))
                        {
                            StudentList.Add(student);
                        }
                    }
                    _sCommon.StudentList = StudentList;
                }
            }
            catch (HttpRequestException)
            {

                LoadStudents();
            }

        }

        public async Task<List<Student>> GetAllStudents()
        {
            WSContext wsContext = new WSContext();
            var temp = await wsContext.GetAllStudents();
            return new List<Student>(temp);
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
