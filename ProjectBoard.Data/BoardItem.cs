﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBoard.Data
{
    public class BoardItem
    {
        public Int64 ID { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Effort { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public Int32 Iteration { get; set; }
        public string OwnerName { get; set; }
        public string ParentID { get; set; }
    }
}
