using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RankedShortestPath;

namespace searchFunction
{
    class Program
    {
        static void Main(string[] args)
        {

            int vertexCount = 1000;

            Random rand = new Random();


            BidirectionalGraph<string, TaggedEdge<string, string>> graph = 
                new BidirectionalGraph<string, TaggedEdge<string, string>>();

            List<PipeLinePiece> pieces = new List<PipeLinePiece>();

            for (int i = 0; i < vertexCount; ++i)
            {
                graph.AddVertex("V" + i.ToString());

                pieces.Add(new PipeLinePiece("V" + i.ToString()));
            }

            PipelineGraph g = new PipelineGraph(pieces);

            for (int i = 0; i < vertexCount; ++i)
            {
                int rn1 = rand.Next(vertexCount);
                int rn2 = rand.Next(vertexCount);

                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn1.ToString(),
                                                   "V" + rn2.ToString(), "lable"));
                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn2.ToString(),
                                                   "V" + rn1.ToString(), "lable"));

                g.AddJoint(rn1, rn2);
            }
            
            HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>> test1 = 
                new HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, E => 1.0);



            test1.ShortestPathCount = 1000;

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
            Console.WriteLine("Paths Found = " + test1.ComputedShortestPathCount.ToString());

            Console.ReadKey();

            Console.WriteLine("=================");



            // my algoritm:
            List<List<PipeLinePiece>> pathes = g.Pathfinder(g.pieces, g.pieces[vertexCount - 1], g.pieces[1]);
            
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


            Console.ReadKey();
        }


    }
}
