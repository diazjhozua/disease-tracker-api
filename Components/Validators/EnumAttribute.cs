using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace disease_tracker_api.Components.Validators
{
    public class EnumAttribute : ValidationAttribute
    {
        // public class enumType { get; set; }

        // public override bool IsValid(object value)
        // {
        //     int enumValue = (int)value;

        //     if (Enum.IsDefined(typeof(this.enumType), enumValue))
        //     {
        //         int len = strValue.Length;
        //         // return len >= this.Minimum && len <= this.Maximum;
        //         return true;
        //     }
        //     return false;
        // }

            // public int Minimum { get; set; }
            // public int Maximum { get; set; }

            // public EnumAttribute()
            // {
            //     this.Minimum = 0;
            //     this.Maximum = int.MaxValue;
            // }

            // public override bool IsValid(object value)
            // {
            //     string strValue = value as string;
            //     if (!string.IsNullOrEmpty(strValue))
            //     {
            //         int len = strValue.Length;
            //         return len >= this.Minimum && len <= this.Maximum;
            //     }
            //     return true;
            // }
    }
}