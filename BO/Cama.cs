// ***********************************************************************
// Assembly         : BO
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe do tipo Cama, que permite a implementação de uma cama"
// ***********************************************************************
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    /// <summary>
    /// Classe para definir o objeto Cama.
    /// </summary>
    public class Cama
    {

        #region ESTADO

        bool jaColocada;
        DateTime dataEntrada;
        Pessoa pessoaColocada = new Pessoa();

        #endregion

        #region CONSTRUTORES

        /// <summary>
        /// Define/Devolve <see cref="BO.Cama"/> class.
        /// </summary>
        public Cama()
        {
            this.dataEntrada = DateTime.Now;
            this.pessoaColocada = new Pessoa();
        }

        /// <summary>
        /// Define/Devolve <see cref="BO.Cama"/> class.
        /// </summary>
        /// <param name="pessoa">Pessoa.</param>
        public Cama(Pessoa pessoa)
        {
            this.dataEntrada = DateTime.Now;
            this.pessoaColocada = pessoa;
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
            set { dataEntrada = value; }
        }

        /// <summary>
        /// Gets or sets the pessoa colocada.
        /// </summary>
        /// <value>The pessoa colocada.</value>
        public Pessoa PessoaColocada
        {
            get { return pessoaColocada; }
            set { pessoaColocada = value; }
        }

        /// <summary>
        /// Gets or sets the se a Pessoa ja esta colocada.
        /// </summary>
        /// <value>The pessoa esta colocada.</value>
        public bool JaColocada
        {
            get { return jaColocada; }
            set { jaColocada = value; }
        }

        #endregion

    }
}
