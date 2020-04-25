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
        /// Método para verificar se as Pessoas são iguais.
        /// </summary>
        /// <returns><c>true</c>, se iguais, <c>false</c> caso contrário.</returns>
        /// <param name="obj">Obj.</param>
        /// <param name="obj1">Obj1.</param>
        bool PessoasIguais(Pessoa obj, object obj1);

        /// <summary>
        /// Método para verificar se os numeros do CC são iguais.
        /// </summary>
        /// <returns><c>true</c>, se iguais, <c>false</c> caso contrário.</returns>
        /// <param name="obj">Obj.</param>
        /// <param name="numero">Registo.</param>
        bool NumerosCCIguais(Pessoa obj, int numero);

    }
}
