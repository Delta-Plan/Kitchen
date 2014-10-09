using System.Collections.Generic;
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
                for (int i = 0; i < 3; i++)
                {
                    yield return new SelectListItem
                    {
                        Value = i.ToString(),
                        Text = ((MeasureType)i).ToString(),
                        Selected = (int) measureType == i
                    };
                }
            }
        }
    }
}