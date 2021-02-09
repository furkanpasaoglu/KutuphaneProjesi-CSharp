using System;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.DTOs
{
    public class StatisticDetailDto : IDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string BookName { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public int PersonalId { get; set; }
        public string PersonalName { get; set; }
        public DateTime? MemberDate { get; set; }
        public DateTime DateofPurchase { get; set; }
        public DateTime DateofReturn { get; set; }
        public bool Status { get; set; }
    }
}