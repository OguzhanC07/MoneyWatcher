using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyWatcher.Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage ="FullName can Not be Empty")]
        [MaxLength(150,ErrorMessage ="S")]       
        [MinLength(1,ErrorMessage ="az uzun yap mk")]
        public string FullName { get; set; }
        [Required(ErrorMessage ="mk")]
        [MaxLength(50,ErrorMessage ="50")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage ="sifre yaz ")]
        [MaxLength(150,ErrorMessage ="ne bileyimmk")]
        [MinLength(1,ErrorMessage ="afsa")]
        public string Password { get; set; }
    }
}
