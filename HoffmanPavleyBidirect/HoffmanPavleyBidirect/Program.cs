using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuickGraph;
using QuickGraph.Algorithms;
using QuickGraph.Algorithms.RankedShortestPath;

namespace HoffmanPavleyBidirect
{
    class Program
    {
        static void Main(string[] args)
        {

            // the following code will give you th enumber 
            // and routes of all paths found in a Bidirectional 
            // graph using the  HoffmanPavley algorith.

            BidirectionalGraph<string, TaggedEdge<string, string>> mvGraph2 = new BidirectionalGraph<string, TaggedEdge<string, string>>();
            // UndirectedGraph<string, TaggedEdge<string, string>> mvGraph2 = new UndirectedGraph<string, TaggedEdge<string, string>>();

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("P1a", "I1", "P1a-I1"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I1", "P1a", "I1-P1a"));

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("P1a", "I3", "P1a-I3"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I3", "P1a", "I3-P1a"));

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I1", "I2", "I1-I2"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I2", "I1", "I2-I1"));

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I1", "I3", "I1-I3"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I3", "I1", "I3-I1"));

            //mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I3", "I2", "I3-I2"));
            //mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I2", "I3", "I2-I3"));

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I3", "Leach", "I3-Leach"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("Leach", "I3", "Leach-I3"));

            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("I2", "Leach", "I2-Leach"));
            mvGraph2.AddVerticesAndEdge(new TaggedEdge<string, string>("Leach", "I2", "Leach-I2"));
            
            HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>> test1 = 
                new HoffmanPavleyRankedShortestPathAlgorithm<string, TaggedEdge<string, string>>(mvGraph2, E => 1.0);

            test1.ShortestPathCount = 20;

            test1.SetRootVertex("P1a");
            test1.SetRootVertex("Leach");

            test1.Compute("P1a", "Leach");
            
            
            Console.WriteLine("Paths Found = " + test1.ComputedShortestPathCount.ToString());

            foreach (IEnumerable<TaggedEdge<string, string>> path in test1.ComputedShortestPaths)
            {
                Console.WriteLine("Path Found.....");
                foreach (var edge in path)
                {
                    //System.Diagnostics.Trace.WriteLine(edge);
                    Console.WriteLine(edge);
                }
            }


            Console.ReadKey();

        }
    }
}
