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
    class Registration : INotifyPropertyChanged
    {
        private Student _studentObject;
        private DateTime _timeStamp;
        public int Id { get; set; }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }


        public int Student { get; set; }

        public Student StudentObject
        {
            get { return _studentObject; }
            set { _studentObject = value; OnPropertyChanged(); }
        }

        public async void GetName()
        {
            var context = new WSContext();
            var student = await context.GetStudent(Student);
            StudentObject = student;
        }
        public Registration(int student)
        {
            TimeStamp = DateTime.Now;
            Student = student;
            GetName();
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
