using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Lab4.Code.Repositories
{
    public class BlogDBRepository2 : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            List<BlogPost> items = new List<BlogPost>();
            items = GetList();
            BlogPost thing = items.Where(i => i.ID == id).FirstOrDefault();
            return thing;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> items = null;
            var path = "~/App_Data/Data.json";


            JavaScriptSerializer cereal = new JavaScriptSerializer();
            var reader = new StreamReader(HttpContext.Current.Server.MapPath(path));
            var stream = reader.ReadToEnd();

            items = cereal.Deserialize<List<BlogPost>>(stream);
            if(items == null)
            {
                items = new List<BlogPost>();
            }
            reader.Close();

            return items;
        }

        public void Save(BlogPost entity)
        {
            List<BlogPost> items = GetList();
            var path = "~/App_Data/Data.json";
            JavaScriptSerializer cereal = new JavaScriptSerializer();
            int id = 1;
            if(entity.ID == 0)
            {
                if(items == null || items.Count == 0)
                    id = 1;
                else
                    id = items.Max(m => m.ID) + 1;
                entity.ID = id;
                entity.Timestamp = DateTime.UtcNow.ToLocalTime();
                items.Add(entity);
            }
            else
            {
                id++;
                BlogPost temp = items.Where(m => m.ID == entity.ID).First();
                int diff = items.IndexOf(temp);
                temp.Title = entity.Title;
                temp.ID = entity.ID;
            }
            string thing;
            thing = cereal.Serialize(items);
            var file = new StreamWriter(HttpContext.Current.Server.MapPath(path));
            file.Write(thing);
            file.Close();
        }
    }
}