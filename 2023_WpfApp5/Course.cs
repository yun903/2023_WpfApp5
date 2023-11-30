namespace _2023_WpfApp5
{
    class Course
    {
        //產生課程名稱，學分數，必選修，開課班級，授課教師
        public String CourseName { get; set; }
        public int Point { get; set; }
        public String Type { get; set; }
        public String OpeningClass { get; set; }
        public Teacher Tutor { get; set; }

        public Course(Teacher tutor)
        {
            Tutor = tutor;
        }
    }
}
