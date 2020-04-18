using System;
using System.Collections;

namespace ListReimplementedFile
{
    public class MyListOfInt : IEnumerable
    {
        public int[] TheListOfInt = new int[0];
        public int ListLength { get; set; }

        public MyListOfInt()
        {
            ListLength = 0;
        }

        public void Add(int i)
        {
            ListLength++;
            Array.Resize(ref TheListOfInt, ListLength);
            TheListOfInt[ListLength-1] = i;
        }

        public void RemoveAt(int idx)
        {
            Console.WriteLine($"Element to be removed: {TheListOfInt[idx]}");
            
            if (idx >= TheListOfInt.Length)
                return; // Guard clause could become an exception
            
            int[] tmpArrayBeforeIdx = new int[0];
            // int[] tmpArrayAfterIdx = new int[0];
            Array.Resize(ref tmpArrayBeforeIdx,idx);
            Array.Copy(TheListOfInt, tmpArrayBeforeIdx,idx);
            Array.Resize(ref tmpArrayBeforeIdx, TheListOfInt.Length-1);
            Array.Copy(TheListOfInt,idx+1,tmpArrayBeforeIdx,idx,TheListOfInt.Length-idx-1);
            
            //TODO Put the tmp table into the main one and resize it accordingly.
            this.Clear();
            Array.Resize(ref TheListOfInt, tmpArrayBeforeIdx.Length);
            Array.Copy(tmpArrayBeforeIdx,TheListOfInt,tmpArrayBeforeIdx.Length);

            foreach (int nb in TheListOfInt)
            {
                Console.WriteLine(nb);
                
            }
        }

        public void Clear()
        {
            TheListOfInt = Array.Empty<int>();
            ListLength = 0;
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}