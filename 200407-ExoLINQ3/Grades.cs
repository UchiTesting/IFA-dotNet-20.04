using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PupilsGrades
{
    public class Grades<T> : IEnumerable<T>
    {
        public readonly List<T> TheGrades;

        public T this[int i]
        {
            get
            {
                if (i < TheGrades.Count)
                {
                    return TheGrades[i];
                }
                else
                { throw new IndexOutOfRangeException("Position goes beyond limits."); }
            }
            set
            {
                if (i < TheGrades.Count)
                {
                    TheGrades[i] = value;
                } else {throw  new IndexOutOfRangeException("Position goes beyond limits.");}
                
            }
        }
        
        public Grades()
        {
            TheGrades = new List<T>();
        }

        public void Add(T value)
        {
            TheGrades.Add(value);
        }
        public IEnumerator<T> GetEnumerator()
        {
            return  new GradeEnumerator<T>(TheGrades);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            TheGrades.ForEach(g => sb.AppendLine(g.ToString()));
            return sb.ToString();
        }
    }
}