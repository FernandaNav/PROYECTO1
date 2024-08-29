using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Vehiculo
    {
        public string Placa {  get; set; }
        protected string Marca {  get; set; }
        protected string Modelo { get; set; }
        protected string Color { get; set; }
        public TimeOnly HoraDeEntrada { get; set; }

        public Vehiculo(string placa, string marca, string modelo, string color, TimeOnly horaDeEntrada)
        {
            Placa = placa;
            Marca = marca;
            Modelo = modelo;
            Color = color;
            HoraDeEntrada = horaDeEntrada;
        }

        public virtual void MostrarVehiculos()
        {
            Console.WriteLine($"Placa: {Placa}");
            Console.WriteLine($"Marca: {Marca}");
            Console.WriteLine($"Modelo: {Modelo}");
            Console.WriteLine($"Color: {Color}");
            Console.WriteLine($"Hora de entrada: {HoraDeEntrada}");
        }
    }
}
