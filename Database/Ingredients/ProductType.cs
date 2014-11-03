using System.Data.Linq.Mapping;
using Database.Abstracts;

namespace Database.Ingredients
{
    public interface IProductType//todo immutable
    {
        string Name { get; }
        string Description { get; }
        MeasureType DefaultMeasurement { get; }
    }

    public class ProductType : IBaseEntity, IProductType
    {
        private int _id;

        [Column(Storage = "_id", AutoSync = AutoSync.OnInsert, IsDbGenerated = true)]
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        [Column]
        public string Description { get; set; }

        [Column]
        public string Name { get; set; }

        [Column(Name = "Measurement", DbType = "int")]//s.rozhin возможно так не полетит, переделаю на геттер и сеттер с приватной интовой переменной
        public MeasureType DefaultMeasurement { get; set; }
        public ProductType() { }
    }
    
}