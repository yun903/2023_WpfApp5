using System.Windows;

namespace _2023_WpfApp5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //宣告一個Student物件的清單
        List<Student> students = new List<Student>();
        Student selelectedStudent = null;

        List<Course> courses = new List<Course>();
        List<Teacher> teachers = new List<Teacher>();
        public MainWindow()
        {
            InitializeComponent();

            InitializeStudent();

            InitializeCourse();
        }

        private static void InitializeCourse()
        {
            //新增一個名為陳定宏的老師，教授視窗程式設計課程，並開設在四個不同班級
            Teacher teacher1 = new Teacher() { TeacherName = "陳定宏" };
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Point = 3, Type = "選修", OpeningClass = "四技二甲" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Point = 3, Type = "選修", OpeningClass = "四技二乙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Point = 3, Type = "選修", OpeningClass = "四技二丙" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", Point = 3, Type = "必修", OpeningClass = "五專三甲" });

            Teacher teacher2 = new Teacher() { TeacherName = "吳建中" };
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機程式", Point = 3, Type = "必修", OpeningClass = "四技一丙" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "微處理機應用實務", Point = 3, Type = "必修", OpeningClass = "四技二甲" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "微處理機應用實務", Point = 3, Type = "必修", OpeningClass = "四技二乙" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "微處理機應用實務", Point = 3, Type = "必修", OpeningClass = "四技二丙" });
        }

        private void InitializeStudent()
        {
            //建立Student物件並加入清單，將此清單內容指定給cmbStudent
            students.Add(new Student() { StudentId = "S001", StudentName = "小明" });
            students.Add(new Student() { StudentId = "S002", StudentName = "小華" });
            students.Add(new Student() { StudentId = "S003", StudentName = "小英" });
            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selelectedStudent = cmbStudent.SelectedItem as Student;
            //將此資訊在labelStatus中顯示
            labelStatus.Content = $"學號：{selelectedStudent.StudentId} 姓名：{selelectedStudent.StudentName}";

        }
    }
}