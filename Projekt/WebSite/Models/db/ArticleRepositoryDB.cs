using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebSite.Models;


namespace WebSite.Models.db
{
    public class ArticleRepositoryDB : IArticleRepository
    {

        private string _connectionString = "Server=localhost; Database=db_swp; Uid=root";
        private MySqlConnection _connection;
         

        public void Open()
        {
            try
            {
                if (this._connection == null)
                {
                    this._connection = new MySqlConnection(this._connectionString);
                }
                if (this._connection.State != ConnectionState.Open)
                {
                    this._connection.Open();
                }
            }
            catch (MySqlException)
            {
                throw;
            }

        }
        public void Close()
        {

            try
            {
                if (this._connection != null && this._connection.State == ConnectionState.Open)
                {
                    this._connection.Close();
                    this._connection = null;
                }
            }
            catch (MySqlException)
            {
                throw;
            }

        }

        public List<Article> GetAllArticles(Kategorien type)
        {
            try
            {
                List<Article> articles = new List<Article>(); 
                MySqlCommand cmd = this._connection.CreateCommand();
                cmd.CommandText = "Select * from article where category = @category";
                cmd.Parameters.AddWithValue("category", type); 
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        articles.Add(new Article()
                        {
                            Name = Convert.ToString(reader["name"]),
                            Description = Convert.ToString(reader["description"]),
                            Kategorien = (Kategorien)Convert.ToInt32(reader["category"]),
                            Price = Convert.ToDecimal(reader["price"]),
                            ImgPath = Convert.ToString(reader["ImgPath"]),
                            ID = Convert.ToInt32(reader["ID"])

                        });
                    }
                }
                return articles.Count == 0 ? null : articles;
            }
            catch(MySqlException)
            {
                throw; 
            }
        }

        public Article GetArticleByID(int id)
        {
            try
            {
                Article article = new Article();
                MySqlCommand cmd = this._connection.CreateCommand();
                cmd.CommandText = "Select * from article where id = @id";
                cmd.Parameters.AddWithValue("id", id);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        article.Description = Convert.ToString(reader["description"]);
                        article.Name = Convert.ToString(reader["name"]);
                        article.ImgPath = Convert.ToString(reader["ImgPath"]);
                        article.Price = Convert.ToDecimal(reader["price"]);
                        article.Kategorien = (Kategorien)Convert.ToInt32(reader["category"]);

                    }
                }
                return article;
            }
            catch (MySqlException)
            {
                throw;
            }
        }
        public void InsertArticle(Article articleToIsert)
        {
            try
            {
                MySqlCommand cmdInsert = this._connection.CreateCommand();

                cmdInsert.CommandText = "insert into article values(null, @Name, @description, @category, @price, @ImgPath)";
                cmdInsert.Parameters.AddWithValue("Name", articleToIsert.Name);
                cmdInsert.Parameters.AddWithValue("description", articleToIsert.Description);
                cmdInsert.Parameters.AddWithValue("category", articleToIsert.Kategorien);
                cmdInsert.Parameters.AddWithValue("price", articleToIsert.Price);
                cmdInsert.Parameters.AddWithValue("ImgPath", articleToIsert.ImgPath);

                cmdInsert.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                throw;
            }
        }


    }
}