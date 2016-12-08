using Lab4.Code.DataObjects;
using Lab4.Code.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        IDataEntityRepository<BlogPost> _stuff;
        public HomeController()
        {
            _stuff = new BlogDBRepository();
        }
        //public HomeController(IDataEntityRepository<BlogPost> thing)
        //{
        //    _stuff = thing;
        //}
        // GET: Home
        public ActionResult Index()
        {
            List<BlogPost> thingy = new List<BlogPost>();
            List<Inventory> objects = new List<Inventory>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP(3) * FROM Blog ORDER BY Timestamp DESC";
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost item = new BlogPost();
                            item.ID = (int)reader["ID"];
                            item.Title = reader["Title"].ToString();
                            item.Content = reader["Content"].ToString();
                            item.Author = reader["Author"].ToString();
                            item.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                            thingy.Add(item);
                        }
                    }
                }
            }
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT TOP(5) * FROM Product";
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Inventory item = new Inventory();
                            item.ID = (int)reader["ID"];
                            item.ProductName = reader["ProductName"].ToString();
                            item.ProductCode = reader["ProductCode"].ToString();
                            item.CategoryID = (int)reader["CategoryID"];
                            item.Quantity = (int)reader["Quantity"];
                            item.Price = (decimal)reader["Price"];
                            item.ProductDescription = reader["ProductDescription"].ToString();
                            item.FileName = reader["ImageName"].ToString();
                            item.ImageType = reader["ImageType"].ToString();
                            item.ProductImage = (byte[])reader["ProductImage"];
                            objects.Add(item);
                        }
                    }
                }
            }

            Tuple<List<BlogPost>, List<Inventory>>ret_val = Tuple.Create(thingy, objects);
            return View(ret_val);
        }
    }
}