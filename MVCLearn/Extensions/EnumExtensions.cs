using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
public static class EnumExtensions
{
    //取得Enum對應的DisplayName(如需其它的DisplayAttribute亦可稍做修改來取得，藉此在前端靈活呈現&運用)
    public static string GetDisplayName(this Enum e)
    {
        var displayAttr = (DisplayAttribute)getTypeValue(e)
            .GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault();

        return displayAttr.Name;
    }

    private static System.Reflection.MemberInfo getTypeValue(Enum e)
    {
        var type = e.GetType();
        var typeValue = type.GetMember(e.ToString()).FirstOrDefault();
        return typeValue;
    }
}
