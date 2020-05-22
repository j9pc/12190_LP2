// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe Dia que define o número total reservas que podem ser efetuadas.
//          Vários métodos que possibilitam a marcação, consulta e remoção de reservas."
// ***********************************************************************
using System;
using System.Collections.Generic;
using BO;
using Excepcoes;

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

        #region METODOS

        /// <summary>
        /// Regista uma reserva.
        /// </summary>
        /// <returns><c>true</c>, se reserva registada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool RegistaReserva(Reserva reserva)
        {

            try
            {
                // verificámos se já tinha reservado
                if (!CamaJaReservada(reserva))
                {
                    if (reservas.Count <= MAXRESERVAS)
                    {
                        reservas.Add(reserva);
                        return true;
                    }
                    return false;

                }

                throw new ExceptionReservaExistente();

            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }

        }

        /// <summary>
        /// Verifica se a cama já foi reservada.
        /// </summary>
        /// <returns><c>true</c>, se a cama já reservada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool CamaJaReservada(Reserva reserva)
        {

            // se a reserva for nula || isto nunca vai ocorrer
            if (reserva.PessoaReserva.NumeroCC == 0)
            {
                throw new ExceptionReservaSemDados();
            }

            if (reservas.Count == 0)
            {
                return false;
            }

            foreach (Reserva res in reservas)
            {
                if (reserva.DataEntrada < res.DataSaida && reserva.PessoaReserva.NumeroCC == res.PessoaReserva.NumeroCC)
                {
                    return true;
                }
            }

            return false;

        }

        /// <summary>
        /// Método que verifica se não há sobreposição de reservas.
        /// </summary>
        /// <returns><c>true</c>, se não tem reserva, <c>false</c> se sim.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool CamaDisponivelReserva(Reserva reserva)
        {

            if (reservas.Count == 0)
            {
                return true;
            }

            foreach (Reserva res in reservas)
            {
                if (reserva.PessoaReserva.NumeroCC == res.PessoaReserva.NumeroCC)
                {
                    if (reserva.DataEntrada >= res.DataEntrada && reserva.DataSaida <= res.DataSaida)
                    {
                        return false; // a pessoa já tem cama associada
                    }
                }
            }

            return true;

        }

        /// <summary>
        /// Método que retorna TRUE caso seja possivel cancelar uma reserva.
        /// Se não, retorna FALSE.
        /// </summary>
        /// <returns><c>true</c> se cancelou a reserva, <c>false</c> se não.</returns>
        /// <param name="numeroCC">Reserva.</param>
        internal bool CancelarReserva(int numeroCC)
        {
            if (reservas.Count == 0)
            {
                return false;
            }

            foreach (Reserva reserva in reservas)
            {
                if (numeroCC == reserva.PessoaReserva.NumeroCC)
                {


                    reservas.Remove(reserva);
                    return true;


                }
            }

            return false;

        }

        /// <summary>
        /// Método que retorna uma lista com os dados das reservas para determinado dia.
        /// </summary>
        /// <returns>The na data.</returns>
        internal List<Reserva> CamasOcupadasNaData()
        {

            List<Reserva> ocupadas = new List<Reserva>(reservas);

            return ocupadas;

        }

        /// <summary>
        /// Metodo que pesquisa reservas através do numero de CC
        /// </summary>
        /// <param name="numeroCC"></param>
        /// <returns></returns>
        internal List<Reserva> CamasOcupadasNaData(int numeroCC)
        {
            List<Reserva> ocupadas = new List<Reserva>();


            foreach (Reserva reserva in reservas)
            {
                if (reserva.PessoaReserva.NumeroCC.Equals(numeroCC))
                {
                    ocupadas.Add(reserva);
                }
            }

            return ocupadas;

        }

        /// <summary>
        /// Método para ativar a reserva.
        /// </summary>
        /// <returns><c>true</c>, se reserva ativada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool AtivarReserva(Reserva reserva)
        {

            if (reservas.Count == 0)
            {
                return false;
            }

            foreach (Reserva res in reservas)
            {
                // se os dados da reserva forem iguais a alguma reserva ativámos a mesma
                if (reserva.PessoaReserva.NumeroCC == res.PessoaReserva.NumeroCC && reserva.DataEntrada >= res.DataEntrada && reserva.DataEntrada < res.DataSaida)
                {
                    res.Colocada = true;
                    return true;
                }
                if (reserva.PessoaReserva.NumeroCC == res.PessoaReserva.NumeroCC && reserva.DataEntrada > res.DataSaida)
                {
                    throw new ExceptionDataExpirada();
                }
            }


            throw new ExceptionSemReserva();

        }

        #endregion

    }
}
