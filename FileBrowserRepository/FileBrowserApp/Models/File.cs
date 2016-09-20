using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FileBrowserApp.Models
{
    public class File
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public double Size { get; set; }
    }
}