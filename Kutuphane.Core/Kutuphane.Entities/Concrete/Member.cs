namespace Kutuphane.Core.Kutuphane.Entities.Concrete
{
    public class Member : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public bool Status { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public string School { get; set; }
    }
}