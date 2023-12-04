using System.Windows;

namespace _2023_WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Student> students = new List<Student>();
        Student selectedStudent = null;

        List<Teacher> teachers = new List<Teacher>();

        List<Course> courses = new List<Course>();
        public MainWindow()
        {
            InitializeComponent();
            InitializeStudent();
            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher("陳定宏");
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二甲" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二乙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "選修", Point = 3, OpeningClass = "四技二丙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Type = "必修", Point = 3, OpeningClass = "五專三甲" });

            Teacher teacher2 = new Teacher("李育強");
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "五專四甲" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "四技三甲" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機數學", Type = "必修", Point = 3, OpeningClass = "四技三乙" });
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳小明" });
            students.Add(new Student { StudentId = "A1234578", StudentName = "王小美" });
            students.Add(new Student { StudentId = "A1236789", StudentName = "黃小琥" });
            cmbStudent.ItemsSource = students;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            DisplayStatus();
        }

        private void DisplayStatus()
        {
            labelStatus.Content = $"選取學生： {selectedStudent.ToString()}" ;
        }
    }
}