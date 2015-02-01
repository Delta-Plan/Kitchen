using System.ComponentModel;

namespace Database.Ingredients
{
    public enum MeasureType
    {
        [Description("По вкусу")]
        AtTaste = 0,

        [Description("Чайная ложка")]
        TeaSpoon = 1,

        [Description("Большая ложка")]
        SoupSpoon = 2,

        [Description("Стакан")]
        Glass = 3,

        [Description("Щепотка")]
        Thimbleful = 4,

        [Description("Грамм")]
        Gram = 5,

        [Description("Килограмм")]
        Kilo = 6,

        [Description("Милилитр")]
        Milliliter = 7,

        [Description("Литр")]
        Liter = 8,

        [Description("Штука")]
        Item = 9
    }
}