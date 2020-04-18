using System;
using System.Collections;
using System.Collections.Generic;

namespace PupilsGrades
{
    public class GradeEnumerator<T> : IEnumerator<T>
    {
        private List<T> TheGrades;
        private int Position;
        public T Current
        {
            get
            {
                if (Position < TheGrades.Count)
                    return TheGrades[Position];
                else
                    throw new IndexOutOfRangeException("Position goes beyond limits.");
            }
        }

        object IEnumerator.Current => Current;

        public GradeEnumerator(List<T> thegrades)
        {
            TheGrades = thegrades;
            Reset();
        }

        public void Dispose() { }

        public bool MoveNext()
        {
            Position++;
            return (Position < TheGrades.Count);
        }

        public void Reset()
        {
            Position = -1;
        }
    }
}