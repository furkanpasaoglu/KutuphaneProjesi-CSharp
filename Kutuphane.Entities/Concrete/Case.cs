using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Case : IEntity
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public decimal Amount { get; set; }
    }
}