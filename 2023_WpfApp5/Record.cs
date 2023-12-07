namespace _2023_WpfApp5
{
    internal class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public bool Equals(Record r)
        {
            return SelectedStudent.StudentId == r.SelectedStudent.StudentId && SelectedCourse.CourseName == r.SelectedCourse.CourseName;
        }

        public override string ToString()
        {
            return $"{SelectedStudent.StudentName} / {SelectedCourse.OpeningClass} {SelectedCourse.CourseName}";
        }
    }
}
