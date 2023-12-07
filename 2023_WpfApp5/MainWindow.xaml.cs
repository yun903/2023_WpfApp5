using Microsoft.Win32;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
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
        Course selectedCourse = null;

        List<Teacher> teachers = new List<Teacher>();
        Teacher selectedTeacher = null;

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

            teachers.Add(teacher1);
            teachers.Add(teacher2);

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
            //建立Student物件並加入清單，將此清單內容指定給cmbStudent
            students.Add(new Student() { StudentId = "S001", StudentName = "小明" });
            students.Add(new Student() { StudentId = "S002", StudentName = "小華" });
            students.Add(new Student() { StudentId = "S003", StudentName = "小英" });
            cmbStudent.ItemsSource = students;
            cmbStudent.SelectedIndex = 0;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selelectedStudent = (Student)cmbStudent.SelectedItem;
            //將此資訊在labelStatus中顯示
            labelStatus.Content = $"{selelectedStudent.ToString()}";

        }

        private void tvTeacher_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (tvTeacher.SelectedItem is Teacher)
            {
                selectedTeacher = (Teacher)tvTeacher.SelectedItem;
                labelStatus.Content = $"選取教師： {selectedTeacher.ToString()}";
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
            if (selelectedStudent == null || selectedCourse == null)
            {
                MessageBox.Show("請選擇學生或課程");
                return;
            }
            else
            {
                Record newRecord = new Record
                {
                    SelectedStudent = selelectedStudent,
                    SelectedCourse = selectedCourse
                };

                foreach (Record r in records)
                {
                    if (r.Equals(newRecord))
                    {
                        MessageBox.Show($"{selelectedStudent.StudentName}已經選過{selectedCourse.CourseName}這門課了，請重新選課");
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
            selectedRecord = (Record)lvRecord.SelectedItem;
            if (selectedRecord != null)
            {
                labelStatus.Content = $"選取紀錄： {selectedRecord.ToString()}";
            }
        }

        private void btnWithdrawl_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCourse != null)
            {
                records.Remove(selectedRecord);
                lvRecord.ItemsSource = records;
                lvRecord.Items.Refresh();
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Json文件|*.json";
            saveFileDialog.Title = "儲存選課紀錄";

            if (saveFileDialog.ShowDialog() == true)
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                    ReferenceHandler = ReferenceHandler.Preserve,
                    WriteIndented = true
                };
                string jsonData = JsonSerializer.Serialize<List<Record>>(records, options);
                File.WriteAllText(saveFileDialog.FileName, jsonData);
            }
        }
    }
}