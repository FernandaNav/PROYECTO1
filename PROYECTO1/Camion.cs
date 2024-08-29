using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Camion:Vehiculo
    {
        public decimal CapacidadDeCarga {  get; set; }
        public Camion(string placa, string marca, string modelo, string color, TimeOnly horaDeEntrada, decimal capacidadDeCarga)
            :base (placa, marca, modelo, color, horaDeEntrada)
        {
            CapacidadDeCarga = capacidadDeCarga;
        }
        public override void MostrarVehiculos()
        {
            base.MostrarVehiculos();
            Console.WriteLine($"Capacidad de carga: {CapacidadDeCarga}");
        }
    }
}
