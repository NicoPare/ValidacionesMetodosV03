using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidacionesMetodosV03.Entidades;

namespace ValidacionesMetodosV03.Modulos
{
    public class ModuloPresupuesto
    {
        public void GuardarPresupuesto(List<dynamic> alojamientosSeleccionados, List<dynamic> vuelosSeleccionados)
        {
            // Generar un código único para identificar el presupuesto
            string codPresupuesto = Guid.NewGuid().ToString();

            // Crear una instancia del objeto Presupuesto con la selección del usuario
            Presupuesto presupuesto = new Presupuesto
            {
                CodPresupuesto = codPresupuesto,
                AlojamientosSeleccionados = alojamientosSeleccionados,
                VuelosSeleccionados = vuelosSeleccionados
            };

            // Leer el contenido actual del archivo JSON
            //string jsonFilePath = "Presupuestos.json"; // Ruta del archivo JSON
            string jsonFilePath = "C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Presupuestos.json";
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserializar el contenido JSON a una lista de objetos Presupuesto (si existe)
            List<Presupuesto> presupuestos = JsonConvert.DeserializeObject<List<Presupuesto>>(jsonContent) ?? new List<Presupuesto>();

            // Agregar el nuevo presupuesto a la lista
            presupuestos.Add(presupuesto);

            // Serializar la lista de presupuestos a formato JSON
            string updatedJsonContent = JsonConvert.SerializeObject(presupuestos, Formatting.Indented);

            // Guardar el contenido actualizado en el archivo JSON
            File.WriteAllText(jsonFilePath, updatedJsonContent);
        }

        /*
         Finalmente, desde donde necesites invocar el método "GuardarPresupuesto", llama al método pasando las listas de selecciones de alojamientos y vuelos:
         */
        // Llamada al método GuardarPresupuesto
        //List<dynamic> alojamientosSeleccionados = ConsultarAlojamiento(destino, fechaIngreso, fechaEgreso, cantidadAdultos, cantidadMenores, cantidadInfantes, calificacion);
        //List<dynamic> vuelosSeleccionados = ConsultarVuelos(origen, destino, fechaIda, fechaVuelta, cantidadAdultos, cantidadMenores, cantidadInfantes);
        //GuardarPresupuesto(alojamientosSeleccionados, vuelosSeleccionados);
    }
}
