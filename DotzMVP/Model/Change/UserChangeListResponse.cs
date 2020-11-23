using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Change
{
    public class UserChangeListResponse
    {
        public Guid ID { get; set; }
        public StatusChange Status { get; set; }
        public Double Amount { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
