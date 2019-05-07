using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public string ImgPath { get; set; }
        public decimal Price { get; set; }
        public Kategorien Kategorien { get; set; }

        public Article() : this(0, "","","", 0.0m, Kategorien.nichtFestgelegt){}
        public Article(int id, string name, string description, string imgPath, decimal price, Kategorien kategorien)
        {
            this.ID = id;
            this.Name = name;
            this.Description = description;
            this.ImgPath = imgPath;
            this.Price = price;
            this.Kategorien = kategorien; 
        }

        public override string ToString()
        {
            return this.ID + " " + this.Name +
                Environment.NewLine + this.Description + "" + this.Price + " €";
        }
    }
    public enum Kategorien
    {
        Ring, Armband, Kette, Ohrring, nichtFestgelegt
    }
}