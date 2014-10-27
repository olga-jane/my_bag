using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace searchFunction
{
    public class Joint
    {
        public Joint() { }
        public Joint(string str)
        {
            Name = str;
            Pieces = new List<PipeLinePiece>();
        }
        public string Name { get; set; }

        public List<PipeLinePiece> Pieces { get; set; }
    }
}
