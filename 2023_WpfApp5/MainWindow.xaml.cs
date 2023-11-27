﻿using System.Windows;

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

        List<Teacher> teachers = new List<Teacher>();
        public MainWindow()
        {
            InitializeComponent();

            InitializeStudent();

            InititalizeCourse();
        }

        private void InititalizeCourse()
        {
            Teacher teacher1 = new Teacher() { TeacherName = "陳定宏" };
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "五專三甲", Point = 3, Type = "必修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二甲", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二乙", Point = 3, Type = "選修" });
            teacher1.TeachingCourses.Add(new Course(teacher1) { CourseName = "視窗程式設計", OpeningClass = "四技二丙", Point = 3, Type = "選修" });

            Teacher teacher2 = new Teacher() { TeacherName = "陳福坤" };
            teacher2.TeachingCourses.Add(new Course(teacher2) {CourseName = "計算機概論", OpeningClass = "四技一丙", Point=2, Type="必修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "計算機概論", OpeningClass = "四技一甲一乙", Point = 2, Type = "必修" });
            teacher2.TeachingCourses.Add(new Course(teacher2) { CourseName = "數位系統導論", OpeningClass = "四技一乙", Point = 3, Type = "必修" });

            Teacher teacher3 = new Teacher() { TeacherName = "許子衡"};
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "Android程式設計", OpeningClass = "四技資工三甲等合開", Point = 3, Type = "選修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "人工智慧與雲端運算", OpeningClass = "四技資工四甲等合開", Point = 3, Type = "選修" });
            teacher3.TeachingCourses.Add(new Course(teacher3) { CourseName = "動態程式語言", OpeningClass = "五專資工三甲", Point = 3, Type = "系定選修" });

            teachers.Add(teacher1);
            teachers.Add(teacher2);
            teachers.Add(teacher3);

            tvTeacher.ItemsSource = teachers;
        }

        private void InitializeStudent()
        {
            students.Add(new Student { StudentId = "A1234567", StudentName = "陳小明" });
            students.Add(new Student { StudentId = "A1234678", StudentName = "王小美" });
            students.Add(new Student { StudentId = "A1234789", StudentName = "林小英" });

            cmbStudent.ItemsSource = students;
        }

        private void cmbStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            selectedStudent = (Student)cmbStudent.SelectedItem;
            labelStatus.Content = $"選取學生：{selectedStudent.ToString()}";
        }
    }
}