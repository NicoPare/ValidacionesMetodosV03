﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using ValidacionesMetodosV03.Archivos;
using ValidacionesMetodosV03.Entidades;


namespace ValidacionesMetodosV03.Modulos
{
    public class ModuloProductos
    {
        /*public void ProcesarVuelos()
        {
            // Leer los vuelos desde el archivo JSON            
            List<Vuelo> vuelos = VuelosArchivo.ObtenerTodas();
            // Crear una lista de productos
            List<Producto> productos = new List<Producto>();
            // Generar un código aleatorio para cada producto y deserializar los vuelos en productos
            foreach (Vuelo vuelo in vuelos)
            {
                string codigoProducto = GenerarCodigoAleatorio();
                Producto producto = new Producto(codigoProducto, vuelo, null);
                productos.Add(producto);
            }
            // Guardar los productos en un nuevo archivo JSON
            GuardarProductosEnArchivo(productos);        
        }
        public void ProcesarAlojamientos()
        {
            // Leer los alojamientos desde el archivo JSON
            List<Alojamiento> alojamientos = AlojamientosArchivo.ObtenerTodas();
            // Crear una lista de productos
            List<Producto> productos = new List<Producto>();
            // Generar un código aleatorio para cada producto y deserializar los alojamientos en productos
            foreach (Alojamiento alojamiento in alojamientos)
            {
                string codigoProducto = GenerarCodigoAleatorio();
                Producto producto = new Producto(codigoProducto, null, alojamiento);
                productos.Add(producto);
            }
            // Guardar los productos en un nuevo archivo JSON
            GuardarProductosEnArchivo(productos);
        }
        public void ProcesarProductos()
        {
            ProcesarVuelos();
            ProcesarAlojamientos();
        }*/

        public void ProcesarVuelosYAlojamientos()
        {
            // Leer los vuelos desde el archivo JSON
            List<Vuelo> vuelos = VuelosArchivo.ObtenerTodas();

            // Leer los alojamientos desde el archivo JSON
            List<Alojamiento> alojamientos = AlojamientosArchivo.ObtenerTodas();

            // Procesar los vuelos y obtener los productos correspondientes
            List<Producto> productos = new List<Producto>();

            foreach (Vuelo vuelo in vuelos)
            {
                string codigoProducto = GenerarCodigoAleatorio();
                Producto producto = new Producto(codigoProducto, vuelo, null);
                productos.Add(producto);
            }

            // Procesar los alojamientos y obtener los productos correspondientes
            foreach (Alojamiento alojamiento in alojamientos)
            {
                string codigoProducto = GenerarCodigoAleatorio();
                Producto producto = new Producto(codigoProducto, null, alojamiento);
                productos.Add(producto);
            }

            // Guardar los productos en el archivo JSON
            GuardarProductosEnArchivo(productos);
        }


        private void GuardarProductosEnArchivo(List<Producto> productos)
        {
            // Serializar los productos en formato JSON
            string productosJson = JsonConvert.SerializeObject(productos, Newtonsoft.Json.Formatting.Indented);

            // Guardar los productos en el archivo JSON
            //File.WriteAllText("Productos.json", productosJson);
            File.WriteAllText("C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Productos.json", productosJson);
        }

        public static string GenerarCodigoAleatorio()
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }


        // CONSULTAS DE DATOS

        private List<Producto> productos;

        public ModuloProductos()
        {
            productos = new List<Producto>();
        }

