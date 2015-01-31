namespace Database.Ingredients
{
    public class Component
    {
        public ProductType ProductType;//S.Rozhin todo to interface 
        public float Ammount;
        public MeasureType Measurement;
        public Component(float ammount, ProductType productType, MeasureType measurement)
        {
            if (measurement!=MeasureType.AtTaste)
            {
                Ammount = ammount;
            }
            ProductType = productType;
            Measurement = measurement;
        }
        public Component(){}
    }
}