using System;

namespace Entities.Models
{
    public class SupportMessage
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public string? Message { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
    }
}
