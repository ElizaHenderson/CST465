using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4.Code.Repositories
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            BlogPost item = new BlogPost();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item.ID = (int)reader["ID"];
                            item.Title = reader["Title"].ToString();
                            item.Content = reader["Content"].ToString();
                            item.Author = reader["Author"].ToString();
                            item.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        }
                    }
                }
            }
            return item;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> items = new List<BlogPost>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog";
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            BlogPost item = new BlogPost();
                            item.ID = (int)reader["ID"];
                            item.Title = reader["Title"].ToString();
                            item.Content = reader["Content"].ToString();
                            item.Author = reader["Author"].ToString();
                            item.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        public void Save(BlogPost entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if(entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Blog(Author, Title, Content) VALUES(@Author, @Title, @Content)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Blog SET Title=@Title, Content=@Content, Author=@Author WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@Content", entity.Content);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}