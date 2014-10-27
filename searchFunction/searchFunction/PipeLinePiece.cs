using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchFunction
{
    public class PipeLinePiece
    {
        public PipeLinePiece() { }
        public PipeLinePiece(string str)
        {
            Name = str;
            Joints = new List<Joint>();
        }
        public string Name { get; set; }

        public List<Joint> Joints { get; set; }
    }
}
