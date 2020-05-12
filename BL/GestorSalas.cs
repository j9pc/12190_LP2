//*************************************
// Assembly         : BL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe de ponte entre a apresentação da aplicação "Main" e o datalayer.
//		Responsável pela comunicação entre ambas as camadas, contendo as regras e exceções indicadas"
// ***********************************************************************
using System;
using System.Collections.Generic;
using BO;
using DL;
using Excepcoes;

namespace BL
{
    /// <summary>
    /// Classe que define o objeto GestorSalas.
    /// </summary>
    public class GestorSalas
    {
        /// <summary>
        /// Método para inserir a Sala
        /// </summary>
        /// <returns> A Sala.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static bool InserirSala(EnumSalas idSala)
        {
            try
            {
                return Salas.InserirSala(idSala);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        /// <summary>
        /// Método para inserir a Sala com o seu max de camas
        /// </summary>
        /// <returns> A sala.</returns>
        /// <param name="idSala">Id da Sala.</param>
        /// <param name="maxCamas">max de Camas.</param>
        public static bool InserirSalaMax(EnumSalas idSala, int maxCamas)
        {
            try
            {
                return Salas.InserirSalaMax(idSala, maxCamas);
            }
            catch (Exception)
            {

                throw new Exception();
            }
        }

        /// <summary>
        /// Método para remover a Sala
        /// </summary>
        /// <returns> A sala.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static bool RemoverSala(EnumSalas idSala)
        {
            try
            {
                return Salas.RemoverSala(idSala);
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }

        /// <summary>
        /// Retorna o número da sala.
        /// </summary>
        /// <returns>A sala.</returns>
        public static int NumeroDeSalas()
        {
            return Salas.NumeroDeSalas();
        }

        /// <summary>
        /// Retorna o total de camas numa determinada sala.
        /// </summary>
        /// <returns>As camas.</returns>
        /// <param name="idSala">Id da sala.</param>
        public static int TotalCamas(EnumSalas idSala)
        {
            return Salas.TotalCamasNaSala(idSala);
        }

        /// <summary>
        /// Retorna o total de camas disponiveis.
        /// </summary>
        /// <returns>As disponiveis.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static int CamasDisponiveis(EnumSalas idSala)
        {
            return Salas.CamasDisponiveis(idSala);
        }

        /// <summary>
        /// Retorna o total de reservas disponivéis.
        /// </summary>
        /// <returns>As reservas disponivéis.</returns>
        /// <param name="idSala">O Id da sala.</param>
        public static int NumeroReservas(EnumSalas idSala)
        {
            return Salas.ReservasDisponiveis(idSala);
        }


        /// <summary>
        /// Retorna o total de reservas.
        /// </summary>
        /// <returns>As reservas.</returns>
        /// <param name="idSala">O Id da Sala.</param>
        public static int MaxReservas(EnumSalas idSala)
        {
            return Salas.MaxReservas(idSala);
        }

        /// <summary>
        /// Tentativa de associar uma pessoa a uma cama, numa dada Sala. 
        /// [1] Sala , [2] Sala.
        /// </summary>
        /// <returns><c>true</c>, se a pessoa foi colocada, <c>false</c> não foi.</returns>
        /// <param name="p">Pessoa.</param>
        /// <param name="docaID">O Id da Sala.</param>
        public static bool TentaAssociarPessoa(Pessoa p, EnumSalas idSala)
        {
            try
            {
                // verificação se é possível
                return Salas.TentaAssociar(p, idSala);
            }
            catch (ExceptionPessoaColocada)
            {
                throw new ExceptionPessoaColocada();
            }
            catch (ExceptionSalaCheia)
            {
                throw new ExceptionSalaCheia();
            }
            catch (ExceptionSemReserva)
            {
                throw new ExceptionSemReserva();
            }
            catch (Exception e)
            { // para o caso de acontecer algo que não foi previsto
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Regra para reservar camas. Se bem sucedida retorna True. 
        /// caso contrário retorna false e atira a excepção relacionada com a falha.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns><c>true</c>, se cama reservada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        /// <param name="idSala">O Id da Sala.</param>
        public static bool ReservarCama(Reserva reserva, EnumSalas idSala)
        {
            try
            {
                //verificámos se é possivel reservar uma cama
                return Salas.ReservarCama(reserva, idSala);
            }
            catch (ExceptionPessoaColocada)
            {
                throw new ExceptionPessoaColocada();
            }
            catch (ExceptionProblemaNaReserva)
            {
                throw new ExceptionProblemaNaReserva();
            }
            catch (ExceptionReservaExistente)
            {
                throw new ExceptionReservaExistente();
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }
            catch (Exception e)
            { // para o caso de acontecer algo que não foi previsto
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para a data "Dia do Ano" e sala indicada.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns>Na data.</returns>
        /// <param name="data">Data.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static List<Reserva> CamasOcupadasNaData(DateTime data, EnumSalas idSala)
        {
            return Salas.CamasOcupadasNaData(data, idSala);
        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para o numero de CC indicado.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns>Na data.</returns>
        /// <param name="idSala">Id da Sala.</param>
        /// <param name="numeroCC">numero de CC.</param>
        public static List<Reserva> ListaNumerosDeCCReservas(EnumSalas idSala, int numeroCC)
        {
            return Salas.NumerosDeCCReservas(idSala, numeroCC);
        }

        /// <summary>
        /// Método de cancelamento de reservas. Retorna TRUE caso seja bem sucedido, 
        /// caso contrário retorna FALSE e respectiva exceção.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns><c>true</c> se conseguiu cancelar a reserva na nSala, <c>false</c> se não. </returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="data">Data.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static bool CancelarReserva(int numeroCC, DateTime data, EnumSalas idSala)
        {
            try
            {
                //verificámos se foi possível cancelar a reserva
                return Salas.CancelarReserva(numeroCC, data, idSala);
            }
            catch (ExceptionSemReserva)
            {
                throw new ExceptionSemReserva();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Retorna uma lista com as pessoas já associadas a camas na presente Data.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns>As colocadas.</returns>
        /// <param name="idSala">Id da Sala.</param>
        public static List<Pessoa> PessoasColocadas(EnumSalas idSala)
        {
            return Salas.PessoasColocadas(idSala);
        }

        /// <summary>
        /// Regra para remover pessoas das camas, caso seja bem sucedido retorna TRUE. 
        /// caso contrário retorna FALSE e respectiva exceção.
        /// Sala [1] Sala [2]	
        /// </summary>
        /// <returns><c>true</c>, se a pessoa foi removida, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="idSala">Id da Sala.</param>
        public static bool RemoverPessoa(int numeroCC, EnumSalas idSala)
        {
            try
            {

                // verificação se é possível retirar a pessoa
                return Salas.RemoverPessoa(numeroCC, idSala);

            }
            catch (ExceptionSemPessoa)
            {
                throw new ExceptionSemPessoa();
            }
            catch (ExceptionProblemaNaReserva)
            {
                throw new ExceptionProblemaNaReserva();
            }
            catch (Exception e)
            { // para o caso de acontecer algo que não foi previsto
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Método para implementar a procura de um especifico numero de CC na lista de Reservas
        /// Caso seja bem sucedido retorna TRUE. 
        /// Caso contrário retorna false mais Excepção associada à falha.
        /// Sala [1] Sala [2]
        /// </summary>
        /// <returns><c>true</c>, se encontrou a pessoa, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="docaID">O Id da Doca.</param>
        public static List<Reserva> NumerosDeCCReservas(int numeroCC, EnumSalas idSala)
        {
            try
            {
                return Salas.NumerosDeCCReservas(idSala, numeroCC);

            }
            catch (ExceptionSemPessoa)
            {
                throw new ExceptionSemPessoa();
            }
            catch (Exception e)
            { // para o caso de acontecer algo que não foi previsto
                throw new Exception(e.Message);
            }
        }
    }
}