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
using BO;
using Excepcoes;

namespace DL
{
    public class Ano
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

        #region METODOS

        /// <summary>
        /// Retorna o número máximo de camas disponiveis para reservar
        /// </summary>
        /// <returns> O máximo de camas.</returns>
        internal int NumeroMaxCamas()
        {
            return registosReservas[DateTime.Now.DayOfYear].NumerosMaxReservas;
        }

        /// <summary>
        /// Retorna a quantidade de camas ainda disponiveis para determinado dia.
        /// </summary>
        /// <returns>As disponiveis.</returns>
        /// <param name="dia">Dia.</param>
        internal int NumeroReservas(int dia)
        {
            return registosReservas[dia].NumeroReservas;
        }

        /// <summary>
        /// Número de pessoas colocadas.
        /// </summary>
        /// <returns>As pessoas colocadas.</returns>
        /// <param name="dia">Dia.</param>
        internal int NumeroReservasAtivas(int dia)
        {
            return registosReservas[dia].NumeroReservasAtivas;
        }

        /// <summary>
        /// Regista uma reserva no dia especificado na reserva.
        /// </summary>
        /// <returns><c>true</c>, se reserva registada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool RegistarReserva(Reserva reserva)
        {
            try
            {
                // validámos a possibilidade de registo de reserva
                return registosReservas[reserva.DataEntrada.DayOfYear].RegistaReserva(reserva);
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }
        }

        /// <summary>
        /// Verificação se a cama já está reservada.
        /// </summary>
        /// <returns><c>true</c>, se não está, <c>false</c> se está.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool CamaJaReservada(Reserva reserva)
        {
            return registosReservas[reserva.DataEntrada.DayOfYear].CamaJaReservada(reserva);
        }

        /// <summary>
        /// Retorna se não há sobreposição de reservas.
        /// </summary>
        /// <returns><c>true</c>, se ainda não tem, <c>false</c> se sim.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool CamaDisponivelReserva(Reserva reserva)
        {
            return registosReservas[reserva.DataEntrada.DayOfYear].CamaDisponivelReserva(reserva);
        }

        /// <summary>
        /// Retorna a validação do cancelamento da Reserva.
        /// </summary>
        /// <returns><c>true</c> se cancelou, <c>false</c> se não.</returns>
        /// <param name="numeroCC">Numero CC.</param>
        /// <param name="data">Data.</param>
        internal bool CancelarReserva(int numeroCC, DateTime data)
        {
            return registosReservas[data.DayOfYear].CancelarReserva(numeroCC);
        }

        /// <summary>
        /// Retorna uma lista com os dados das camas ocupadas pela data.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns>Na data "".</returns>
        /// <param name="salaID">O Id da sala.</param>
        /// <param name="data">A data.</param>
        internal List<Reserva> CamasOcupadasNaData(DateTime data)
        {
            return registosReservas[data.DayOfYear].CamasOcupadasNaData();
        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para o numero de CC e sala indicada.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns>Na data "".</returns>
        /// <param name="salaID">O Id da sala.</param>
        /// <param name="numeroCC">Numero CC.</param>
        public List<Reserva> ReservasNumeroCC(int numeroCC)
        {
            try
            {
                List<Reserva> reservasNumeroCC = new List<Reserva>();

                for (int i = 0; i < MAXDIASANO; i++)
                {

                    if (registosReservas[i].NumeroReservas > 0)
                    {
                        foreach (Reserva item in registosReservas[i].CamasOcupadasNaData(numeroCC))
                        {
                            reservasNumeroCC.Add(item);
                        }
                    }

                }

                return reservasNumeroCC;
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Retorna se a reserva foi ativada.
        /// </summary>
        /// <returns>Foi ativada.</returns>
        /// <param name="reserva">Reserva.</param>
        internal bool AtivarReserva(Reserva reserva)
        {
            try
            {
                // validámos a possibilidade de Ativação de Reserva
                return registosReservas[reserva.DataEntrada.DayOfYear].AtivarReserva(reserva);
            }
            catch (ExceptionDataExpirada)
            {
                throw new ExceptionDataExpirada();
            }
            catch (ExceptionSemReserva)
            {
                throw new ExceptionSemReserva();
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }
        }
        #endregion

    }
}
