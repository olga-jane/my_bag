using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int vertexCount = 6;

            List<PipeLinePiece> pieces = new List<PipeLinePiece>();

            for (int i = 0; i < vertexCount; ++i)
            {
                pieces.Add(new PipeLinePiece("Компонент - " + (i + 1).ToString()));
            }

            PipelineGraph g = new PipelineGraph(pieces);

            g.AddJoint(0, 1);
            g.AddJoint(1, 2);
            g.AddJoint(1, 3);
            g.AddJoint(3, 4);
            g.AddJoint(2, 4);
            g.AddJoint(4, 5);
            g.AddJoint(0, 5);
            g.AddJoint(2, 5);


            foreach (var p in g.Pathfinder(g.pieces, g.pieces[5], g.pieces[0]))
            {
                Console.WriteLine("=================");
                foreach (var pi in p)
                {
                    Console.WriteLine(pi.Name);
                }
            }

            Console.ReadKey();
        }


    }
}
