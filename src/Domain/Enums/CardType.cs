using System.ComponentModel.DataAnnotations;

namespace MetroPass.Domain.Enums
{
    public enum CardType
    {
        /// <summary>
        /// 一般票卡
        /// </summary>
        [Display(Name = "一般票卡")]
        Ｓtandard,

        /// <summary>
        /// 學生票
        /// </summary>
        [Display(Name = "學生票")]
        Student,

        /// <summary>
        /// 敬老票
        /// </summary>
       [Display(Name = "敬老票")] 
        Elderly,

        /// <summary>
        //  基北北桃都會通
        /// </summary>
        [Display(Name = "基北北桃都會通")]
        TPass
    }

}
