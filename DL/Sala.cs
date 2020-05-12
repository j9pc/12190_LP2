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
using Excepcoes;


namespace DL
{
    /// <summary>
    /// Classe para definir o objeto Sala.
    /// </summary>
    public class Sala
    {

        #region ESTADO

        EnumSalas idSala = EnumSalas.Desconhecida;
        int maxCamas = 100;
        readonly Ano marcacaoReservas = new Ano();

        // Lista de Pessoas para cada cama
        readonly List<Cama> camas;

        #endregion

        #region CONSTRUTORES

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

        #endregion

        #region METODOS

        /// <summary>
        /// Retorna o máximo de camas nas salas.
        /// </summary>
        /// <value>O MaxSala.</value>
        public int MaxSala
        {
            get { return maxCamas + marcacaoReservas.NumeroMaxCamas(); }
        }

        /// <summary>
        /// Retorna o ID da sala.
        /// </summary>
        /// <value>O id da sala.</value>
        public EnumSalas IdSala
        {
            get { return idSala; }

        }

        /// <summary>
        /// Retorna as camas ocupadas.
        /// </summary>
        /// <value>As ocupadas.</value>
        public int CamasOcupadas()
        {
            return camas.Count + marcacaoReservas.NumeroReservasAtivas(DateTime.Now.DayOfYear);
        }

        /// <summary>
        /// Retorna as camas livres.
        /// </summary>
        /// <returns>As livres.</returns>
        public int CamasLivres()
        {
            return MaxSala - CamasOcupadas();
        }

        /// <summary>
        /// Retorna o número de camas disponiveis para reserva.
        /// </summary>
        /// <returns>As disponíveis.</returns>
        public int ReservasDisponiveis()
        {
            return marcacaoReservas.NumeroReservas(DateTime.Now.DayOfYear) - marcacaoReservas.NumeroReservasAtivas(DateTime.Now.DayOfYear);
        }

        /// <summary>
        /// Retorna o número de camas com uma pessoa colocada
        /// </summary>
        /// <returns>As ativas.</returns>
        public int ReservasAtivas()
        {
            return marcacaoReservas.NumeroReservasAtivas(DateTime.Now.DayOfYear);
        }

        /// <summary>
        /// Retorna o número maximo de reservas para o dia atual
        /// </summary>
        /// <returns>As reservas.</returns>
        public int MaxReservas()
        {
            return marcacaoReservas.NumeroMaxCamas();
        }

        #endregion

        #region IPESSOA

        /// <summary>
        /// Método para verificar se é o mesmo numero de CC
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        /// <param name="obj">Object.</param>
        /// <param name="registo">Registo.</param>
        public bool NumerosCCIguais(Pessoa obj, int registo)
        {
            var pessoa = (Pessoa)obj;
            return (pessoa.NumeroCC == registo);
        }

        /// <summary>
        /// Método para verificar se as pessoas são iguais
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        /// <param name="obj">Object.</param>
        /// <param name="obj1">Obj1.</param>
        public bool PessoasIguais(Pessoa obj, object obj1)
        {
            var pessoa = (Pessoa)obj;
            return pessoa.Equals(obj1);
        }

        /// <summary>
        /// Método para verificar a validação da idade da Pessoa.
        /// </summary>
        /// <returns>true</returns>
        /// <c>false</c>
        /// <param name="idade">Idade.</param>
        public bool ValidaIdade(int idade)
        {
            throw new ApplicationException();
        }

        #endregion

        #region METODOS DE INSERÇÃO

