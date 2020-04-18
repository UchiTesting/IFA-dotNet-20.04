using System;
using System.Collections.Generic;
using  System.Threading;
using Microsoft.SqlServer.Server;
using System.Linq;
using System.Runtime.InteropServices;
using System.Xml;

namespace PupilsGrades
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            /*Ecrivez une programme qui permet de chercher:
            - Afficher toute les notes d'un etudiant


            */
            var students = new List<Student>();
            
            students.AddRange(CreateStudents(30,5));
            
            var Vincent = new Teacher("Vincent");
            
            Console.WriteLine("Displaying all grades from a student");
            students.ForEach(DisplayGrades);
            Console.WriteLine("Students with a grade under average");
            students.ForEach(s =>
            {
                if (HasUnderAverageGrade(s))
                    Console.WriteLine(s);
            });

            Console.WriteLine("Students having Vincent as a teacher.");
            students.ForEach(s =>
            {
                if (HasTeacher(s, Vincent))
                    Console.WriteLine(s);
            });
        }

        private static void DisplayGrades(Student s)
        {
            var query = from grade in s.StudentGrades
                where grade > 0
                select grade;
            Console.WriteLine($"{s.Name} grades: ");
            foreach (var f in query)
            {
                Console.Write($"{f,7:F}");
            }
            Console.Write("\r\n");
        }
        private static bool HasUnderAverageGrade(Student s)
        {
            var query = from grade in s.StudentGrades
                where grade < 10.0
                select grade;
            
            return (query.ToList().Count > 0);
        }

        private static bool HasTeacher(Student student, Teacher t)
        {
            return (student.Teacher.Equals(t));
        }

        private static IEnumerable<Student> CreateStudents(int numberOfStudents, int numberOfGrades)
        {
            
            var tmpList = new List<Student>();
            var teacherList = new List<Teacher>();
            teacherList.Add(new Teacher("Vincent"));
            teacherList.Add(new Teacher("Franck"));
            teacherList.Add(new Teacher("Pascal"));
            teacherList.Add(new Teacher("Julien"));
            
            var gen = new Random();

            for (var i = 0; i < numberOfStudents; i++)
            {
                tmpList.Add(new Student($"Student {i}",teacherList[gen.Next(0,4)]));
                for (var j = 0; j < numberOfGrades; j++)
                {
                    tmpList[i].StudentGrades.Add(((float)gen.NextDouble())*20);
                }
            }

            return tmpList;
        }
    }
}