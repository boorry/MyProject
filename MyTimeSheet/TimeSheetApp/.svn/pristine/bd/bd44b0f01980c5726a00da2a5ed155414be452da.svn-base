using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using System.Windows.Controls;

namespace TimeSheetApp.Model
{
    public class MyValidationRules : ValidationRule
    {
        public float? EstimateDuration { get; set; }

        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            float estimate;

            if (value != null && float.TryParse(value.ToString(), out estimate))
                return new ValidationResult(true, null);
                return new ValidationResult(false, "Ce champ doit contenir un nombre !");
            
        }
        
    }
}
