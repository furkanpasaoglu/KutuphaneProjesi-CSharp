using System;
using Kutuphane.Core.Kutuphane.Entities;

namespace Kutuphane.Entities.Concrete
{
    public class Penaltie : IEntity
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int StatisticsId { get; set; }
        public DateTime DateofStart { get; set; }
        public DateTime DateofEnd { get; set; }
        public decimal Money { get; set; }
    }
}