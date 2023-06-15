using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidacionesMetodosV03.Modulos
{
    internal class Validaciones
    {
        public static bool ValidarCiudad(string ciudad)
        {
            try
            {
                // Verificar si la ciudad está vacía
                if (string.IsNullOrWhiteSpace(ciudad))
                {
                    Console.WriteLine("Error: La ciudad no puede estar vacía.");
                    return false;
                }

                // Verificar si la ciudad contiene números o caracteres especiales, excepto espacios en blanco
                if (ciudad.Any(c => !char.IsLetter(c) && !char.IsWhiteSpace(c)))
                {
                    Console.WriteLine("Error: La ciudad solo puede contener letras y espacios en blanco.");
                    return false;
                }

                // Cargar los datos del archivo Ciudades.json
                string ciudadesJson = File.ReadAllText("Ciudades.json");

                // Deserializar el archivo JSON a una lista de ciudades
                var ciudades = JsonConvert.DeserializeObject<string[]>(ciudadesJson);

                // Verificar si la ciudad existe en la lista de ciudades
                return ciudades.Any(c => c.Equals(ciudad, StringComparison.OrdinalIgnoreCase));
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: No se encontró el archivo Ciudades.json.");
            }
            catch (JsonReaderException)
            {
                Console.WriteLine("Error: El archivo Ciudades.json tiene un formato JSON inválido.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            return false;
        }
        public static bool ValidarFecha(string fecha)
        {
            DateTime fechaActual = DateTime.Now;

            // Verificar si la fecha es mayor o igual a la fecha actual
            if (!DateTime.TryParse(fecha, out DateTime fechaIngresada) || fechaIngresada < fechaActual.Date)
            {
                Console.WriteLine("Error: La fecha debe ser igual o mayor a la fecha actual.");
                return false;
            }

            return true;
        }

        public static bool ValidarFechas(string fechaInicio, string fechaFin)
        {
            // Verificar si las fechas son válidas
            if (!DateTime.TryParse(fechaInicio, out DateTime fechaInicioIngresada) ||
                !DateTime.TryParse(fechaFin, out DateTime fechaFinIngresada))
            {
                Console.WriteLine("Error: Las fechas ingresadas son inválidas.");
                return false;
            }

            // Verificar si la fecha de fin es mayor a la fecha de inicio
            if (fechaFinIngresada <= fechaInicioIngresada)
            {
                Console.WriteLine("Error: La fecha de fin debe ser mayor a la fecha de inicio.");
                return false;
            }

            return true;
        }

        public static bool ValidarCantidadPasajerosAdultos(int cantidad)
        {
            // Verificar si la cantidad de pasajeros adultos es mayor a 0
            if (cantidad <= 0)
            {
                Console.WriteLine("Error: La cantidad de pasajeros adultos debe ser mayor a 0.");
                return false;
            }

            return true;
        }
        public static bool ValidarCalificacion(int calificacion)
        {
            // Verificar si la calificación está dentro del rango válido (1-5)
            if (calificacion < 1 || calificacion > 5)
            {
                Console.WriteLine("Error: La calificación debe estar entre 1 y 5.");
                return false;
            }

            return true;
        }
        public static bool ValidarNombreApellido(string nombre, string apellido)
        {
            // Verificar si el nombre y/o apellido están vacíos o contienen valores numéricos
            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) ||
                nombre.Any(char.IsDigit) || apellido.Any(char.IsDigit))
            {
                Console.WriteLine("Error: No ha ingresado correctamente los datos solicitados. Por favor, vuelva a intentarlo.");
                return false;
            }

            return true;
        }

        public static bool ValidarPais(string pais)
        {
            // Cargar los datos del archivo Paises.json
            string paisesJson = File.ReadAllText("Paises.json");

            // Deserializar el archivo JSON a una lista de países
            var paises = JsonConvert.DeserializeObject<string[]>(paisesJson);

            // Verificar si el país está en la lista de países
            if (!paises.Any(p => p.Equals(pais, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine("Error: País no encontrado, por favor, revise la ortografía del país ingresado.");
                return false;
            }

            return true;
        }

        public static bool ValidarTipoDocumento(string tipoDocumento)
        {
            // Cargar los tipos de documentos permitidos desde algún origen de datos
            var tiposDocumentoPermitidos = new List<string> { "DNI", "Pasaporte", "Cédula" };

            // Verificar si el tipo de documento está en la lista de tipos permitidos
            if (!tiposDocumentoPermitidos.Contains(tipoDocumento, StringComparer.OrdinalIgnoreCase))
            {
                Console.WriteLine("Error: Tipo de documento inválido, por favor, revise la ortografía.");
                return false;
            }

            return true;
        }

        public static bool ValidarDocumento(string documento)
        {
            // Verificar si el documento contiene caracteres especiales o es un valor en formato string
            if (documento.Any(c => !char.IsDigit(c)) || int.TryParse(documento, out _))
            {
                Console.WriteLine("Error: Documento ingresado inválido, por favor, vuelva a ingresar.");
                return false;
            }

            return true;
        }

        public static bool ValidarFechaNacimiento(string fechaNacimiento)
        {
            DateTime fechaActual = DateTime.Now;

            // Verificar si la fecha de nacimiento es mayor a la fecha actual
            if (!DateTime.TryParse(fechaNacimiento, out DateTime fechaNacimientoIngresada) || fechaNacimientoIngresada > fechaActual)
            {
                Console.WriteLine("Error: Su fecha de nacimiento ingresada es posterior al día de la fecha. Por favor, ingrese nuevamente su fecha de nacimiento.");
                return false;
            }

            return true;
        }
    }
}
