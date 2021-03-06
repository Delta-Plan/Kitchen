﻿using System.Data.Linq.Mapping;
using Database.Abstracts;
using Database.Ingredients;

namespace Database.Models
{
    [Table(Name = "Recipes")]
    public class BaseRecipe : IBaseEntity
    {
        [Column]
        public int OwnerId { get;  set; }

        [Column(IsPrimaryKey = true, Name = "Id", IsDbGenerated = true)] 
        protected int _id;

        public int Id
        {
            get { return _id; }
        }

        [Column]
        public string Name;

        [Column]
        public string Description;

        [Column(Name = "IngridientsJson")]
        private string _ingridientsJson;

        [Column]
        public bool IsPublic;

        [Column]
        protected int RecipeTypeId;

        public int RecipeType
        {
            get { return RecipeTypeId; }
        }

        private RecipieIngridients _recipieIngridients;
        public RecipieIngridients Ingridients
        {
            get
            {
                if (_recipieIngridients == null)
                {
                    _recipieIngridients = new RecipieIngridients(_ingridientsJson);
                    return _recipieIngridients;
                }
                return _recipieIngridients;
            }
            set { _recipieIngridients = value;
                _ingridientsJson = value.SerialiseToJsonString();
            }
        }

    }
}