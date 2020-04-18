using System;
using System.Linq;

namespace PupilsGrades
{
    public class Student
    {
        public string Name { get; set; }
        public Teacher Teacher { get; set; }
        public Grades<float> StudentGrades;

        public Student(string name, Teacher t)
        {
            StudentGrades = new Grades<float>();
            Name = name;
            Teacher = t;
        }

        public void AddGrade(float grade)
        {
            StudentGrades.Add(grade);
        }

        public float AverageGrade()
        {
            float sum = StudentGrades.TheGrades.Sum(f => f);
            return sum / StudentGrades.TheGrades.Count;
        }

        public override string ToString()
        {
            return $"{Name} has {StudentGrades.TheGrades.Count} grades with an average of {AverageGrade():F}.";
        }
    }
}