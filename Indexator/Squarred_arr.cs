using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator
{
    public class Squarred_arr
    {
        private int[] arr;
        public Squarred_arr(int size)
        {
            arr = new int[size];
        }
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс вне границ массива.");
                }
            }
            set
            {
                if (index >= 0 && index < arr.Length)
                {
                    arr[index] = value * value;
                }
                else
                {
                    throw new IndexOutOfRangeException("Индекс вне границ массива.");
                }
            }
        }
    }
}
