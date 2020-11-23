using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Threading;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //Creo la tienda
            Tienda tienda = new Tienda("Tienda de Consola", "Adolfo Alsina 2303", 10, 13);
            //Suscripcion del metodo de prueba al evento.
            tienda.EventoTiempo += tienda.SimulacionDePrueba;
            //Creo productos para la tienda.
            Remera r1 = new Remera(4, 129.99f, Prenda.EColor.Naranja, Remera.EManga.Manga_corta);
            Remera r2 = new Remera(2, 100, Prenda.EColor.Negro, Remera.EManga.Manga_larga);
            Pantalon p1 = new Pantalon(3, 219.99f, Prenda.EColor.Rosa, Pantalon.EPantalon.Short);
            Pantalon p2 = new Pantalon(1, 150, Prenda.EColor.Rojo, Pantalon.EPantalon.Skinny);
            //Agregar productos a la lista de prendas
            tienda += r1;
            tienda += r2;
            tienda += p1;
            tienda += p2;
            Console.WriteLine("Toque alguna tecla para iniciar la simulacion.");
            Console.ReadKey();
            //Simulacion de la tienda abierta: Apareceran productos segun la cantidad de horas abierto el local, 1 por hora.(Se ejecuta 1 por segundo).
            Thread hilo = new Thread(new ThreadStart(tienda.Vendiendo));
            hilo.Start();
            Thread.Sleep(tienda.HorasAbierto * 1000); //Fuerzo a terminarlo despues de este tiempo solo para el testo en Consola.
            if(hilo != null && hilo.IsAlive)
            {
                hilo.Abort();
            }
            //Serializado a XML de la tienda, se guardara en el escritorio.
            Xml<Tienda> xml = new Xml<Tienda>();
            xml.Guardar(tienda, "TiendaConsola.xml");
            Console.WriteLine("Toque alguna tecla para leer todas las ventas guardadas en TXT");
            Console.ReadKey();
            //Leer todas las ventas guardadas en txt(Ya sean de Form o Consola)
            Texto texto = new Texto();
            Console.Clear();
            Console.WriteLine(texto.Leer("Ventas.txt"));
            Console.ReadKey();
        }

    }
}
