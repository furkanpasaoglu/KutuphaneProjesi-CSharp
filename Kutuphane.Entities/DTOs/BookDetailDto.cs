using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.DTOs
{
    public class BookDetailDto : IDto
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string AuthorName { get; set; }
        public string AuthorSurname { get; set; }
        public string YearofPublication { get; set; }
        public string PublishingHouse { get; set; }
        public string Page { get; set; }
        public bool Status { get; set; }

    }
}