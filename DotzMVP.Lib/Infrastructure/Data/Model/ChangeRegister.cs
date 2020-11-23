using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class ChangeRegister: ModelBase
    {
        public StatusChange Status { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public List<ChangeRegisterItem> Itens { get; set; }
    }

    public enum StatusChange 
    {
        Waiting,
        Approved,
        Rejected,
    }

}
