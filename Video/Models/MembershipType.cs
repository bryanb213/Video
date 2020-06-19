using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Video.Models
{
    public class MembershipType
    {
        public int Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonth { get; set; }
        public byte DiscountRate { get; set; }

    }
}
