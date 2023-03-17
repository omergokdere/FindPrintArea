using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPrintArea
{
    public class BlankProduct
    {
        private String name;
        private String description;
        private String category;
        private String color;
        private String side;
        private String path;
        private String parentFolder;
        private Rectangle printRegion;

        public BlankProduct()
        {

        }

        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public string Category { get => category; set => category = value; }
        public string Color { get => color; set => color = value; }
        public string Side { get => side; set => side = value; }
        public string Path { get => path; set => path = value; }
        public Rectangle PrintRegion { get => printRegion; set => printRegion = value; }
        public string ParentFolder { get => parentFolder; set => parentFolder = value; }
    }
}
