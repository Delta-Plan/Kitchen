using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Database.Abstracts;
using Database.Accessors;
using Database.Ingredients;

namespace Database
{
    [Table(Name = "dbo.Recipes")]
    public abstract class BaseRecipe: BaseEntity<BaseRecipe>
    {
        [Column]
        public string Name;

        [Column]
        public string Description;

        [Column(Name = "IngridientsJson")]
        private string _ingridientsJson;

        [Column]
        public bool IsPublic;

        protected override BaseRecipe GetRef()
        {
            return this;
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
            set { _recipieIngridients = value; }
        }

        [Column]
        public int OwnerId { get; private set; }
    }
}