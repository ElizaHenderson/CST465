﻿using Lab4.Code.DataObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Web;

namespace Lab4.Code.Repositories
{
    public class InventoryDBRepository : IDataEntityRepository<Inventory>
    {
        public Inventory Get(int id)
        {
            Inventory item = new Inventory();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
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
                        }
                    }
                }
            }
            return item;
        }

        public List<Inventory> GetList()
        {
            List<Inventory> items = new List<Inventory>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Product";
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
                            items.Add(item);
                        }
                    }
                }
            }
            return items;
        }
        public void Delete(int entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "DELETE FROM [Product] WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", entity);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Save(Inventory entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    if (entity.ID == 0)
                    {
                        command.CommandText = "INSERT INTO Product(ProductCode,ProductName,CategoryID,ProductDescription,ProductImage,Price,Quantity, ImageName,ImageType) VALUES(@ProductCode,@ProductName,@CategoryID,@ProductDescription,@ProductImage,@Price,@Quantity,@ImageName,@ImageType)";
                    }
                    else
                    {
                        command.CommandText = "UPDATE Product SET ProductCode=@ProductCode, ProductName=@ProductName, ImageName=@ImageName, ImageType=@ImageType, CategoryID=@CategoryID, ProductDescription=@ProductDescription, ProductImage=@ProductImage, Price=@Price, Quantity=@Quantity WHERE ID=@ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                    command.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
                    command.Parameters.AddWithValue("@CategoryID", entity.CategoryID);
                    command.Parameters.AddWithValue("@ProductDescription", entity.ProductDescription);
                    command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    command.Parameters.AddWithValue("@Price", entity.Price);
                    if (entity.FileName == null)
                    {
                        command.Parameters.AddWithValue("@ProductImage", 0);
                        command.Parameters.AddWithValue("@ImageType", "null");
                        command.Parameters.AddWithValue("@ImageName", "null");
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ProductImage", entity.ProductImage);
                        command.Parameters.AddWithValue("@ImageType", entity.ImageType);
                        command.Parameters.AddWithValue("@ImageName", entity.FileName);
                    }
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}