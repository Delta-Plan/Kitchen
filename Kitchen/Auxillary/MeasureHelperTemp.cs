using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Web.Mvc;
using Database.Ingredients;

namespace Kitchen.Auxillary
{
    public class MeasureHelperTemp
    {
        public static MeasureType measureType { get; set; }

        public static IEnumerable<SelectListItem> ProductMeasureSelectList
        {
            get
            {
                return Enum.GetValues(typeof(MeasureType)).Cast<MeasureType>().Select(measure => new SelectListItem
                {
                    Value = ((int)measure).ToString(CultureInfo.InvariantCulture),
                    Text = GetDescription(measure),
                    Selected = measureType == measure
                });
            }
        }
        //S.Rozhin need to some other generic class
        private static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());
            var attribute = Attribute.GetCustomAttribute(field, typeof(DescriptionAttribute)) as DescriptionAttribute;
            return attribute == null ? value.ToString() : attribute.Description;
        }
    }
}