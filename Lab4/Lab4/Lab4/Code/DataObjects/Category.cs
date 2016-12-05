using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Code.DataObjects
{
    public class Category : IDataEntity
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
    }
}