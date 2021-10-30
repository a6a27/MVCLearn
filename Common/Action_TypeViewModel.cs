using System.ComponentModel.DataAnnotations;

namespace Common
{
    public enum Action_Type
    {
        //本ViewModel規劃為對應權限的新增/修改/停用/查詢 為全系統共用
        [Display(Name = "新增")]
        Insert,
        [Display(Name = "修改")]
        Update,
        [Display(Name = "刪除")]
        Stop,
        [Display(Name = "審核")]
        Audit,
        [Display(Name = "瀏覽")]
        Select,
        [Display(Name = "取消")]
        Cancel,
        [Display(Name = "其他")]
        Other,
    }
}
