using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class About : IEntity
    {
        public int Id { get; set; }
        public string Details { get; set; }
    }
}