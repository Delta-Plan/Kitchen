using System.ComponentModel;

namespace Database.Ingredients
{
    public enum MeasureType
    {
        [Description("По вкусу")]
        AtTaste,

        [Description("Чайная ложка")]
        TeaSpoon,

        [Description("Десертная ложка")]
        DessertSpoon,

        [Description("Столовая ложка")]
        SoupSpoon,

        [Description("Стакан")]
        Glass,

        [Description("Щепотка")]
        Thimbleful,

        [Description("Грамм")]
        Gram,

        [Description("Килограмм")]
        Kilo,

        [Description("Милилитр")]
        Milliliter,

        [Description("Литр")]
        Liter,

        [Description("Штука")]
        Item
    }
}