        /// <summary>
        /// Método que retorna TRUE caso seja possivel associar a pessoa à cama.
        /// Se não, retorna FALSE e respetiva mensagem de erro.
        /// </summary>
        /// <param name="pessoa">pessoa.</param>
        public bool Associar(Pessoa pessoa)
        {
            Reserva dadosReserva;
            var associarPessoa = new Cama(pessoa);

            if (Associar(pessoa))
            {
                //verificação se a pessoa já está associada a uma cama
                throw new ExceptionPessoaColocada();
            }

            if (NasReservas(pessoa.NumeroCC, out dadosReserva))
            {

                if (camas.Count <= MaxSala)
                {
                    associarPessoa.JaColocada = true;
                    camas.Add(associarPessoa);

                    try
                    {
                        // ativamos a reserva
                        return marcacaoReservas.AtivarReserva(dadosReserva);
                    }
                    catch (ExceptionDataExpirada)
                    {
                        throw new ExceptionDataExpirada();
                    }
                    catch (ExceptionReservaSemDados)
                    {
                        throw new ExceptionReservaSemDados();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                }

                return false;

            }

            // se o total de pessoas associadas a camas for menor que o máximo de camas
            // e a pessoa não estiver na Reserva, associa a pessoa
            if (CamasOcupadas() <= MaxSala)
            {
                camas.Add(associarPessoa);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Método que verifica se a pessoa já foi associada a uma cama.
        /// Retorna TRUE ou FALSE consuante resultado
        /// </summary>
        /// <param name="p">C.</param>
        bool PessoaJaColocada(Pessoa p)
        {
            foreach (Cama cama in camas)
            {
                if (PessoasIguais(p, cama.PessoaColocada))
                {
                    throw new ExceptionPessoaColocada();

                }
                else if (NumerosCCIguais(cama.PessoaColocada, p.NumeroCC))
                {
                    throw new ExceptionNumeroCCIgual();
                }
            }

            return false;

        }

        #endregion

        #region METODOS DE RESERVA
        /// <summary>
        /// Método que retorna TRUE caso seja possivel fazer uma reserva.
        /// Se não, retorna FALSE e respetiva mensagem de erro.
        /// </summary>
        /// <returns><c>true</c>, se cama reservada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        public bool ReservarCama(Reserva reserva)
        {

            // verificamos se ja esta colocada
            if (PessoaJaColocada(reserva.PessoaReserva))
            {
                throw new ExceptionPessoaColocada();
            }
            // verificamos se já tinha reservado a cama
            if (marcacaoReservas.CamaJaReservada(reserva))
            {
                throw new ExceptionReservaExistente();
            }

            //verificamos se existe reservas disponíveis
            if (!marcacaoReservas.CamaDisponivelReserva(reserva))
            {
                throw new ExceptionSalaCheia();
            }

            try
            {
                return FazerReserva(reserva); // reserver efetuada caso possível
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }

        }

        /// <summary>
        /// Método interno que verifica se a pessoa já está nas reservas.
        /// Se for verdade retorna TRUE e faz print da informação da reserva com a sua cama associada.
        /// </summary>
        /// <returns><c>true</c>, se reserva encontrada, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="dadosReserva">Reserva.</param>
        bool NasReservas(int numeroCC, out Reserva dadosReserva)
        {
            List<Reserva> reservas = CamasOcupadasNaData(DateTime.Now); // retornámos uma lista com as pessoas nas reservas;
            dadosReserva = null;

            foreach (Reserva reserva in reservas)
            {
                {
                    dadosReserva = reserva;
                    return true;
                }
            }

            return false;

        }


        /// <summary>
        /// Método que retorna TRUE caso seja possivel fazer ativar uma reserva.
        /// Se não, retorna FALSE e respetiva mensagem de erro.
        /// </summary>
        /// <returns><c>true</c>, se reserva ativada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        public bool AtivarReserva(Reserva reserva)
        {
            try
            {
                // ativámos a reserva caso seja possível
                return marcacaoReservas.AtivarReserva(reserva);
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
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }

        }

        /// <summary>
        /// Método interno de registo de reservas.
        /// </summary>
        /// <returns><c>true</c>, se reserva efetuada, <c>false</c> se não.</returns>
        /// <param name="reserva">Reserva.</param>
        bool FazerReserva(Reserva reserva)
        {
            try
            {
                marcacaoReservas.RegistarReserva(reserva);
            }
            catch (ExceptionReservaSemDados)
            {
                throw new ExceptionReservaSemDados();
            }

            return true;

        }

        /// <summary>
        /// Método que retorna uma lista com os dados da reserva para determinado dia.
        /// </summary>
        /// <returns>Na data.</returns>
        /// <param name="data">Data.</param>
        public List<Reserva> CamasOcupadasNaData(DateTime data)
        {
            return marcacaoReservas.CamasOcupadasNaData(data);
        }

        /// <summary>
        /// Retorna uma lista com os dados da reserva para o numero de CC indicado.
        /// </summary>
        /// <returns>A reserva com o numero de CC.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        public List<Reserva> NumerosDeCCReservas(int numeroCC)
        {
            return marcacaoReservas.ReservasNumeroCC(numeroCC);
        }

        /// <summary>
        /// Método que retorna TRUE caso seja possivel cancelar uma reserva.
        /// Se não, retorna FALSE e respetiva mensagem de erro.
        /// </summary>
        /// <returns><c>true</c>, reserva cancelada, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        /// <param name="data">Data.</param>
        public bool CancelarReserva(int numeroCC, DateTime data)
        {
            // tentámos cancelar a reserva
            if (!marcacaoReservas.CancelarReserva(numeroCC, data))
            {
                throw new ExceptionSemReserva();
            }

            return true;

        }

        /// <summary>
        /// Método que retorna uma lista de pessoas já associadas as camas existentes.
        /// </summary>
        /// <returns>As colocadas.</returns>
        public List<Pessoa> PessoasColocadas()
        {

            List<Pessoa> listaPessoas = new List<Pessoa>();


            if (camas.Count == 0)
            {
                return null;
            }


            foreach (Cama cama in camas)
            {
                listaPessoas.Add(cama.PessoaColocada);
            }

            return listaPessoas;

        }

        #endregion

        #region METODOS DE REMOVER

        /// <summary>
        /// Método que retorna TRUE caso seja possivel remover uma Pessoa.
        /// Se não, retorna FALSE e respetiva mensagem de erro.
        /// </summary>
        /// <returns><c>true</c>, a pessoa foi retirada, <c>false</c> se não.</returns>
        /// <param name="numeroCC">numero de CC.</param>
        public bool RemoverPessoa(int numeroCC)
        {
            Reserva dadosReserva;
            bool reserva = false;

            if (camas.Count == 0)
            {
                return false;
            }

            foreach (Cama cama in camas)
            {
                if (cama.JaColocada)
                {
                    // verificámos os dados da mesma
                    reserva = NasReservas(numeroCC, out dadosReserva);
                    if (reserva)
                    {
                        // cancelámos a mesma
                        marcacaoReservas.CancelarReserva(dadosReserva.PessoaReserva.NumeroCC, dadosReserva.DataEntrada);
                    }
                    else
                    {
                        // se der algum erro na reserva
                        throw new ExceptionProblemaNaReserva();
                    }
                }
                // retirámos a pessoa da Cama
                if (numeroCC == cama.PessoaColocada.NumeroCC)
                {
                    camas.Remove(cama);
                    return true;
                }
            }

            throw new ExceptionSemPessoa();

        }
    }

    #endregion

}
