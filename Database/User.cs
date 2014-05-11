using Database.Entities;

namespace Database
{
    public class User : Entity
    {
        public string Name { get; set; }
        public int RoleId { get; set; }
    }
}
