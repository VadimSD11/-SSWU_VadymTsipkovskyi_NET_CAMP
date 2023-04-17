using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise__2
{
    internal class Size
    {
        
        public float Width { get; set; }
        public float Height { get; set; }
        public float Depth { get; set; }

        public Size(float width, float height, float depth)
        {
            Width = width;
            Height = height;
            Depth = depth;
        }

        public override string? ToString()
        {
            return "Width := "+Width+" Height := "+Height+" Depth := "+Depth;
        }
    }
}
