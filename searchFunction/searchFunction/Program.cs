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


            PipelineGraph g = new PipelineGraph();

            g.AddJoint(1, 2);
            g.AddJoint(2, 3);
            g.AddJoint(2, 4);
            g.AddJoint(4, 5);
            g.AddJoint(3, 5);
            g.AddJoint(5, 6);


            foreach (var p in g.Pathfinder(g.pieces, g.pieces[0], g.pieces[5]))
            {
                Console.WriteLine("===========================");
                foreach (var pi in p)
                {
                    Console.WriteLine(pi.Name);
                }
            }

            Console.ReadKey();

















            Console.ReadKey();


            List<PipeLinePiece> pieces = new List<PipeLinePiece> { 
            new PipeLinePiece("Компонент - 1"),
            new PipeLinePiece("Компонент - 2"),
            new PipeLinePiece("Компонент - 3"),
            new PipeLinePiece("Компонент - 4"),
            new PipeLinePiece("Компонент - 5"),
            new PipeLinePiece("Компонент - 6")};

            List<Joint> joints = new List<Joint> { 
            new Joint("Стык - 1"),
            new Joint("Стык - 2"),
            new Joint("Стык - 3"),
            new Joint("Стык - 4"),
            new Joint("Стык - 5"),
            new Joint("Стык - 6"),
            new Joint("Стык - 7"),
            new Joint("Стык - 8")};
            //===============================
            pieces[0].Joints.Add(joints[0]);
            pieces[0].Joints.Add(joints[6]);
            pieces[0].Joints.Add(joints[7]);

            pieces[1].Joints.Add(joints[0]);
            pieces[1].Joints.Add(joints[1]);
            pieces[1].Joints.Add(joints[2]);

            pieces[2].Joints.Add(joints[1]);
            pieces[2].Joints.Add(joints[3]);

            pieces[3].Joints.Add(joints[2]);
            pieces[3].Joints.Add(joints[4]);
            pieces[3].Joints.Add(joints[7]);

            pieces[4].Joints.Add(joints[3]);
            pieces[4].Joints.Add(joints[4]);
            pieces[4].Joints.Add(joints[5]);

            pieces[5].Joints.Add(joints[5]);
            pieces[5].Joints.Add(joints[6]);

            //===============================
            joints[0].Pieces.Add(pieces[0]);
            joints[0].Pieces.Add(pieces[1]);

            joints[1].Pieces.Add(pieces[1]);
            joints[1].Pieces.Add(pieces[2]);

            joints[2].Pieces.Add(pieces[1]);
            joints[2].Pieces.Add(pieces[3]);

            joints[3].Pieces.Add(pieces[2]);
            joints[3].Pieces.Add(pieces[4]);

            joints[4].Pieces.Add(pieces[3]);
            joints[4].Pieces.Add(pieces[4]);

            joints[5].Pieces.Add(pieces[4]);
            joints[5].Pieces.Add(pieces[5]);

            joints[6].Pieces.Add(pieces[0]);
            joints[6].Pieces.Add(pieces[5]);

            joints[7].Pieces.Add(pieces[0]);
            joints[7].Pieces.Add(pieces[3]);


            foreach (var p in Pathfinder(pieces, pieces[1], pieces[5]))
            {
                Console.WriteLine("===========================");
                foreach (var pi in p)
                {
                    Console.WriteLine(pi.Name);
                }
            }

            Console.ReadKey();
        }


        public static List<List<PipeLinePiece>> Pathfinder(List<PipeLinePiece> pieces,
                                                           PipeLinePiece startPiece,
                                                           PipeLinePiece endPiece)
        {
            List<List<PipeLinePiece>> paths = new List<List<PipeLinePiece>>();

            Stack<PipeLinePiece> stack = new Stack<PipeLinePiece>();

            stack.Push(startPiece);

            List<Joint> joints= stack.Peek().Joints;

            int[] path = new int[pieces.Count * (pieces.Count - 1) / 2];

            int k = 0;



            while (stack.Count > 0)
            {
                while(k < joints.Count)
                {
                    for (int i = 0; i < 2; ++i)
                    {
                        if (!stack.Contains(joints[k].Pieces[i]))
                        {
                            path[stack.Count - 1] = k;
                            stack.Push(joints[k].Pieces[i]);
                            joints = stack.Peek().Joints;
                            k = 0;
                            break;
                        }
                        else if (i == 1)
                        {
                            ++k;
                        }
                    }
                    if (stack.Peek() == endPiece)
                    {
                        paths.Add(stack.ToList<PipeLinePiece>());
                        break;
                    }
                }

                if (stack.Count > 1)
                {
                    stack.Pop();
                    joints = stack.Peek().Joints;

                    path[stack.Count - 1]++;

                    k = path[stack.Count - 1];
                }
                else
                    break;
            } 
            return paths;
        }
    }
}
