using PROYECTO1;

int opcion = 0;
Mensajes mensaje = new Mensajes();
Estacionamiento estacionamiento = new Estacionamiento();
do
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.WriteLine("--------------------------------------------");
    Console.WriteLine("              EASY PARKING");
    Console.WriteLine("--------------------------------------------\n"); Console.ResetColor();
    Console.WriteLine("1. Registrar vehículo");
    Console.WriteLine("2. Retirar vehículo");
    Console.WriteLine("3. Visualizar vehículos estacionados");
    Console.WriteLine("4. Visualización de espacios disponibles");
    Console.WriteLine("5. Salir\n");
    Console.ForegroundColor= ConsoleColor.DarkYellow;
    Console.Write("Ingrese la opcion que quieras: ");
    try
    {
        opcion = Convert.ToInt32(Console.ReadLine()); Console.ResetColor();
        switch (opcion)
        {
            case 1:
                estacionamiento.IngresarVehiculo();
                break;
            case 2:
                estacionamiento.RetirarVehiculo();
                break;
            case 3:
                estacionamiento.VisualizarVehiculos();
                break;
            case 4:
                estacionamiento.EspaciosDisponibles();
                break;
            case 5:
                estacionamiento.Salida();
                break;
            default:
                mensaje.Default();
                mensaje.Continuar();
                break;
        }
    }
    catch (FormatException)
    {
        mensaje.ErrorDeFormato();
        mensaje.Continuar();
    }
} while(opcion != 5);
