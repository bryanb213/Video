using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Video.Models;

namespace Video.ViewModels
{
    public class NewCustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypesss { get; set; }
        public Customer Customer { get; set; }
    }
}
