using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickGraph;
using QuickGraph.Collections;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;
using QuickGraph.Algorithms.RankedShortestPath;

namespace PartsCombiner
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomeTest();
        }


        static void DoSomeTest()
        {

            TimeSpan dt0;
            DateTime dtMy0;

            int vertexCount = 100000;

            Random rand = new Random();


            BidirectionalGraph<Part, Edge<Part>> graph = new BidirectionalGraph<Part, Edge<Part>>();

            List<Part> pieces = new List<Part>();

            for (int i = 0; i < vertexCount; ++i)
            {
                pieces.Add(new Part(Guid.NewGuid(), "V" + i.ToString()));

                graph.AddVertex(pieces[i]);
            }

            int rn1;
            int rn2;

            for (int i = 0; i < vertexCount - 1; ++i)
            {
                rn1 = rand.Next(vertexCount);
                rn2 = rand.Next(vertexCount);

                graph.AddEdge(new Edge<Part>(pieces[rn1], pieces[rn2]));
                graph.AddEdge(new Edge<Part>(pieces[rn2], pieces[rn1]));
            }

            // compute shortest paths
            var tryGetPaths = graph.ShortestPathsDijkstra<Part, Edge<Part>>(e => 1, pieces[0]);

            IEnumerable<Edge<Part>> Dpath;

            // query path for given vertices
            Part target = pieces[vertexCount - 1];

            dtMy0 = DateTime.Now;
            tryGetPaths(target, out Dpath);
            dt0 = DateTime.Now - dtMy0;

            if (tryGetPaths(target, out Dpath))
            {
                foreach (var edge in Dpath)
                {
                    Console.WriteLine(edge);
                }
            }
            Console.WriteLine("Dijkstra time = " + dt0.TotalMilliseconds);

            Console.ReadKey();
        }
    }
}
