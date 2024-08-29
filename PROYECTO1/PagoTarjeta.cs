using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class PagoTarjeta : Pago
    {
        protected int NumeroDeTarjeta { get; set; }
        protected string NombreTitular { get; set; } 
        protected DateTime FechaVencimiento {  get; set; }
        private int CVV {  get; set; }

        public PagoTarjeta(int numeroDeTarjeta, string nombreTitular, DateTime fechaVencimiento, int cVV)
        {
            NumeroDeTarjeta = numeroDeTarjeta;
            NombreTitular = nombreTitular;
            FechaVencimiento = fechaVencimiento;
            CVV = cVV;
        }

        public override bool ProcesarPago(decimal monto)
        {
            return true;
        }
    }
}
