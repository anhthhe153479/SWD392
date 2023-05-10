using System;
using System.Collections.Generic;

namespace SWD392.Models.Models
{
    public partial class Recharge
    {
        public int RechargeId { get; set; }
        public int UserId { get; set; }
        public DateTime? RechargeDate { get; set; }
        public int? Amount { get; set; }
        public int Status { get; set; }
        public string Method { get; set; } = null!;
        public string? Content { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
