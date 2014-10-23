using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickGraph;
using QuickGraph.Algorithms.Search;

namespace ConsoleApplication5
{
    class Program
    {
        static void Main(string[] args)
        {

            MyClass myClass = new MyClass();

            foreach (var v in myClass.vertexPredecessors)
                Console.WriteLine(v.Key + " - " + v.Value);

            Console.ReadKey();


        }
    }
}
