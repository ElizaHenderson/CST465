using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code.DataObjects
{
    public class BlogPost : IDataEntity
    {
        public int ID { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

    }
}