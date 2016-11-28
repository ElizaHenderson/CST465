using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code.DataObjects
{
    public class Categories : IDataEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}