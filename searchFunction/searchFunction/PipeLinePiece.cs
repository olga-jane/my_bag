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

        public PipeLinePiece(string str, int w): this(str)
        {
            this.Weigth = w;
        }

        public string Name { get; set; }
        public int Weigth { get; set; }

        public List<Joint> Joints { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
