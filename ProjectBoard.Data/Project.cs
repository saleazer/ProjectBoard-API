using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBoard.Data
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Creator { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