        // Consulta de vuelos
        /*
        public List<Vuelo> ConsultarVuelos(string origen, string destino, DateTime fechaIda, DateTime? fechaVuelta, int cantidadAdultos, int cantidadMenores, int cantidadInfantes)
        {
            List<Vuelo> vuelosDisponibles = new List<Vuelo>();
            foreach (Producto producto in productos)
            {
                if (producto.Vuelo != null && producto.Vuelo.Origen == origen && producto.Vuelo.Destino == destino)
                {
                    DateTime fechaHoraSalida = producto.Vuelo.FechaHoraSalida;
                    if (fechaIda.Date == fechaHoraSalida.Date)
                    {
                        if (fechaVuelta == null || fechaVuelta.Value.Date == fechaHoraSalida.Date)
                        {
                            Tarifa tarifaAdulto = producto.Vuelo.Tarifa.Find(t => t.TipoPasajero == "Adulto");
                            Tarifa tarifaMenor = producto.Vuelo.Tarifa.Find(t => t.TipoPasajero == "Menor");
                            Tarifa tarifaInfante = producto.Vuelo.Tarifa.Find(t => t.TipoPasajero == "Infante");
                            if (tarifaAdulto != null && cantidadAdultos <= tarifaAdulto.DisponibilidadVuelo
                                && tarifaMenor != null && cantidadMenores <= tarifaMenor.DisponibilidadVuelo
                                && tarifaInfante != null && cantidadInfantes <= tarifaInfante.DisponibilidadVuelo)
                            {
                                vuelosDisponibles.Add(producto.Vuelo);
                            }
                        }
                    }
                }
            }
            return vuelosDisponibles;
        }*/
        public List<dynamic> ConsultarVuelos(string origen, string destino, DateTime fechaIda, DateTime? fechaVuelta,
        int cantidadAdultos, int cantidadMenores, int cantidadInfantes)
        {

            //string jsonFilePath = "Productos.json"; // Ruta del archivo JSON
            string jsonFilePath = "C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Productos.json";

            // Leer el contenido del archivo JSON
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserializar el contenido JSON a una lista de objetos Producto
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(jsonContent);

            List<dynamic> vuelosDisponibles = new List<dynamic>();



            foreach (Producto producto in productos)
            {
                if (producto.Vuelo != null && producto.Vuelo.Origen == origen && producto.Vuelo.Destino == destino)
                {
                    DateTime fechaHoraSalida = producto.Vuelo.FechaHoraSalida.Date;

                    if (fechaIda.Date == fechaHoraSalida.Date) /*&&
                        (fechaVuelta == null || fechaVuelta.Value.Date == fechaHoraSalida.Date))*/
                    {
                        var vueloSimplificado = new
                        {
                            CodVuelo = producto.Vuelo.CodVuelo,
                            Origen = producto.Vuelo.Origen,
                            Destino = producto.Vuelo.Destino,
                            FechaHoraSalida = producto.Vuelo.FechaHoraSalida,
                            FechaHoraArribo = producto.Vuelo.FechaHoraArribo,
                            Aerolinea = producto.Vuelo.Aerolinea,
                            Tarifas = producto.Vuelo.Tarifa
                            .Where(t => (cantidadMenores == 0 && cantidadInfantes == 0 && t.TipoPasajero == "Adulto") ||
                                        (cantidadMenores > 0 && cantidadInfantes == 0 &&
                                         (t.TipoPasajero == "Adulto" || t.TipoPasajero == "Menor")) ||
                                        (cantidadMenores == 0 && cantidadInfantes > 0 &&
                                         (t.TipoPasajero == "Adulto" || t.TipoPasajero == "Infante")) ||
                                        (cantidadMenores > 0 && cantidadInfantes > 0))
                            .Select(t => new
                        {
                            Precio = t.Precio,
                            ClaseVuelo = t.ClaseVuelo,
                            TipoPasajero = t.TipoPasajero
                            }).ToList()
                        };

                        vuelosDisponibles.Add(vueloSimplificado);
                    }
                }
            }

            return vuelosDisponibles;
        }

