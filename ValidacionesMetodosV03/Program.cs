// See https://aka.ms/new-console-template for more information
using ValidacionesMetodosV03.Entidades;
using ValidacionesMetodosV03.Modulos;

namespace ValidacionesMetodosV03
{
    internal static class Program
    {
        static void Main()
        {
            Console.WriteLine("Hello, World!");

            // CARGO DATOS EN Productos.json
            ModuloProductos moduloProductos = new ModuloProductos();

            moduloProductos.ProcesarVuelosYAlojamientos();

            // prueba del método ConsultarVuelos()

            // Parámetros de búsqueda de vuelos
            string origen = "EZE";
            string destino = "LHR";
            DateTime fechaIda = DateTime.Parse("2023-06-01");
            DateTime? fechaVuelta = DateTime.Parse("2023-07-01");
            //fechaVuelta;
            int cantidadAdultos = 1;
            int cantidadMenores = 1;
            int cantidadInfantes = 0;

            // Consultar vuelos disponibles
            var vuelosDisponibles = moduloProductos.ConsultarVuelos(origen, destino, fechaIda, fechaVuelta, cantidadAdultos, cantidadMenores, cantidadInfantes);

            // Mostrar los vuelos encontrados
            foreach (var vuelo in vuelosDisponibles)
            {
                //Console.WriteLine("Código de vuelo: " + vuelo.CodVuelo);
                Console.WriteLine("Origen: " + vuelo.Origen);
                Console.WriteLine("Destino: " + vuelo.Destino);
                Console.WriteLine("Aerolínea: " + vuelo.Aerolinea);
                Console.WriteLine("Fecha y hora de salida: " + vuelo.FechaHoraSalida);
                Console.WriteLine("Fecha y hora de arribo: " + vuelo.FechaHoraArribo);
                //Console.WriteLine("Tarifa: " + vuelo.Tarifa.Precio);
                //Console.WriteLine("Tiempo de vuelo: " + vuelo.TiempoDeVuelo);
                Console.WriteLine("-------------------------------------");
                foreach (var tarifa in vuelo.Tarifas)
                {
                    Console.WriteLine("Precio: " + tarifa.Precio);
                    Console.WriteLine("Clase de vuelo: " + tarifa.ClaseVuelo);
                    Console.WriteLine("Clase de vuelo: " + tarifa.TipoPasajero);
                }

            }

            //Consulto alojamientos disponibles


            // Parámetros de búsqueda Alojamiento
            string destinoAl = "BSA";
            DateTime fechaIngreso = DateTime.Parse("2023-06-01");
            DateTime fechaEgreso = DateTime.Parse("2023-06-03");
            int cantidadAdultosAl = 1;
            int cantidadMenoresAl = 1;
            int cantidadInfantesAl = 0;
            int calificacion = 2;

            List<dynamic> alojamientosDisponibles = moduloProductos.ConsultarAlojamiento(destinoAl, fechaIngreso, fechaEgreso, cantidadAdultosAl, cantidadMenoresAl, cantidadInfantesAl, calificacion);

            Console.WriteLine("Alojamientos disponibles:");

            foreach (var alojamiento in alojamientosDisponibles)
            {
                Console.WriteLine($"Ciudad: {alojamiento.CodCiudad}");
                Console.WriteLine($"Fecha de ingreso: {alojamiento.FechaIngreso}");
                Console.WriteLine($"Fecha de salida: {alojamiento.FechaSalida}");
                Console.WriteLine($"Nombre del alojamiento: {alojamiento.NombreAlojamiento}");
                Console.WriteLine($"Tarifa: {alojamiento.Tarifa}");
                Console.WriteLine($"Nombre de la habitación: {alojamiento.NombreHabitacion}");
                Console.WriteLine($"Calificación: {alojamiento.Calificacion}");
                Console.WriteLine();

                //foreach()
            }

        }
    }
}
