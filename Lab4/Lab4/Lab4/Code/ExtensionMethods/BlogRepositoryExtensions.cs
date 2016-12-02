using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab4.Code.ExtensionMethods
{
    static public class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> bob, string steve)
        {
            List<BlogPost> jerry = bob.GetList();
            jerry = jerry.Where(m => m.Content.Contains(steve) || m.Title.Contains(steve)).ToList();
            return jerry;
        }
    }
}