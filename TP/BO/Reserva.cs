// ***********************************************************************
// Assembly         : BO
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe Reserva, permite a criação de reservas de camas, juntamente com uma Pessoa da classe Pessoa"
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Classe para definir o objeto Reserva.
    /// </summary>
    public class Reserva
    {

        #region ESTADO

        Pessoa pessoa;
        bool colocada;
        DateTime dataEntrada, dataSaida;

        #endregion

        #region CONSTRUTORES
        /// <summary>
        /// Define/Devolve <see cref="BO.Reserva"/> class.
        /// </summary>
        public Reserva()
        {
            this.pessoa = new Pessoa();
            this.dataEntrada = new DateTime();
            this.dataSaida = DataEntrada;
            this.colocada = false;
        }

        /// <summary>
        /// Define/Devolve <see cref="BO.Reserva"/> class.
        /// </summary>
        /// <param name="dataEntrada">Data entrada.</param>
        /// <param name="dataSaida">Data saida.</param>
        /// <param name="pessoa">Pessoa.</param>
        public Reserva(DateTime dataEntrada, DateTime dataSaida, Pessoa pessoa)
        {
            this.dataEntrada = dataEntrada;
            this.dataSaida = dataSaida;
            this.pessoa = pessoa;
            this.colocada = false;
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Gets or sets the data entrada.
        /// </summary>
        /// <value>The data entrada.</value>
        public DateTime DataEntrada
        {
            get { return dataEntrada; }
            set
            {
                if (PessoaReserva.NumeroCC != -1 && value < DateTime.Now)
                {
                    throw new Exception();
                }
                dataEntrada = value;
            }
        }

        /// <summary>
        /// Gets or sets the data saida.
        /// </summary>
        /// <value>The data saida.</value>
        public DateTime DataSaida
        {
            get { return dataSaida; }
            set { dataSaida = value; }
        }

        /// <summary>
        /// Gets or sets the reserva para a Pessoa.
        /// </summary>
        /// <value>The Pessoa Reserva.</value>
        public Pessoa PessoaReserva
        {
            get { return pessoa; }
            set { pessoa = value; }
        }

        /// <summary>
        /// Gets or sets the reserva colocada.
        /// </summary>
        /// <value>The colocada.</value>
        public bool Colocada
        {
            get { return colocada; }
            set { colocada = value; }
        }

        #endregion

    }
}
