using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Numero
    {
        private double numero;
		#region Constructores
		/// <summary>
		/// Genera una instancia del tipo Numero con valor "cero".
		/// </summary>
		public Numero()
		{
			this.numero = 0;
		}
		/// <summary>
		/// Inicializa una instancia del tipo Numero ingresando un 'string' dentro se valida que sea un valor correcto.
		/// </summary>
		/// <param name="strNumero"></param>
		public Numero(string strNumero)
			:this()
		{
			SetNumero = strNumero;
		}
		/// <summary>
		/// Inicializa una instancia del tipo Numero ingresando un numero de tipo 'double' sin validar.
		/// </summary>
		/// <param name="numero"></param>
		public Numero(double numero)
			:this(numero.ToString())
		{
			this.numero = numero;
		}
        #endregion
        #region Set y validaciones
        /// <summary>
        /// Propiedad que inicializa un objeto del tipo Numero validando que sea correcto.
        /// </summary>
        public string SetNumero
		{
			set
			{
				numero = ValidarNumero(value);
			}
		}
		/// <summary>
		/// Metodo que valida un dato del tipo 'string' se pueda convertir en un dato del tipo 'double' correcto.
		/// </summary>
		/// <param name="strNumero"></param>
		/// <returns>Retorna el resultado si sale bien, 0 caso contrario</returns>
		private double ValidarNumero(string strNumero)
		{
			double auxNumero;
			if (double.TryParse(strNumero, out auxNumero))
			{
				return auxNumero;
			}
			else
				return 0;
		}
        #endregion
        #region Conversiones
        /// <summary>
        /// Convierte un dato del tipo string a un string en decimal.
        /// </summary>
        /// <param name="numero"></param>
        /// <returns>Retorna el resultado si sale bien y "Valor Inválido" si no puede convertir</returns>
        public string DecimalBinario(string numero)
		{
			if (!double.TryParse(numero, out double auxNumero))
				return "Valor inválido";

			return DecimalBinario(auxNumero);
		}
		/// <summary>
		/// Convierte el atributo numero del tipo double de un objeto de tipo Numero en string binario.
		/// </summary>
		/// <returns>Retorna el resultado convertido o "-1" si no se puede convertir</returns>
		public string DecimalBinario(double numero)	
		{
			int auxNumero = (int)numero;
			if (auxNumero > 0 && auxNumero < 256)
			{
				string resultado = "";
				do
				{
					resultado = (auxNumero % 2) + resultado;
					auxNumero = (int)auxNumero / 2;
				} while (auxNumero > 0);
				return resultado;
			}
			else
				return "Valor inválido";
		}

		/// <summary>
		/// Convierte el atributo numero del tipo string de un objeto de tipo Numero en binario.
		/// </summary>
		/// <returns>Retorna el resultado si sale bien y "Valor Inválido" si no puede convertir</returns>
		public string BinarioDecimal(string numero)
		{

			bool flag = true;
			for (int i = 0; i < numero.Length; i++)
			{
				if (numero[i] != '0' && numero[i] != '1')
				{
					flag = false;
				}
			}

			if (flag)
			{
				double resultado = 0;
				for (int i = 0; i < numero.Length; i++)
				{
					resultado += int.Parse(numero[i].ToString()) * (Math.Pow(2, numero.Length - 1 - i));
				}
				return resultado.ToString();
			}
			else
				return "Valor inválido";
		}
		#endregion
		#region Operadores
		/// <summary>
		/// Metodo estático de sobrecarga del operador 'suma' que suma los atributos numero entre dos objetos del tipo Numero.
		/// </summary>
		/// <param name="numeroUno"></param>
		/// <param name="numeroDos"></param>
		/// <returns>Retorna la suma de los atributos de ambas instancias</returns>
		public static double operator +(Numero numeroUno, Numero numeroDos)
		{
			return numeroUno.numero + numeroDos.numero;
		}
		/// <summary>
		/// Metodo estático de sobrecarga del operador 'resta' que resta los atributos numero entre dos objetos del tipo Numero.
		/// </summary>
		/// <param name="numeroUno"></param>
		/// <param name="numeroDos"></param>
		/// <returns>Retorna la resta de los atributos de ambas instancias</returns>
		public static double operator -(Numero numeroUno, Numero numeroDos)
		{
			return numeroUno.numero - numeroDos.numero;
		}
		/// <summary>
		/// Metodo estático de sobrecarga del operador 'multiplicar' que multiplica los atributos numero entre dos objetos del tipo Numero.
		/// </summary>
		/// <param name="numeroUno"></param>
		/// <param name="numeroDos"></param>
		/// <returns>Retorna la multiplicacion de los atributos de ambas instancias</returns>
		public static double operator *(Numero numeroUno, Numero numeroDos)
		{
			return numeroUno.numero * numeroDos.numero;
		}
		/// <summary>
		/// Metodo estático de sobrecarga del operador 'division' que divide los atributos numero entre dos objetos del tipo Numero.
		/// </summary>
		/// <param name="numeroUno"></param>
		/// <param name="numeroDos"></param>
		/// <returns>Retorna la division de los atributos de ambas instancias caso que el denominador sea cero retorna MinValue</returns>
		public static double operator /(Numero numeroUno, Numero numeroDos)
		{
			if (numeroDos.numero != 0)
			{
				return numeroUno.numero / numeroDos.numero;
			}
			else
				return double.MinValue;
		}
		#endregion
	}
}
