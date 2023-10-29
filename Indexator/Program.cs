using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Indexator
{
    public class Program
    {
        static void Main(string[] args)
        {
            {
                Squarred_arr squared_arr = new Squarred_arr(5);

                squared_arr[0] = 3; 
                squared_arr[1] = 4;
                squared_arr[2] = 5;
                squared_arr[3] = 6;
                squared_arr[4] = 7;

                Console.WriteLine(squared_arr[4]); // Получаем значение (16)
            }
        }
    }
}
