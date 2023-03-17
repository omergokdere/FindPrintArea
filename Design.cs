using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindPrintArea
{
    public class Design
    {
        private string path;
        private string fileName;
        private string defaultDesignName;
        private string givenDesignName;
        private Bitmap image;

        public string Path { get => path; set => path = value; }
        public string FileName { get => fileName; set => fileName = value; }
        public string GivenDesignName { get => givenDesignName; set => givenDesignName = value; }
        public string DefaultDesignName { get => defaultDesignName; set => defaultDesignName = value; }
        public Bitmap Image { get => image; set => image = value; }
    }
}
