using System.ComponentModel.DataAnnotations;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Author : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Yazar Adını Boş Geçemezsiniz")]
        public string Name { get; set; }
        [StringLength(20, ErrorMessage = "Soyad 20 Karakterden Uzun Olamaz")]
        public string Surname { get; set; }
        public string Detail { get; set; }
    }
}