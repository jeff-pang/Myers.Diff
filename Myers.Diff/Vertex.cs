using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Myers.Diff
{
    public class Vertex
    {
        public int X { get; set; }
        public int Y { get; set; }
        public char C { get; set; }
        public int D { get; set; }

        public Vertex() { }
        public Vertex(int d,char c,int x,int y)
        {
            D = d;
            C = c;
            X = x;
            Y = y;
        }
    }
}
