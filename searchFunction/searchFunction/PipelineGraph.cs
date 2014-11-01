using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchFunction
{
    class PipelineGraph
    {
        public List<PipeLinePiece> pieces;

        public PipelineGraph(List<PipeLinePiece> pieces)
        {
            this.pieces = pieces;
        }

        public void AddJoint(int fPoint, int tPoint)
        {
            Joint joint = new Joint("V" + tPoint.ToString() + "->" + "V" + fPoint.ToString());

            joint.Pieces.Add(pieces[fPoint]);
            joint.Pieces.Add(pieces[tPoint]);

            pieces[fPoint].Joints.Add(joint);
            pieces[tPoint].Joints.Add(joint);
        }


        public List<List<PipeLinePiece>> Pathfinder(List<PipeLinePiece> pieces,
                                                    PipeLinePiece startPiece,
                                                    PipeLinePiece endPiece)
        {
            List<List<PipeLinePiece>> paths = new List<List<PipeLinePiece>>();

            Stack<PipeLinePiece> stack = new Stack<PipeLinePiece>();

            stack.Push(startPiece);

            List<Joint> joints = stack.Peek().Joints;

            int[] path = new int[pieces.Count];

            int k = 0;

            while (stack.Count > 0 && paths.Count < 1)
            {
                while (k < joints.Count)
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
