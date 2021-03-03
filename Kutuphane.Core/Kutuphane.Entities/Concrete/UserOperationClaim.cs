namespace Kutuphane.Core.Kutuphane.Entities.Concrete
{
    public class UserOperationClaim : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int OperationClaimId { get; set; }
    }
}