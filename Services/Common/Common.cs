using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Services
{
    public class CommonService
    {
        /// <summary>
        /// 取得下拉選單範例參考
        /// </summary>
        /// <param name="sParams">查找資料庫使用的參數</param>
        /// <returns></returns>
        public List<SelectListItem> Get_DropDownListTest(params string[] sParams)
        {
            List<SelectListItem> Data_List = new List<SelectListItem>();

            #region ToDo...從資料庫取出資料
            //// 範例 
            var data = new[] { 
                new SelectListItem { Value = "排", Text = "排球"} ,
                new SelectListItem { Value = "網", Text = "網球"} ,
                new SelectListItem { Value = "羽", Text = "羽球"} 
            };
            #endregion

            Data_List.AddRange(data);

            return Data_List;
        }
    }
}
