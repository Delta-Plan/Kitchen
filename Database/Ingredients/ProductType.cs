using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database.Ingredients
{
    public interface IProductType : IBaseEntity//todo immutable
    {
        string Name { get; }
        string Description { get; }
        MeasureType DefaultMeasurement { get; }
    }

    public class ProductType : IProductType
    {
        [Column]
        public int Id { get; private set; }
        [Column]
        public string Description { get; set; }
        [Column]
        public string Name { get; set; }
        [Column(Name = "Measurement", DbType = "int")]//s.rozhin возможно так не полетит, переделаю на геттер и сеттер с приватной интовой переменной
        public MeasureType DefaultMeasurement { get; set; }
        public ProductType() { }
    }
    
}