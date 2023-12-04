using System.Collections.ObjectModel;

namespace _2023_WpfApp5
{
    class Teacher
    {
        public String TeacherName { get; set; }

        public ObservableCollection<Course> TeachingCourses { get; set; }
        public Teacher(string teacherName)
        {
            TeacherName = teacherName;
            TeachingCourses = new ObservableCollection<Course>();
        }

        public override string ToString()
        {
            return TeacherName;
        }
    }
}
