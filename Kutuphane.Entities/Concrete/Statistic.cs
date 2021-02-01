using System;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Statistic : IEntity
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberID { get; set; }
        public int PersonalId { get; set; }
        public DateTime DateofPurchase { get; set; }
        public DateTime DateofReturn { get; set; }
    }
}