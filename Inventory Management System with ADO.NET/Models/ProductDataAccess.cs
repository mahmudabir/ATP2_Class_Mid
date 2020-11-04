using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Inventory_Management_System_with_ADO.NET.Models
{
    public class ProductDataAccess
    {
        private DataAccess dataAccess;

        public ProductDataAccess()
        {
            this.dataAccess = new DataAccess();
        }
        public List<Product> GetAllProducts()
        {
            string sql = "SELECT * FROM Products";
            SqlDataReader reader = dataAccess.GetData(sql);
            List<Product> productList = new List<Product>();

            while (reader.Read())
            {
                Product product = new Product();
                product.ProductId = (int)reader["ProductId"];
                product.ProductName = reader["ProductName"].ToString();
                product.Price = Convert.ToDouble(reader["Price"]);
                product.CategoryId = (int)reader["CategoryId"];
                productList.Add(product);
            }
            return productList;
        }

        public Product GetProductById(int id)
        {
            string sql = "SELECT * FROM Products WHERE ProductId=" + id;
            SqlDataReader reader = dataAccess.GetData(sql);
            reader.Read();
            Product product = new Product();
            product.ProductId = (int)reader["ProductId"];
            product.ProductName = (string)reader["ProductName"];
            product.Price = (double)reader["Price"];
            product.CategoryId = (int)reader["CategoryId"];
            return product;
        }

        public int InsertProduct(Product product)
        {
            string sql = "INSERT INTO Products(ProductName, Price, CategoryId) VALUES('" + product.ProductName + "," + product.Price + ", " + product.CategoryId + "')";
            return dataAccess.ExecuteQuery(sql);
        }
        public int UpdateProduct(Product product)
        {
            string sql = "UPDATE Products SET ProductName=" + product.ProductName + ", Price="+product.Price+", CategoryId="+product.CategoryId+" WHERE ProductId=" + product.CategoryId;
            return dataAccess.ExecuteQuery(sql);
        }

        public int DeleteProduct(int id)
        {
            string sql = "DELETE FROM Products WHERE ProductId=" + id;
            return dataAccess.ExecuteQuery(sql);
        }


    }
}