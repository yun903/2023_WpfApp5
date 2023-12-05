namespace _2023_WpfApp5
{
    class Record
    {
        public Student SelectedStudent { get; set; }
        public Course SelectedCourse { get; set; }

        public bool Equals(Record r)
        {
            return this.SelectedStudent.StudentId == r.SelectedStudent.StudentId && this.SelectedCourse.CourseName == r.SelectedCourse.CourseName;
        }
    }
}
