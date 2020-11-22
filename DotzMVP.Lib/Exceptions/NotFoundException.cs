using System;
using System.Collections.Generic;
using System.Text;

namespace DotzMVP.Lib.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string mensagem) : base(mensagem) { }
    }
}
