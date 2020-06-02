// ***********************************************************************
// Assembly         : BO
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : Classe que define a Interface da Classe Pessoa
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Interface Pessoa.
    /// </summary>
    public interface IPessoa
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numero"></param>
        /// <param name="numeroI"></param>
        /// <returns></returns>
        bool NumerosCCIguais(int numero, int numeroI);

    }
}
