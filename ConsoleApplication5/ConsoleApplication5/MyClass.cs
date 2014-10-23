using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using QuickGraph;
using QuickGraph.Algorithms.Search;

namespace ConsoleApplication5
{
    class MyClass
    {
        public MyClass()
        {
            AdjacencyGraph<string, Edge<string>> graph = new AdjacencyGraph<string, Edge<string>>(true);

            // Add some vertices to the graph

            graph.AddVertex("D");
            graph.AddVertex("A");
            graph.AddVertex("B");
            graph.AddVertex("C");
            graph.AddVertex("E");
            //graph.AddVertex("F");
            //graph.AddVertex("G");
            //graph.AddVertex("H");
            //graph.AddVertex("I");
            //graph.AddVertex("J");

            // Create the edges
            Edge<string> a_b = new Edge<string>("A", "B");
            Edge<string> a_d = new Edge<string>("B", "C");
            Edge<string> b_a = new Edge<string>("C", "D");
            Edge<string> b_c = new Edge<string>("D", "B");
            Edge<string> b_e = new Edge<string>("D", "E");
            Edge<string> c_b = new Edge<string>("E", "C");
            Edge<string> c_f = new Edge<string>("E", "A");
            Edge<string> c_j = new Edge<string>("A", "E");
            //Edge<string> d_e = new Edge<string>("D", "E");
            //Edge<string> d_g = new Edge<string>("D", "G");
            //Edge<string> e_d = new Edge<string>("E", "D");
            //Edge<string> e_f = new Edge<string>("E", "F");
            //Edge<string> e_h = new Edge<string>("E", "H");
            //Edge<string> f_i = new Edge<string>("F", "I");
            //Edge<string> f_j = new Edge<string>("F", "J");
            //Edge<string> g_d = new Edge<string>("G", "D");
            //Edge<string> g_h = new Edge<string>("G", "H");
            //Edge<string> h_g = new Edge<string>("H", "G");
            //Edge<string> h_i = new Edge<string>("H", "I");
            //Edge<string> i_f = new Edge<string>("I", "F");
            //Edge<string> i_j = new Edge<string>("I", "J");
            //Edge<string> i_h = new Edge<string>("I", "H");
            //Edge<string> j_f = new Edge<string>("J", "F");

            // Add the edges
            graph.AddEdge(a_b);
            graph.AddEdge(a_d);
            graph.AddEdge(b_a);
            graph.AddEdge(b_c);
            graph.AddEdge(b_e);
            graph.AddEdge(c_b);
            graph.AddEdge(c_f);
            graph.AddEdge(c_j);
            //graph.AddEdge(d_e);
            //graph.AddEdge(d_g);
            //graph.AddEdge(e_d);
            //graph.AddEdge(e_f);
            //graph.AddEdge(e_h);
            //graph.AddEdge(f_i);
            //graph.AddEdge(f_j);
            //graph.AddEdge(g_d);
            //graph.AddEdge(g_h);
            //graph.AddEdge(h_g);
            //graph.AddEdge(h_i);
            //graph.AddEdge(i_f);
            //graph.AddEdge(i_h);
            //graph.AddEdge(i_j);
            //graph.AddEdge(j_f);


            var dfs = new DepthFirstSearchAlgorithm<string, Edge<string>>(graph);


            dfs.TreeEdge += dfs_TreeEdge;

            dfs.Compute();

            

        }

        public Dictionary<string, Edge<string>> vertexPredecessors = 
            new Dictionary<string,Edge<string>>();

        void dfs_TreeEdge(Edge<string> e)
        {
            vertexPredecessors.Add(e.Target, e);
        }
    }
}
