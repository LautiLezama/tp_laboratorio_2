using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using System.Xml.Serialization;

namespace Entidades
{
    public delegate void encargadoTiempo();
    public class Tienda
    {
        private string nombre;
        private string direccion;
        private int horarioInicio;
        private int horarioFin;
        [field: NonSerialized]
        private List<Prenda> prendas;
        public event encargadoTiempo EventoTiempo;
        private int horasAbierto;

        #region Constructores
        /// <summary>
        /// Constructor sin parametros para poder serializar el objeto.
        /// </summary>
        public Tienda()
        {

        }

        public Tienda(string nombre, string direccion, int horarioInicio, int horarioFin)
        {
            this.nombre = nombre;
            this.direccion = direccion;
            this.horarioFin = horarioFin;
            this.horarioInicio = horarioInicio;
            this.prendas = new List<Prenda>();
            this.horasAbierto = this.horarioInicio.HorasAbierto(this.horarioFin);
        }
        #endregion

        #region Propiedades
        public int HorasAbierto
        {
            get
            {
                return this.horasAbierto;
            }
            set
            {
                this.horasAbierto = value;
            }
        }


        public List<Prenda> Prendas
        {
            get
            {
                return this.prendas;
            }
            set
            {
                this.prendas = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }

        public string Direccion
        {
            get
            {
                return this.direccion;
            }
            set
            {
                this.direccion = value;
            }
        }

        public int HorarioInicio
        {
            get
            {
                return this.horarioInicio;
            }
            set
            {
                this.horarioInicio = value;
            }
        }

        public int HorarioFin
        {
            get
            {
                return this.horarioFin;
            }
            set
            {
                this.horarioFin = value;
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Escoge una prenda aleatoria de las que haya en la tienda, la guarda como una venta en un archivo txt y retorna un mensaje demostrando que se concreto la venta.
        /// </summary>
        /// <returns>Informacion del producto vendido</returns>
        public string VenderPrenda()
        {
            Texto texto = new Texto();
            Random random = new Random();
            Prenda prendaVendida;
            int indexPrenda = random.Next(0, this.prendas.Count);
            prendaVendida = this.prendas[indexPrenda];
            string mensajeRetorno = $"Se ha vendido un/a {prendaVendida.MostrarInfoVenta()}";
            texto.Guardar(mensajeRetorno, "Ventas.txt");
            return mensajeRetorno;
        }
        /// <summary>
        /// (Aqui se aplica Eventos)Mientras que la tienda siga abierta, invocara cada 1 segundo al evento EventoTiempo.
        /// </summary>
        public void Vendiendo()
        {

            while (this.horasAbierto >= 0)
            {
                this.EventoTiempo.Invoke();
                Thread.Sleep(1000);
            }

        }

        /// <summary>
        /// Simulacion de Venta para el proyecto TEST de la Consola. (El original se encuentra en FrmTienda)
        /// </summary>
        public void SimulacionDePrueba()
        {
            if (this.horasAbierto == 0)
            {
                return;
            }
            Console.WriteLine(this.VenderPrenda());
            this.HorasAbierto -= 1;
        }
        #endregion

        #region Operadores
        /// <summary>
        /// (Aqui se aplica Excepciones)Sobrecarga del operador + que, en caso de no estar ya incluida, agrega una prenda a la tienda.
        /// </summary>
        /// <param name="t">Tienda</param>
        /// <param name="p">Prenda a agregar</param>
        /// <returns>Retorna la tienda que se pasó por parametro</returns>
        public static Tienda operator +(Tienda t, Prenda p)
        {
            if(t != p)
            {
                t.prendas.Add(p);
                return t;
            }
            else
            {
                throw new TiendaException("Esta prenda ya se encuentra en la tienda.");
            }
        }
        /// <summary>
        /// Sobrecarga del operador - que elimina una prenda de la tienda, solamente en caso de estar en la misma.
        /// </summary>
        /// <param name="t">Tienda</param>
        /// <param name="codigo">Codigo de la prenda a eliminar</param>
        /// <returns>True en caso de eliminarlo correctamente, caso contrario false</returns>
        public static bool operator -(Tienda t, int codigo)
        {
            foreach (Prenda p in t.Prendas)
            {
                if (p.Codigo == codigo)
                {
                    t.Prendas.Remove(p);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador == que compara si una prenda se encuentra ya dentro de la tienda.
        /// </summary>
        /// <param name="t">Tienda</param>
        /// <param name="p">Prenda a validar</param>
        /// <returns>True en caso de estar en la tienda, caso contrario false</returns>
        public static bool operator ==(Tienda t, Prenda p)
        {
            foreach(Prenda prenda in t.prendas)
            {
                if(prenda.Codigo == p.Codigo)
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Sobrecarga del operador != que compara si una prenda no se encuentra dentro de la tienda.
        /// </summary>
        /// <param name="t">Tienda</param>
        /// <param name="p">Prenda a validar</param>
        /// <returns>True en caso de no estar en la tienda, caso contrario false</returns>
        public static bool operator !=(Tienda t, Prenda p)
        {
            return !(t == p);
        }
        #endregion

    }
}
