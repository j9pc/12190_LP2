// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe Dia que define o número total reservas que podem ser efetuadas.
//          Vários métodos que possibilitam a marcação, consulta e remoção de reservas."
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DL
{
    public class Dia
    {
        #region ESTADO

        const int maxCamas = 100;
        readonly List<Reserva> reservas;
        const int MAXRESERVAS = maxCamas;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Define/Devolve <see cref="DL.Dia"/> class.
        /// </summary>
        internal Dia()
        {
            reservas = new List<Reserva>();
        }

        #endregion

        #region PROPRIEDADES

        /// <summary>
        /// Retorna o número máximo de reservas.
        /// </summary>
        /// <value>O max de reservas.</value>
        internal int NumerosMaxReservas
        {
            get { return MAXRESERVAS; }
        }

        /// <summary>
        /// Retorna o número de reservas existente.
        /// </summary>
        /// <value>O número de reservas.</value>
        internal int NumeroReservas
        {
            get { return reservas.Count; }
        }

        /// <summary>
        /// Retorna o número de reservas ativas.
        /// </summary>
        /// <value>As ativas.</value>
        internal int NumeroReservasAtivas
        {
            get
            {
                int resAtivas = 0;

                foreach (Reserva reserva in reservas)
                {
                    if (reserva.Colocada)
                    {
                        resAtivas++;
                    }
                }

                return resAtivas;
            }
        }

        #endregion
    }
}
