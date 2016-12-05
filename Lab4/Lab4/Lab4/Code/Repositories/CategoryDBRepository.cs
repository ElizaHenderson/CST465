using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4.Code.Repositories
{
    public class CategoryDBRepository : IDataEntityRepository<Category>
    {
        public Category Get(int id)
        {
            Category item = new Category();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Category WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            item.ID = (int)reader["ID"];
                            item.CategoryName = reader["Category"].ToString();
                        }
                    }
                }
            }
            return item;
        }

        public List<Category> GetList()
        {
            List<Category> items = new List<Category>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Category";
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Category item = new Category();
                            item.ID = (int)reader["ID"];
                            item.CategoryName = reader["CategoryName"].ToString();
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        public void Save(Category entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Category(CategoryName) VALUES(@CategoryName)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Category SET CategoryName=@CategoryName WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.Parameters.AddWithValue("@CategoryName", entity.CategoryName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}