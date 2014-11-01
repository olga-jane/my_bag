using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RankedShortestPath;

using QuickGraph;
using QuickGraph.Collections;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.ShortestPath;
using QuickGraph.Algorithms.Observers;

namespace searchFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            DoSomeTest();

            //DoSomeDijkstraTest();
        }

        static void DoMySomeDemoTest()
        {
            HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>> test1;

            int vertexCount = 50;

            Random rand = new Random();
            List<PipeLinePiece> pieces = new List<PipeLinePiece>();



            BidirectionalGraph<string, TaggedEdge<string, string>> graph;

            for (int i = 0; i < vertexCount; ++i)
            {
                pieces.Add(new PipeLinePiece("V" + i.ToString()));
            }



            PipelineGraph g = new PipelineGraph(pieces);

            for (int i = 0; i < vertexCount - 1; ++i)
            {
                int rn1 = rand.Next(vertexCount);
                int rn2 = rand.Next(vertexCount);
                g.AddJoint(rn1, rn2);
            }

            List<List<PipeLinePiece>> pathes = g.Pathfinder(g.pieces, g.pieces[vertexCount - 1], g.pieces[1]);

            foreach (var w in pathes)
            {
                graph = new BidirectionalGraph<string, TaggedEdge<string, string>>();

                for (int i = 0; i < w.Count; ++i)
                {
                    graph.AddVertex(w[i].Name);
                }

                for (int i = 0; i < w.Count - 1; ++i)
                {
                    graph.AddEdge(new TaggedEdge<string, string>(w[i].Name, w[i + 1].Name, "lable"));
                    graph.AddEdge(new TaggedEdge<string, string>(w[i + 1].Name, w[i].Name, "lable"));
                }


                test1 = new HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, E => 1.0);

                test1.ShortestPathCount = 10;

                test1.SetRootVertex("V1");
                test1.SetRootVertex("V" + vertexCount.ToString());
                test1.Compute("V1", "V" + (vertexCount - 1).ToString());


                foreach (IEnumerable<TaggedEdge<string, string>> path in test1.ComputedShortestPaths)
                {
                    Console.WriteLine("Path Found.....");
                    foreach (var edge in path)
                    {
                        Console.WriteLine(edge);
                    }
                }
                Console.WriteLine("============================     =================");
                Console.ReadLine();
            }
            Console.ReadKey();

        }






        static void DoSomeTest()
        {

            TimeSpan dt0;
            DateTime dtMy0;

            TimeSpan dt2;
            DateTime dtMy2;

            int vertexCount = 500000;

            Random rand = new Random();


            BidirectionalGraph<PipeLinePiece, Edge<PipeLinePiece>> graph =
                new BidirectionalGraph<PipeLinePiece, Edge<PipeLinePiece>>();

            List<PipeLinePiece> pieces = new List<PipeLinePiece>();

            for (int i = 0; i < vertexCount; ++i)
            {
                pieces.Add(new PipeLinePiece("V" + i.ToString(), i));
                graph.AddVertex(pieces[i]);
            }

            PipelineGraph g = new PipelineGraph(pieces);

            for (int i = 0; i < vertexCount-1; ++i)
            {
                int rn1 = i;
                int rn2 = i + 1;

                //int rn1 = rand.Next(vertexCount);
                //int rn2 = rand.Next(vertexCount);

                graph.AddEdge(new Edge<PipeLinePiece>(g.pieces[rn1], g.pieces[rn2]));

                graph.AddEdge(new Edge<PipeLinePiece>(g.pieces[rn2], g.pieces[rn1]));

                g.AddJoint(rn1, rn2);
            }

            // compute shortest paths
            var tryGetPaths 
                = graph.ShortestPathsBellmanFord<PipeLinePiece, Edge<PipeLinePiece>>
                (e => e.Source.Weigth, g.pieces[0]);

            IEnumerable<Edge<PipeLinePiece>> Dpath;

         
            
            // query path for given vertices
            PipeLinePiece target = g.pieces[vertexCount - 1];

            dtMy0 = DateTime.Now;   
            tryGetPaths(target, out Dpath);
            dt0 = DateTime.Now - dtMy0;

            Console.WriteLine("Dijkstra time = " + dt0.TotalMilliseconds);


            //if (tryGetPaths(target, out Dpath))
            //foreach (var edge in Dpath)
            //{
            //    Console.WriteLine(edge);
            //}
            Console.WriteLine("Dijkstra time = " + dt0.TotalMilliseconds);


            dtMy2 = DateTime.Now;
            // my algoritm:
            List<List<PipeLinePiece>> pathes = g.Pathfinder(g.pieces, g.pieces[vertexCount - 1], g.pieces[1]);
            dt2 = DateTime.Now - dtMy2;
            Console.WriteLine("My time = " + dt2.Ticks);



            List<List<string>> list = new List<List<string>>();


            for (int k = 0; k < pathes.Count; ++k )
            {
                list.Add(new List<string>());

                for (int i = 0; i < pathes[k].Count - 1; ++i)
                {
                    list[k].Add(pathes[k][i].Name + "->" + pathes[k][i + 1].Name);
                }
            }
            
            foreach (var p in list)
            {
                Console.WriteLine("-----------------");
                foreach (var pi in p)
                {
                    Console.WriteLine(pi);
                }
            }
            Console.WriteLine("Paths Found = " + pathes.Count);
            Console.WriteLine("Dijkstra time = " + dt0.TotalMilliseconds);
            Console.WriteLine("My time = " + dt2.TotalMilliseconds);


            Console.ReadKey();




        }





        static void DoSomeDijkstraTest()
        {

            int vertexCount = 100;


            BidirectionalGraph<string, TaggedEdge<string, string>> graph 
                = new BidirectionalGraph<string, TaggedEdge<string, string>>();


            for (int i = 0; i < vertexCount; ++i)
            {
                graph.AddVertex("V" + i.ToString());
            }

            for (int i = 0; i < vertexCount - 1; ++i)
            {
                int rn1 = i;
                int rn2 = i + 1;

                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn1.ToString(),
                                                   "V" + rn2.ToString(), "lable"));
                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn2.ToString(),
                                                   "V" + rn1.ToString(), "lable"));
            }


            // compute shortest paths
            var tryGetPaths = graph.ShortestPathsDijkstra<string, TaggedEdge<string, string>>(e => 1, "V0");


            
            // query path for given vertices
            string target = "V" + (vertexCount - 1).ToString();

            IEnumerable<TaggedEdge<string, string>> path;

            if (tryGetPaths(target, out path))
            {
                foreach (var edge in path)
                {
                    Console.WriteLine(edge);
                }
            }


            Console.ReadKey();







        }
    }
}
