using Database.Entities;

namespace Database
{
    public class Role : Entity
    {
        public string ShortName { get; set; }
        public string Descriprion { get; set; }
    }
}
