using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab4.Code.Repositories
{
    public class CategoriesDBRepository
    {
        public Categories Get(int id)
        {
            Categories item = new Categories();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Categories WHERE ID=@ID";
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

        public List<Categories> GetList()
        {
            List<Categories> items = new List<Categories>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Categories";
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Categories item = new Categories();
                            item.ID = (int)reader["ID"];
                            item.CategoryName = reader["CategoryName"].ToString();
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }

        public void Save(Categories entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Categories(CategoryName) VALUES(@Name)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Categories SET CategoryName=@Name WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.Parameters.AddWithValue("@Name", entity.CategoryName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}