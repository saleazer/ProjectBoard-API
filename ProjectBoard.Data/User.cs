using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectBoard.Data
{
    public class User
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
