using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Auto: Vehiculo
    {
        protected int CantidadDePuertas {  get; set; }
        public Auto(string placa, string marca, string modelo, string color, TimeOnly horaDeEntrada, int cantidadDePuertas)
            :base(placa, marca, modelo, color, horaDeEntrada)
        {
            CantidadDePuertas = cantidadDePuertas;
        }

        public override void MostrarVehiculos()
        {
            base.MostrarVehiculos();
            Console.WriteLine($"Cantidad de puertas: {CantidadDePuertas}");
        }
    }
}
