using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserVoucher : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid VoucherId { get; set; }
        public int Quantity { get; set; }

        // Navigation Properties
        public User User { get; set; } = null!;
        public Voucher Voucher { get; set; } = null!;
    }
}