using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AlgorithmDijkstra
{
    class Program
    {
        static void Main(string[] args)
        {
            const int N = 10000;

            DijkstraAlgorithm<string, object> alg = new DijkstraAlgorithm<string, object>(N);

            List<Guid> guid = new List<Guid>();
            for (int i = 0; i < N; i++)
            {
                guid.Add(Guid.NewGuid());
            }

            for (int i = 0; i < N; i++)
            {
                alg.AddVertex(guid[i], "v-" + i.ToString());
            }

            var rand = new Random();
            for (int i = 0; i < N - 1; i++)
            {
                alg.AddEdge(guid[rand.Next(0, i)], guid[rand.Next(i + 1, N - 1)], null);
                //alg.AddEdge(guid[i], guid[i+1], null);
            }

            foreach (var p in alg.Execute(guid[0], guid[N - 1]))
                Console.WriteLine(p.Data + " " + p.Weight.ToString());

            Console.ReadLine();
        }
    }



    public class DijkstraAlgorithm<TVertex, TEdge>
    {
        private Dictionary<Guid, Vertex> vertices;
        private Dictionary<Guid, HashSet<Vertex>> adjacencyMatrix;
        private List<Vertex> queue;
        private List<Vertex> path;

        public DijkstraAlgorithm(int capacity)
        {
            adjacencyMatrix = new Dictionary<Guid, HashSet<Vertex>>(capacity);
            vertices = new Dictionary<Guid, Vertex>(capacity);
            path = new List<Vertex>(2);
            queue = new List<Vertex>(2);
        }

        public void AddVertex(Guid id, TVertex data, bool mark = false)
        {
            var vertex = new Vertex(id, data, mark);
            vertices.Add(vertex.Id, vertex);
            adjacencyMatrix.Add(vertex.Id, new HashSet<Vertex>());
        }

        public void AddEdge(Guid startVertexId, Guid endVertexId, TEdge data, int weight = 1)
        {
            var edge = new Edge(vertices[startVertexId], vertices[endVertexId], data, weight);

            adjacencyMatrix[startVertexId].Add(vertices[endVertexId]);
            adjacencyMatrix[endVertexId].Add(vertices[startVertexId]);
        }

        public List<Vertex> Execute(Guid startVertexId, Guid endVertexId)
        {
            Vertex minVertex;

            vertices[startVertexId].Weight = 0;

            queue.Add(vertices[startVertexId]);

            while (queue.Count > 0)
            {
                minVertex = queue.Find(x => x.Weight == queue.Min<Vertex>(y => y.Weight));
                Сalculate(minVertex);
                queue.RemoveAt(queue.IndexOf(minVertex));
            }

            Vertex parent = vertices[endVertexId];

            while (parent != null)
            {
                path.Add(parent);
                parent = parent.Parent;
            }

            return path;
        }

        private void Сalculate(Vertex currentVertex)
        {
            currentVertex.Mark = true;

            var adjacencyVertices =
                adjacencyMatrix[currentVertex.Id]
                .Where<Vertex>(x => x.Mark == false);

            foreach (var i in adjacencyVertices)
            {
                foreach (var l in currentVertex.Edges)
                {
                    if ((l.StartVertex.Id == i.Id || l.EndVertex.Id == i.Id)
                        && i.Weight > currentVertex.Weight + l.Weight)
                    {
                        i.Weight = currentVertex.Weight + l.Weight;
                        i.Parent = currentVertex;
                        queue.Add(i);
                    }
                }
            }
        }

        public class Vertex
        {
            public TVertex Data { get; set; }
            public Guid Id { get; set; }
            public bool Mark { get; set; }
            public int Weight { get; set; }
            public List<Edge> Edges { get; set; }
            public Vertex Parent { get; set; }

            public Vertex(Guid id, TVertex data, bool mark = false)
            {
                this.Id = id;
                this.Mark = mark;
                this.Weight = int.MaxValue;
                this.Edges = new List<Edge>(2);
                this.Data = data;
            }
        }

        public class Edge
        {
            public TEdge Data { get; set; }
            public Vertex StartVertex { get; set; }
            public Vertex EndVertex { get; set; }
            public int Weight { get; set; }

            public Edge(Vertex startVertex, Vertex endVertex, TEdge data, int weight)
            {
                this.StartVertex = startVertex;
                this.StartVertex.Edges.Add(this);

                this.EndVertex = endVertex;
                this.EndVertex.Edges.Add(this);

                this.Weight = weight;

                this.Data = data;
            }
        }

    }
}

