﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Motocicleta: Vehiculo
    {
        private bool SideCar {  get; set; }

        public Motocicleta(string placa, string marca, string modelo, string color, DateTime horaDeEntrada, bool sideCar) 
            :  base(placa, marca, modelo, color, horaDeEntrada)
        {
            SideCar = sideCar;
        }
        public override void MostrarVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Tipo de vehículo: motocicleta"); Console.ResetColor();
            base.MostrarVehiculos();
            if (SideCar==true)
            {
                Console.WriteLine("¿Tiene sidecar?: Si");
            }
            else
            {
                Console.WriteLine("¿Tiene sidecar?: No");
            }
        }
    }
}
