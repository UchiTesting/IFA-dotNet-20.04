using System.Collections;
using System.Collections.Generic;

namespace ListReimplementedFile
{
    public class MyListOfIntEnumerator : IEnumerator<int>
    {
        private MyListOfInt loi { get; set; }
        private int _index;
        private int current;
        public int Current { get => current;
            set { current = value; }
        }

        public MyListOfIntEnumerator(MyListOfInt _loi)
        {
            loi = _loi;
            Reset();
        }
        
        public bool MoveNext()
        {
            if (_index >= loi.ListLength -1)
                return false;
 
            _index++;

            //Current = (_index < loi.ListLength) ? loi.TheListOfInt[_index]:null;
            return true;
        }

        public void Reset()
        {
            _index = -1;
        }


        object? IEnumerator.Current => Current;

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}