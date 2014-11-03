using System;
using System.Data.Linq.Mapping;
using Database.Models;

namespace Database
{
    [Obsolete]
    public class SimpleRecipe : BaseRecipe
    {
        public SimpleRecipe()
            : base()
        {
            this.IsPublic = true;
        }
    }
}