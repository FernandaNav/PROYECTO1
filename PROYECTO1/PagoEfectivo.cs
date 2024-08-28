using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class PagoEfectivo:Pago
    {
        public override bool ProcesarPago(decimal monto)
        {
            return true;
        }
    }
}
