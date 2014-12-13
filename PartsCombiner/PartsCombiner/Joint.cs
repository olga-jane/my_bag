using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsCombiner
{
    public class Joint
    {
        public Joint(Part part1, Part part2)
        { 
            this.part1 = part1;
            this.part2 = part2;
        }
        public Part part1;
        public Part part2;
    }
}
