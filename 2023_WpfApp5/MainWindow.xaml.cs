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
        Teacher selectedTeacher = null;

        List<Course> courses = new List<Course>();
        Course selectedCourse = null;

        List<Record> records = new List<Record>();
        Record selectedRecord = null;
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

            Teacher teacher3 = new Teacher("陳福坤");
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一甲" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一乙" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "計算機概論", Type = "必修", Point = 3, OpeningClass = "資工一丙" });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);
            tvTeacher.ItemsSource = teachers;

            foreach (Teacher teacher in teachers)
            {
                foreach (Course course in teacher.TeachingCourses)
                {
                    courses.Add(course);
                }
            }
            lbCourse.ItemsSource = courses;
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳小明" });
            students.Add(new Student { StudentId = "A1234578", StudentName = "王小美" });
            students.Add(new Student { StudentId = "A1236789", StudentName = "黃小琥" });
            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = $"選取學生： {selectedStudent.ToString()}";
        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvTeacher.SelectedItem is Teacher)
            {
                selectedTeacher = (Teacher)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取老師： {selectedTeacher.ToString()}";
            }

            if (tvTeacher.SelectedItem is Course)
            {
                selectedCourse = (Course)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取課程： {selectedCourse.ToString()}";
            }
        }

        private void lbCourse_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedCourse = (Course)lbCourse.SelectedItem;
            labelStatus.Content = $"選取課程： {selectedCourse.ToString()}";
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (selectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選取學生或課程");
                return;
            }
            else
            {
                Record newRecord = new Record
                {
                    SelectedStudent = selectedStudent,
                    SelectedCourse = selectedCourse
                };

                foreach(Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName}已經選過 {selectedCourse.CourseName} 課程");
                        return;
                    }
                }
                records.Add(newRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }
        }

        private void lvRecord_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            //此部分還有問題
            if (records.Count == 0) return;
            selectedRecord = lvRecord.SelectedItem as Record;
            labelStatus.Content = $"{selectedRecord.ToString()}";
        }

        private void btnWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecord !=null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }
            else
            {
                MessageBox.Show("請選取要退選的紀錄");
            }
        }
    }
}