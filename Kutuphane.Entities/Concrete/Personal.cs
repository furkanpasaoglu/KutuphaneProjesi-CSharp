using System.ComponentModel.DataAnnotations;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Personal : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Personel Adı Boş Geçilemez")]
        public string Name { get; set; }
    }
}