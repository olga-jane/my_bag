using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PartsCombiner
{
    public class Part
    {
        public Guid Id { get; set; }
        public string Number { get; set; }


        public Part(Guid id, string number)
        {
            this.Id = id;
            this.Number = number;
        }

        public override string ToString()
        {
            return Number;
        }
    }
}
