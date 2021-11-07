using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCLearn.Enum
{
    public enum ClassStudent_Money
    {
        [Display(Name = "不方便透漏")]
        不說,
        [Display(Name = "貧窮")]
        貧,
        [Display(Name = "一般")]
        一般,
        [Display(Name = "富裕")]
        富裕
    }
}