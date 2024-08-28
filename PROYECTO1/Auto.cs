﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Auto: Vehiculo
    {
        public int CantidadDePuertas {  get; set; }
        public Auto(string placa, string marca, string modelo, string color, DateTime horaDeEntrada, int cantidadDePuertas)
            :base(placa, marca, modelo, color, horaDeEntrada)
        {
            CantidadDePuertas = cantidadDePuertas;
        }

        public override void MostrarVehiculos()
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("Tipo de Vehículo: Auto"); Console.ResetColor();
            base.MostrarVehiculos();
            Console.WriteLine($"Cantidad de puertas: {CantidadDePuertas}");
        }
    }
}
