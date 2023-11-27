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