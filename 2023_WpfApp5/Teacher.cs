using System.Collections.ObjectModel;

namespace _2023_WpfApp5
{
    internal class Teacher
    {
        public String TeacherName { get; set; }
        public ObservableCollection<Course> TeachingCourses { get; set; }

        public Teacher()
        {
            this.TeachingCourses = new ObservableCollection<Course>();
        }
    }
}
