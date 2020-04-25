// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe Ano que define o número total de dias.
//          Comunica com a classe Dia para implementação dos métodos."
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DL
{
    class Ano
    {
        #region ESTADO

        readonly Dia[] registosReservas;
        const int MAXDIASANO = 365;

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Define/Devolve de <see cref="DL.Ano"/> class.
        /// </summary>
        internal Ano()
        {
            registosReservas = new Dia[MAXDIASANO];
            for (int i = 0; i < MAXDIASANO; i++)
            {
                registosReservas[i] = new Dia();
            }
        }

        #endregion
    }
}
