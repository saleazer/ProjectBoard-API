﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBoard.Data
{
    public class ProjectAccess
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string AccessLevel { get; set; }
    }
}