        // Consulta de Alojamientos
        /*
        public List<Alojamiento> ConsultarAlojamiento(string destino, DateTime fechaIngreso, DateTime fechaEgreso,
        int cantidadAdultos, int cantidadMenores, int cantidadInfantes, int calificacion)
        {
            string jsonFilePath = "Productos.json"; // Ruta del archivo JSON
            // Leer el contenido del archivo JSON
            string jsonContent = File.ReadAllText(jsonFilePath);
            // Deserializar el contenido JSON a una lista de objetos Alojamiento
            List<Alojamiento> alojamientos = JsonConvert.DeserializeObject<List<Alojamiento>>(jsonContent);
            // Filtrar los alojamientos que coinciden con el destino y la calificación
            List<Alojamiento> alojamientosFiltrados = alojamientos.Where(a =>
                a.CodCiudad == destino && a.Calificacion >= calificacion).ToList();
            // Filtrar las habitaciones disponibles dentro del rango de fechas
            List<Alojamiento> alojamientosDisponibles = new List<Alojamiento>();
            foreach (var alojamiento in alojamientosFiltrados)
            {
                List<HabitacionAlojamiento> habitacionesDisponibles = new List<HabitacionAlojamiento>();
                foreach (var habitacion in alojamiento.HabitacionAlojamiento)
                {
                    bool habitacionDisponible = habitacion.DisponibilidadHabitacion.Any(d =>
                        d.Fecha >= fechaIngreso && d.Fecha <= fechaEgreso && d.CantidadDisponible > 0);
                    if (habitacionDisponible && habitacion.CapacidadAdultos >= cantidadAdultos &&
                        habitacion.CapacidadMenores >= cantidadMenores && habitacion.CapacidadInfantes >= cantidadInfantes)
                    {
                        habitacionesDisponibles.Add(habitacion);
                    }
                }
                if (habitacionesDisponibles.Count > 0)
                {
                    Alojamiento alojamientoDisponible = new Alojamiento
                    {
                        CodHotel = alojamiento.CodHotel,
                        NombreAlojamiento = alojamiento.NombreAlojamiento,
                        CodCiudad = alojamiento.CodCiudad,
                        Direccion = alojamiento.Direccion,
                        Calificacion = alojamiento.Calificacion,
                        HabitacionAlojamiento = habitacionesDisponibles
                    };
                    alojamientosDisponibles.Add(alojamientoDisponible);
                }
            }
            return alojamientosDisponibles;
        }
        */

        public List<dynamic> ConsultarAlojamiento(string destino, DateTime fechaIngreso, DateTime fechaEgreso,
        int cantidadAdultos, int cantidadMenores, int cantidadInfantes, int calificacion)
        {
            //string jsonFilePath = "Productos.json"; // Ruta del archivo JSON
            string jsonFilePath = "C:\\Users\\npare\\source\\repos\\ValidacionesMetodosV03\\ValidacionesMetodosV03\\Datos\\Productos.json";

            // Leer el contenido del archivo JSON
            string jsonContent = File.ReadAllText(jsonFilePath);

            // Deserializar el contenido JSON a una lista de objetos Producto
            List<Producto> productos = JsonConvert.DeserializeObject<List<Producto>>(jsonContent);

            // Filtrar los productos que coinciden con el destino y la calificación
            List<Producto> productosFiltrados = productos.Where(p =>
                p.Alojamiento != null && p.Alojamiento.CodCiudad == destino && p.Alojamiento.Calificacion >= calificacion).ToList();

            // Filtrar las habitaciones disponibles dentro del rango de fechas
            List<dynamic> alojamientosDisponibles = new List<dynamic>();

            foreach (var producto in productosFiltrados)
            {
                foreach (var habitacion in producto.Alojamiento.HabitacionAlojamiento)
                {
                    bool habitacionDisponible = habitacion.DisponibilidadHabitacion.Any(d =>
                        d.Fecha >= fechaIngreso && d.Fecha <= fechaEgreso && d.CantidadDisponible > 0);

                    if (habitacionDisponible && habitacion.CapacidadAdultos >= cantidadAdultos &&
                        habitacion.CapacidadMenores >= cantidadMenores && habitacion.CapacidadInfantes >= cantidadInfantes)
                    {
                        var alojamientoSimplificado = new
                        {
                            CodCiudad = producto.Alojamiento.CodCiudad,
                            FechaIngreso = fechaIngreso,
                            FechaSalida = fechaEgreso,
                            NombreAlojamiento = producto.Alojamiento.NombreAlojamiento,
                            Tarifa = habitacion.Tarifa,
                            NombreHabitacion = habitacion.NombreHabitacion,
                            Calificacion = producto.Alojamiento.Calificacion
                        };

                        alojamientosDisponibles.Add(alojamientoSimplificado);
                    }
                }
            }

            return alojamientosDisponibles;
        }


    }
}
