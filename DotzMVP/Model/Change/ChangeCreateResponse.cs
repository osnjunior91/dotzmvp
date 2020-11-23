using DotzMVP.Lib.Infrastructure.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Change
{
    public class ChangeCreateResponse
    {
        public Guid ID { get; set; }
        public Guid UserID { get; set; }
        public StatusChange Status { get; set; }
    }
}
