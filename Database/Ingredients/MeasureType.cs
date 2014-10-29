using System.ComponentModel;

namespace Database.Ingredients
{
    public enum MeasureType
    {
        [Description("По вкусу")]
        AtTaste = 0,

        [Description("Чайная ложка")]
        TeaSpoon = 1,

        [Description("Чайная ложка")]
        Item = 2
    }
}