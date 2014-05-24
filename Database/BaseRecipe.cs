
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Data.Linq.Mapping;
using Database.Ingredients;
using Database.baseAccessors;
using common.logging;

namespace Database
{
    [Table(Name = "Recipes")]
    public abstract class BaseRecipe: IBaseEntity
    {
        [Column(IsPrimaryKey = true,IsDbGenerated = true)]
        public int Id;

        [Column]
        public string Name;

        [Column]
        public string Description;

        [Column(Name = "IngridientsJson")]
        private string _ingridientsJson;

        [Column(Name = "Deleted")]
        private bool _isDeleted;

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
            protected set { throw new NotImplementedException(); }
        }

        public int OwnerId { get; private set; }

        public bool Save(DataContext dc, int userId, ILogger log, bool doSubmit = false)
        {
            var table = dc.GetTable<BaseRecipe>();
            //todo existing entity check
            table.InsertOnSubmit(this);
            if (doSubmit)
            {
                dc.SubmitChanges(ConflictMode.FailOnFirstConflict);
            }
            return true;
        }

        public bool Delete(DataContext dc, int userId, ILogger log, bool doSubmit = false)
        {
            if (OwnerId!=userId)
            {
                log.Warn("Trying to delete recipie not by owner");
                return false;
            }
            _isDeleted = true;
            if (doSubmit)
            {
                dc.SubmitChanges();
            }
            return true;
        }
    }
}