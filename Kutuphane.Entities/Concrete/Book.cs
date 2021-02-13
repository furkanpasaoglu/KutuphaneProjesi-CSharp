using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Book : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string YearofPublication { get; set; }
        public string PublishingHouse { get; set; }
        public string Page { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
    }
}