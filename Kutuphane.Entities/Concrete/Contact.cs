using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Contact : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string SubjectName { get; set; }
        public string Message { get; set; }
    }
}