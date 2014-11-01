using System.Data;
using System.Data.Linq.Mapping;
using Database.Abstracts;
using Database.Ingredients;

namespace Database.Models
{
    [Table(Name = "Recipes")]
    //[InheritanceMapping(Type = typeof(BaseRecipe), IsDefault = true, Code = 1)]
    //[InheritanceMapping(Type = typeof(SimpleRecipe), IsDefault = false, Code = 2)]
    public class BaseRecipe : IBaseEntity
    {
        [Column]
        public int OwnerId { get;  set; }

        
        protected int _id;

        [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, DbType = "Int NOT NULL IDENTITY", IsPrimaryKey = true, IsDbGenerated = true)]
        public int Id
        {
            get { return _id; }
            set {}
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
        //protected int RecipeTypeId;

        //public int RecipeType
        //{
        //    get { return RecipeTypeId; }
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

    }
}