using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Specifications.UserSpec
{
    public class UserSpecParams : BaseSpecParams
    {
        public String? UserName { get; set; }
        public String? Role {  get; set; }
    }
}
