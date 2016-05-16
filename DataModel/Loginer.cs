using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataEntity
{
    /// <summary>
    /// API文档开发者
    /// </summary>
    public class Loginer
    {
        /// <summary>
        /// 账户
        /// </summary>
        [Required]
        [Display(Name = "账户")]
        public string Account { get; set; }


        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        [Display(Name = "密码")]
        public string Password { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        [Required]
        [Display(Name = "验证码")]
        public string ValidateCode { get; set; }
    }
}
