using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
    internal class TreePerformance<T>
    {
        public delegate T Method();
        //public static void Measure(string message,Delegate @delegate,Tree obj)
        public static void Measure(string message,Method method)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            T value = method();
            //Object value = @delegate.Method.Invoke(obj,null);
            //Console.WriteLine(value.ToString());

            sw.Stop();
            Console.WriteLine($"{message.PadLeft(42)}{value.ToString().PadLeft(12)}, вычислено за {sw.Elapsed.ToString("ss\\.fffffff")} секунд.");
        }
    }
}
