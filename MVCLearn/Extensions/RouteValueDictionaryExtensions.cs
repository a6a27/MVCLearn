using System.Web.Mvc;
using System.Web.Routing;


    /// <summary>
    /// RouteValueDictionaryExtensions
    /// </summary>
    public static class RouteValueDictionaryExtensions
    {
        //通用型的
        //本處採用的是通盤的寫法 將所有寫入至RouteValueDictionary的屬性賦予在欄位最後面
        //EX:
        //var routeValue = new RouteValueDictionary();
        //routeValue["readonly"] = "";
        //routeValue["disabled"] = "";
        //@Html.TextBoxFor(model => model.EmpoID, routeValue.Merge(new { @class = "form-control m-b dropdownlist-right", @maxlength = "10", @onkeyup = "value=value.replace(/[\\W]/g,'')" }))                           
        public static RouteValueDictionary Merge(this RouteValueDictionary source, object mergeObject)
        {
            //var result = new RouteValueDictionary(mergeObject);
            var result = HtmlHelper.AnonymousObjectToHtmlAttributes(mergeObject);

            foreach (var key in source.Keys)
            {
                result[key] = source[key];
            }

            return result;
        }

        //先轉型(之所以多做這一層是為了確保型別的正確性 
        //因為該Extensions是加在object上的 如連續性使用將會導致型別錯誤 
        //EX:X.ReadOnly(CloseALL).Disabled(CloseALL))
        public static RouteValueDictionary ReadOnly(this object source, bool readOnly)
        {
            //var result = new RouteValueDictionary(source);
            var result = HtmlHelper.AnonymousObjectToHtmlAttributes(source);

            //轉型完再丟去加上readonly屬性
            return result.ReadOnly(readOnly);
        }

        //賦予對應的屬性
        public static RouteValueDictionary ReadOnly(this RouteValueDictionary source, bool readOnly)
        {
            if (readOnly)
                source["readonly"] = "";

            return source;
        }

        //先轉型(之所以多做這一層是為了確保型別的正確性 
        //因為該Extensions是加在object上的 如連續性使用將會導致型別錯誤 
        //EX:X.ReadOnly(CloseALL).Disabled(CloseALL))
        public static RouteValueDictionary Disabled(this object source, bool disabled)
        {
            //var result = new RouteValueDictionary(source);
            var result = HtmlHelper.AnonymousObjectToHtmlAttributes(source);

            //轉型完再丟去加上disabled屬性
            return result.Disabled(disabled);
        }

        //賦予對應的屬性
        public static RouteValueDictionary Disabled(this RouteValueDictionary source, bool disabled)
        {
            if (disabled)
                source["disabled"] = "";

            return source;
        }
    }

