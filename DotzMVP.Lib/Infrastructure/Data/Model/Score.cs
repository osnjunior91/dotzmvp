﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Infrastructure.Data.Model
{
    public class Score: ModelBase
    {
        public double Amount { get; set; }
        public Guid PersonID { get; set; }
        public Person Person { get; set; }
        public Guid CustomerID { get; set; }
        public Customer Customer { get; set; }
    }
}
