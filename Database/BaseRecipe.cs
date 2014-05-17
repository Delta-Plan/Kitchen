
using System;
using System.Collections.Generic;
using System.Data.Linq.Mapping;

namespace Database
{
    [Table(Name = "Recipes")]
    public abstract class BaseRecipe
    {
        [Column(IsPrimaryKey = true)]
        public int Id;

        [Column]
        public string Name;

        [Column]
        public string Description;

        [Column(Name = "IngridientsJson")]
        private string _ingridientsJson;


        public Dictionary<int, string> Ingridients
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }
    }
}