// ***********************************************************************
// Assembly         : Excepcoes
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe do tipo Excepções, que permite criar as várias excepções a serem usadas ao longo do projeto"
// ***********************************************************************
using System;

namespace Excepcoes
{
    /// <summary>
    /// A pessoa já colocada.
    /// </summary>
    public class ExceptionPessoaColocada : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.PessoaColocada"/> class.
        /// </summary>
        public ExceptionPessoaColocada() : base("A pessoa já se encontra colocada.")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.PessoaColocada"/> class.
        /// </summary>
        public ExceptionPessoaColocada(string msg) : base(String.Format("A pessoa já se encontra colocada {0}", msg))
        {

        }

    }
    /// <summary>
    /// Sala cheia.
    /// </summary>
    public class ExceptionSalaCheia : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.SalaCheia"/> class.
        /// </summary>
        public ExceptionSalaCheia() : base("A sala encontra-se cheia.")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.SalaCheia"/> class.
        /// </summary>
        public ExceptionSalaCheia(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Reserva já existente.
    /// </summary>
    public class ExceptionReservaExistente : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.ReservaExistente"/> class.
        /// </summary>
        public ExceptionReservaExistente() : base("A pessoa indicada já tem cama reservada para a data indicada.")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.ReservaExistente"/> class.
        /// </summary>
        public ExceptionReservaExistente(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Reserva não encontrada.
    /// </summary>
    public class ExceptionSemReserva : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.SemReserva"/> class.
        /// </summary>
        public ExceptionSemReserva() : base("A reserva não foi encontrada.")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.SemReserva"/> class.
        /// </summary>
        public ExceptionSemReserva(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Pessoa não encontrada.
    /// </summary>
    public class ExceptionSemPessoa : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.SemPessoa"/> class.
        /// </summary>
        public ExceptionSemPessoa() : base("A pessoa não foi encontrada.")
        {

        }

        /// Define/Devolve <see cref="Excepcoes.SemPessoa"/> class.
        /// </summary>
        public ExceptionSemPessoa(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Numero de CC não colocado.
    /// </summary>
    public class ExceptionNumeroCCVazio : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCVazio"/> class.
        /// </summary>
        public ExceptionNumeroCCVazio() : base("O numero de CC não pode ser vazio.")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCVazio"/> class.
        /// </summary>
        public ExceptionNumeroCCVazio(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Numero de CC Igual.
    /// </summary>
    public class ExceptionNumeroCCIgual : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCIgual"/> class.
        /// </summary>
        public ExceptionNumeroCCIgual() : base("Foi detectado que o numero de CC já se encontra associado a outra pessoa\n" +
            "Inseriu corretamente??")
        {

        }
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCIgual"/> class.
        /// </summary>
        public ExceptionNumeroCCIgual(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Data colocada incorretamente.
    /// </summary>
    public class ExceptionDataInvalida : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.DataInvalida"/> class.
        /// </summary>
        public ExceptionDataInvalida() : base("Data inválida, a data da reserva tem de ser superior á data atual [ " + DateTime.Now + " ]")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.DataInvalida"/> class.
        /// </summary>
        public ExceptionDataInvalida(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Problema na reserva.
    /// </summary>
    public class ExceptionProblemaNaReserva : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.ProblemaNaReserva"/> class.
        /// </summary>
        public ExceptionProblemaNaReserva() : base("A pessoa tem uma reserva ativa, mas não foi encontrado qualquer dado sobre a mesma")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.ProblemaNaReserva"/> class.
        /// </summary>
        public ExceptionProblemaNaReserva(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Numero de CC colocado incorretamente.
    /// </summary>
    public class ExceptionNumeroCCInvalido : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCInvalido"/> class.
        /// </summary>
        public ExceptionNumeroCCInvalido() : base("O numero de CC inserido está invalido ")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.NumeroCCInvalido"/> class.
        /// </summary>
        public ExceptionNumeroCCInvalido(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Reserva com data expirada
    /// </summary>
    public class ExceptionDataExpirada : ApplicationException
    {
        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.DataExpirada"/> class.
        /// </summary>
        public ExceptionDataExpirada() : base("A data da reserva indicada já expirou")
        {

        }

        /// <summary>
        /// Define/Devolve <see cref="Excepcoes.DataExpirada"/> class.
        /// </summary>
        public ExceptionDataExpirada(string msg) : base(msg)
        {

        }
    }

    /// <summary>
    /// Reserva sem data
    /// </summary>
    public class ExceptionReservaSemDados : ApplicationException
    {
        /// <summary>
        /// Define/Devolve de<see cref="Excepcoes.ReservaSemDados"/> class.
        /// </summary>
        public ExceptionReservaSemDados() : base("Os dados da reserva estão nulos")
        {

        }

        /// <summary>
        /// Define/Devolve de<see cref="Excepcoes.ReservaSemDados"/> class.
        /// </summary>
        public ExceptionReservaSemDados(string msg) : base(String.Format("Os dados da reserva estão nulos: {0}", msg))
        {

        }
    }
}
