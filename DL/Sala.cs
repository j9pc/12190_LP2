// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe que cria uma Sala contendo 200 camas, 
//		contém todos os metodos associados ao reservar camas para as Pessoas."
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BO;

namespace DL
{
    /// <summary>
    /// Classe para definir o objeto Sala.
    /// </summary>
    public class Sala
    {

        EnumSalas idSala = EnumSalas.Desconhecida;
        int maxCamas = 100;
        readonly Ano marcacaoReservas = new Ano();

        // Lista de Pessoas para cada cama
        readonly List<Cama> camas;

        /// <summary>
        /// Define/Devolve <see cref="DL.Sala"/> class.
        /// </summary>
        public Sala()
        {
            camas = new List<Cama>();
        }

        /// <summary>
        /// Define/Devolve <see cref="DL.Sala"/> class.
        /// </summary>
        public Sala(EnumSalas id)
        {
            this.idSala = id;
            camas = new List<Cama>();


        }

        /// <summary>
        /// Define/Devolve <see cref="DL.Sala"/> class.
        /// </summary>
        public Sala(EnumSalas id, int maxCamas)
        {
            this.idSala = id;
            this.maxCamas = maxCamas;
            camas = new List<Cama>();
        }
    }
}
