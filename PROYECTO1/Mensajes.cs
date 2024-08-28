using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROYECTO1
{
    public class Mensajes
    {
        public void Continuar()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Presiona ENTER para continuar...");
            Console.ResetColor(); Console.ReadKey(); Console.Clear();
        }
        public void ErrorDeFormato()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Error de formato. Intenta de nuevo.");
            Console.ResetColor();
        }
        public void Default()
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine("Esta opción no existe"); Console.ResetColor();
            Continuar();
        }
    }
}
