﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BinaryTree
{
    internal class TreePerformance
    {
        public static void Measure(string message,Delegate @delegate,Tree obj)
        {
            Stopwatch sw= new Stopwatch();
            sw.Start();
            Object value = @delegate.Method.Invoke(obj,null);
            Console.WriteLine(value.ToString());
            sw.Stop();
        }
    }
}
