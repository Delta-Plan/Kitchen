using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Database.Abstracts;
using Database.Accessors;
using Database.Ingredients;

namespace Database
{
    //[InheritanceMapping(Type = typeof(BaseRecipe), IsDefault = true, Code = 1)] 
    [Table(Name = "Recipes")] // todo начнём с простого...как минимум с того, что, хотя бы, работает...
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

        //[Column(IsDiscriminator = true, Name = "RecipeTypeId")] 
        //protected int _recipeTypeId;

        //public int RecipeType
        //{
        //    get { return _recipeTypeId; }
        //}

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

        //[Column(IsDiscriminator = true, Name = "Disctiminator")]
        //public int? RecipeType { get; set; }
        

    }
}