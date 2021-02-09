using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Adı Boş Bırakamazsınız")]
        [StringLength(20,ErrorMessage ="En Fazla 20 Karakter Girebilirsiniz")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        [Required(ErrorMessage = "Kullanıcı Adını Boş Bırakamazsınız")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Şifre Alanını Boş Bırakamazsınız")]
        [StringLength(10, ErrorMessage = "En Fazla 10 Karakter Girebilirsiniz")]
        public string Password { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
    }
}