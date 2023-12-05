using Microsoft.Win32;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;
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

        List<Course> courses = new List<Course>();
        Course selectedCourse = null;

        List<Teacher> teachers = new List<Teacher>();
        Teacher selectedTeacher = null;

        List<Record> records = new List<Record>();
        Record selectedRecord = null;
        public MainWindow()
        {
            InitializeComponent();
            InitailizeStudent();
            InitializeCourse();
        }

        private void InitializeCourse()
        {
            Teacher teacher1 = new Teacher { TeacherName = "陳定宏" };
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName="視窗程式設計", OpeningClass="四技二甲", Point=3, Type = "選修"});
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二乙", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二丙", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });

            Teacher teacher2 = new Teacher { TeacherName = "李宗儒" };
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "Android程式設計", OpeningClass = "五專四甲", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "人工智慧與應用", OpeningClass = "博研電子一甲等合開", Point = 3, Type = "選修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "動態程式語言", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });

            Teacher teacher3 = new Teacher { TeacherName = "鄧瑞哲" };
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "微積分(一)", OpeningClass = "四技資工一丙", Point = 3, Type = "必修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "圖像化程式設計", OpeningClass = "五專資工一甲", Point = 2, Type = "系定選修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "圖像化程式設計實習", OpeningClass = "五專資工一甲", Point = 2, Type = "系定選修" });

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

        private void InitailizeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳小明" });
            students.Add(new Student { StudentId = "A1234987", StudentName = "王小美" });
            students.Add(new Student { StudentId = "A1234234", StudentName = "張小虎" });
            students.Add(new Student { StudentId = "A1234002", StudentName = "黃小龍" });

            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
            //selectedStudent = (Student)cmbStudent.SelectedItem;
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
            else if (tvTeacher.SelectedItem is Course)
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
                MessageBox.Show("請選取學生與課程");
                return;
            }
            else
            {
                Record newRecord = new Record { SelectedStudent = selectedStudent, SelectedCourse = selectedCourse };

                foreach (Record r in records)
                {
                    if (newRecord.Equals(r))
                    {
                        MessageBox.Show($"{selectedStudent.StudentName}已選取{selectedCourse.CourseName}");
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
            if (lvRecord.SelectedItem !=null)
            {
                selectedRecord = (Record)lvRecord.SelectedItem;
                labelStatus.Content = $"選取紀錄： {selectedRecord.SelectedStudent.StudentName}　 {selectedRecord.SelectedCourse.CourseName}";
            }
        }

        private void btnWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            if (selectedRecord != null)
            {
                records.Remove(selectedRecord);
                lvRecord.Items.Refresh();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            //開啟一個對話方塊，將records內容存成json檔，使用Microsoft所提供的Json類別
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";

            if (saveFileDialog.ShowDialog() == true)
            {
                var options = new JsonSerializerOptions
                {
                    WriteIndented = true, 
                    ReferenceHandler = ReferenceHandler.Preserve,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
                };

                string json = JsonSerializer.Serialize(records, options);
                File.WriteAllText(saveFileDialog.FileName, json);
            }
        }
    }
}