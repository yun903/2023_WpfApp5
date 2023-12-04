﻿namespace _2023_WpfApp5
{
    class Course
    {
        public String CourseName { get; set; }
        public String Type { get; set; }
        public int Point { get; set; }
        public String OpeningClass { get; set; }
        public Teacher Tutor { get; set; }
        public Course(Teacher tutor)
        {
            Tutor = tutor;
        }
        public override string ToString()
        {
            return $"{CourseName} / {OpeningClass} {Type} {Point}學分";
        }
    }
}
