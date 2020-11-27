using Microsoft.EntityFrameworkCore;
using System;

namespace ScrumLeaderboard.DATA
{
    //second comment test
    public class BoardItem
    {
        public Int64 ID { get; set; }
        public string ItemType { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public string Priority { get; set; }
        public string Effort { get; set; }


    }


}
