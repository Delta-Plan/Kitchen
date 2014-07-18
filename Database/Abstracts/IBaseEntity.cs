using System.Data.Linq;
using common.Logging;

namespace Database.Abstracts
{
    public interface IBaseEntity//todo S.rozhin check for internal
    {
        int Id { get;}
        bool Save(DataContext dc, int userId, ILogger log, bool doSubmit = false);
        bool Delete(DataContext dc, int userId, ILogger log, bool doSubmit = false);
    }
}