using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Pago
    {
        public virtual bool ProcesarPago(decimal monto, TimeOnly horaEntrada, TimeOnly horaSalida)
        {
            return true;
        }
    }
}
