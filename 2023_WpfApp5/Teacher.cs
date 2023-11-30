using System.Collections.ObjectModel;

namespace _2023_WpfApp5
{
    class Teacher
    {
        //產生教師姓名以及授課科目清單
        public String TeacherName { get; set; }
        public ObservableCollection<Course> TeachingCourses { get; set; }
        public Teacher()
        {
            TeachingCourses = new ObservableCollection<Course>();
        }

    }
}
