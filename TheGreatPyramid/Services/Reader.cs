using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheGreatPyramid.Services
{
    public class Reader
    {
        public string[] Read()
        {
            var path = @"C:\Dev\pyramid.txt";

            var lines = File.ReadAllLines(path);

            return lines;
        }
    }
}
