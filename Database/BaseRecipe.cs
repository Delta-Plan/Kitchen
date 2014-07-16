using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Database.Accessors;
using Database.Ingredients;
using common.logging;

namespace Database
{
    [Table(Name = "Recipes")]
    public abstract class BaseRecipe: BaseEntity<BaseRecipe>
    {
        [Column]
        public string Name;

        [Column]
        public string Description;

        [Column(Name = "IngridientsJson")]
        private string _ingridientsJson;

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
        public int OwnerId { get; private set; }
    }
}