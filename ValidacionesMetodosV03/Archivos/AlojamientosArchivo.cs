using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionesMetodosV03.Entidades;
using Newtonsoft.Json;

namespace ValidacionesMetodosV03.Archivos
{
    internal static class AlojamientosArchivo
    {

        static List<Alojamiento> todos;

        static AlojamientosArchivo()
        {
            //si existe el archivo...
            //if (File.Exists("Alojamiento.json"))
            if (File.Exists("C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Alojamiento.json"))
            {
                //lee TODO el contenido del archivo.
                //string contenidoDelArchivo = File.ReadAllText("Alojamiento.json");
                string contenidoDelArchivo = File.ReadAllText("C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Alojamiento.json");

                //esta linea convierte el texto
                //de vuelta a objetos de tipo PersonaEnt;

                todos = JsonConvert.DeserializeObject<List<Alojamiento>>(contenidoDelArchivo);
            }
            else
            {
                todos = new List<Alojamiento>();
            }
        }

        //Estilo 1: este modulo devuelve una lista de todos los alojamientos
        //y el resto del sistema trabaja con eso.
        public static List<Alojamiento> ObtenerTodas()
        {
            return todos.ToList();
        }

    }
}
