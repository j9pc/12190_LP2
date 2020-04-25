// ***********************************************************************
// Assembly         : BO
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe do tipo Pessoa, que permite a criação de pessoas com as propriedades da Classe"
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Classe para definir o objeto Pessoa.
    /// </summary>
    public class Pessoa
    {

        #region ESTADO
        int idade, numeroCC;
        string nome;
        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Define/Devolve <see cref="BO.Pessoa"/> class.
        /// </summary>
        public Pessoa()
        {
            nome = null;
            idade = new int();
            numeroCC = new int();
        }

        /// <summary>
        /// Define/Devolve <see cref="BO.Pessoa"/> class.
        /// </summary>
        /// <param name="nome">Nome.</param>
        /// <param name="idade">Idade.</param>
        /// <param name="numeroCC">Numero CC.</param>
        public Pessoa(string nome, int idade, int numeroCC)
        {
            this.nome = nome;
            this.idade = idade;
            this.numeroCC = numeroCC;
        }
        #endregion

        #region PROPRIEDADES
        /// <summary>
        /// Gets or sets the nome.
        /// </summary>
        /// <value>The matricula.</value>
        public string Nome
        {
            get { return nome; }
            set { nome = value; }
        }

        /// <summary>
        /// Gets or sets the idade
        /// </summary>
        /// <value>The marca.</value>
        public int Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        /// <summary>
        /// Gets or sets the numeroCC
        /// </summary>
        /// <value>The ano.</value>
        public int NumeroCC
        {
            get { return numeroCC; }
            set { numeroCC = value; }
        }
        #endregion

        #region METODOS
        /// <summary>
        /// Operadores.
        /// Sempre que se adiciona um operador equivalencia, tem de se adicionar a diferença.
        /// </summary>
        public static bool operator ==(Pessoa x, Pessoa y)
        {
            return ((x.Nome == y.Nome) && (x.numeroCC == y.numeroCC));
        }

        /// <param name="x">The x coordinate.</param>
        /// <param name="y">The y coordinate.</param>
        public static bool operator !=(Pessoa x, Pessoa y)
        {
            return ((x.Nome != y.Nome) && (x.numeroCC != y.numeroCC));
        }

        /// <summary>
        /// Verifica se a Pessoa é igual ao objecto <see cref="BO.Pessoa"/>.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with the current <see cref="BO.Pessoa"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="System.Object"/> is equal to the current
        /// <see cref="BO.Pessoa"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj is Pessoa)
            {
                Pessoa a = obj as Pessoa;
                return (this == a);
            }

            return (this == ((Pessoa)obj));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        #endregion

    }
}

