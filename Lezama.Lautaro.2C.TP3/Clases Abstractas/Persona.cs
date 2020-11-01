using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using Excepciones;

namespace Clases_Abstractas
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        private ENacionalidad nacionalidad;
        private int dni;
        public enum ENacionalidad { Argentino, Extranjero }

        #region Constructores
        public Persona()
        {
        }

        public Persona(string nombre, string apellido, ENacionalidad nacionalidad)
            : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Nacionalidad = nacionalidad;
        }

        public Persona(string nombre, string apellido, int dni, ENacionalidad nacionalidad)
        {
            try
            {
                this.DNI = dni;
            }
            catch(NacionalidadInvalidaException ex)
            {
                throw ex;
            }
            
        }

        public Persona(string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : this(nombre, apellido, nacionalidad)
        {
            try
            {
                this.StringToDNI = dni;
            }
            catch(DniInvalidoException ex)
            {
                throw ex;
            }
        }
        #endregion

        #region Propiedades
        /// <summary>
        /// Propiedad de lectura y escritura del atributo nombre.
        /// </summary>
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo apellido.
        /// </summary>
        public string Apellido
        {
            get
            {
                return this.apellido;
            }
            set
            {
                this.apellido = ValidarNombreApellido(value);
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo dni.
        /// </summary>
        public int DNI
        {
            get
            {
                return this.dni;
            }
            set
            {
                try
                {
                    this.dni = ValidarDni(this.nacionalidad, value);

                }
                catch (NacionalidadInvalidaException ex)
                {
                    throw ex;
                }
            }
        }
        /// <summary>
        /// Propiedad de lectura y escritura del atributo nacionalidad.
        /// </summary>
        public ENacionalidad Nacionalidad
        {
            get
            {
                return this.nacionalidad;
            }
            set
            {
                this.nacionalidad = value;
            }
        }

        /// <summary>
        /// Propiedad de escritura que convierte un dni en formato string a int para asignarlo al objeto instanciado.
        /// </summary>
        public string StringToDNI
        {
            set
            {
                try
                {
                    this.DNI = ValidarDni(this.nacionalidad, value);
                }
                catch (DniInvalidoException ex)
                {
                    throw ex;
                }
            }
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Muestra los datos de la Persona.
        /// </summary>
        /// <returns>Datos de la Persona</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"NOMBRE COMPLETO: {this.nombre} {this.apellido}");
            sb.AppendLine($"NACIONALIDAD: {this.nacionalidad}");
            return sb.ToString();
        }
        /// <summary>
        /// Valida que el DNI sea correcto en relación a la nacionalidad.
        /// </summary>
        /// <param name="nacionalidad">el atributo nacionalidad</param>
        /// <param name="dato">el dni a validar</param>
        /// <returns>En caso de ser correcto, el dni. Caso contrario una excepción de tipo NacionalidadInvalidaException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, int dato)
        {
            if (nacionalidad == ENacionalidad.Argentino)
            {
                if (dato >= 1 && dato < 90000000)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
                }
            }
            else
            {
                if (dato >= 90000000 && dato < 100000000)
                {
                    return dato;
                }
                else
                {
                    throw new NacionalidadInvalidaException("La nacionalidad no se condice con el numero de DNI.");
                }
            }
        }
        /// <summary>
        /// Valida que el DNI cumpla con el formato de un dni(cantidad de numeros y que sean números)
        /// </summary>
        /// <param name="nacionalidad">atributo nacionalidad</param>
        /// <param name="dato">el dni a validar</param>
        /// <returns>En caso de ser correcto, el dni, caso contrario una excepcion de tipo DniInvalidoException</returns>
        private int ValidarDni(ENacionalidad nacionalidad, string dato)
        {
            int dni;
            if (dato.Length < 1 || dato.Length > 8)
            {
                throw new DniInvalidoException("El DNI no contiene los digitos necesarios.");
            }

            foreach (char c in dato)
            {
                if (!char.IsDigit(c))
                {
                    throw new DniInvalidoException("El DNI solo debe estar compuesto por números.");
                }
            }

            int.TryParse(dato, out dni);
            return dni;

        }
        /// <summary>
        /// Valida que el nombre y/o apellido contengan solo letras.
        /// </summary>
        /// <param name="dato">Nombre o apellido a validar.</param>
        /// <returns>Caso de ser correcto, el dato a validar, caso contrario un string vacio.</returns>
        private string ValidarNombreApellido(string dato)
        {
            foreach (char c in dato)
            {
                if (!char.IsLetter(c))
                {
                    return string.Empty;
                }
            }
            return dato;
        }
        #endregion
    }
}
