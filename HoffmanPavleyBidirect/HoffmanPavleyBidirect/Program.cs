using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RankedShortestPath;

using QuickGraph.Graphviz;

namespace HoffmanPavleyBidirect
{
    class Program
    {

        public static int maxNumber = 15;

        static void Main(string[] args)
        {
            Random rand = new Random();
            // the following code will give you th enumber 
            // and routes of all paths found in a Bidirectional 
            // graph using the  HoffmanPavley algorith.

            BidirectionalGraph<string, TaggedEdge<string, string>> graph = 
                new BidirectionalGraph<string, TaggedEdge<string, string>>();

            for (int i = 0; i < maxNumber; ++i)
            {
                graph.AddVertex("V" + i.ToString());
            }

            for (int i = 0; i < maxNumber; ++i)
            {
                int rn1 = rand.Next(maxNumber);
                int rn2 = rand.Next(maxNumber);

                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn1.ToString(),
                                                   "V" + rn2.ToString(), "lable"));
                graph.AddEdge(
                    new TaggedEdge<string, string>("V" + rn2.ToString(),
                                                   "V" + rn1.ToString(), "lable"));
            }
            
            HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>> test1 = 
                new HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>>(graph, E => 1.0);

            test1.ShortestPathCount = 1000;

            test1.SetRootVertex("V1");
            test1.SetRootVertex("V" + maxNumber.ToString());

            test1.Compute("V1", "V" + (maxNumber - 1).ToString());
            
            
            

            foreach (IEnumerable<TaggedEdge<string, string>> path in test1.ComputedShortestPaths)
            {
                Console.WriteLine("Path Found.....");
                foreach (var edge in path)
                {
                    //System.Diagnostics.Trace.WriteLine(edge);
                    Console.WriteLine(edge);
                }
            }

            Console.WriteLine("Paths Found = " + test1.ComputedShortestPathCount.ToString());



            var graphViz = new GraphvizAlgorithm<string, TaggedEdge<string, string>>(graph, 
                            @".\", QuickGraph.Graphviz.Dot.GraphvizImageType.Png);

            graphViz.FormatVertex += FormatVertex;
            //graphViz.FormatEdge += FormatEdge;

            graphViz.Generate(new FileDotEngine(), "figure");

            Console.ReadKey();


        }

        private static void FormatVertex(object sender, FormatVertexEventArgs<string> e)
        {
            e.VertexFormatter.Label = e.Vertex;
        }
        private static void FormatEdge(object sender, FormatEdgeEventArgs<string, TaggedEdge<string, string>> e)
        {
            e.EdgeFormatter.Head.Label = e.Edge.Target;
            e.EdgeFormatter.Tail.Label = e.Edge.Source;
        }
    }
}
