using System.Data.Linq;
using System.Data.Linq.Mapping;
using Database.baseAccessors;
using common.logging;

namespace Database.Ingredients
{
    public interface IIngridient : IBaseEntity//todo immutable
    {
    }

    class Ingridient : BaseEntity<Ingridient>, IIngridient
    {
        [Column] public string Description;
        [Column] public string Name;
        protected override Ingridient GetRef()
        {
            return this;
        }
    }
}