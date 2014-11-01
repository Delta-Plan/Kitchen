using System.Data.Linq;
using common.Logging;

namespace Database.Abstracts
{
    public interface IBaseEntity//todo S.rozhin check for internal
    {
        int Id { get; set; }
        //bool IsDeleted { get; }
    }
}