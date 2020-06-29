using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetNote.ViewModel
{
    public class LoginViewModel
    {
        /// <summary>
        /// 사용자 ID
        /// </summary>
        [Required(ErrorMessage = "사용자 아이디를 입력하세요")] // Not Null 설정
        public string UserId { get; set; }

        /// <summary>
        /// 사용자 비밀번호
        /// </summary>
        [Required(ErrorMessage = "사용자 비밀번호 입력하세요")] // Not Null 설정
        public string UserPassword { get; set; }
    }
}
