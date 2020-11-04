using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Xml;

namespace Inventory_Management_System_with_ADO.NET.Models
{
    public class CategoryDataAccess
    {
        DataAccess dataAccess;

        public CategoryDataAccess()
        {
            this.dataAccess = new DataAccess();
        }

        public List<Category> GetAllCategories()
        {
            string sql = "SELECT * FROM Categories";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Category> catList = new List<Category>();

            while (reader.Read())
            {
                Category cat = new Category();
                cat.CategoryId = (int)reader["CategoryId"];
                cat.CategoryName = reader["CategoryName"].ToString();
                catList.Add(cat);
            }

            return catList;
        }

        public Category GetCategoryById(int id)
        {
            string sql = "SELECT * FROM Categories WHERE CategoryId=" + id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Category cat = new Category();
            cat.CategoryId = (int)reader["CategoryId"];
            cat.CategoryName = reader["CategoryName"].ToString();
            return cat;
        }

        public int InsertCategory(Category cat)
        {
            string sql = "INSERT INTO Categories(CategoryName) VALUES('" + cat.CategoryName + "')";
            return dataAccess.ExecuteQuery(sql);
        }

        public int UpdateCategory(Category cat)
        {
            string sql = "UPDATE Categories SET CategoryName='" + cat.CategoryName + "' WHERE CategoryId=" + cat.CategoryId;
            return dataAccess.ExecuteQuery(sql);
        }

        public int DeleteCategory(int id)
        {
            string sql = "DELETE FROM Categories WHERE CategoryId=" + id;
            return dataAccess.ExecuteQuery(sql);
        }
    }
}