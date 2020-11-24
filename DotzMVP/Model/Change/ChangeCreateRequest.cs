using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotzMVP.Model.Change
{
    public class ChangeCreateRequest
    {
        public List<ChangeCreateRequestItem> Itens { get; set; }
    }

    public class ChangeCreateRequestItem
    {
        public Guid ProductID { get; set; }
        public int Amount { get; set; }

    }
}
