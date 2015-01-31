﻿using System.ComponentModel;

namespace Database.Ingredients
{
    public enum MeasureType
    {
        [Description("По вкусу")]
        AtTaste = 0,

        [Description("Чайная ложка")]
        TeaSpoon = 1,
        SoupSpoon=2,
        Glass = 3,
        Thimbleful = 4,//щепотка
        Gram = 5,
        Kilo = 6,
        Milliliter = 7,
        Liter = 8,
        Item = 9// это я так поняла шт.    }
}