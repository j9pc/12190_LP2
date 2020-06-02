//*************************************
// Assembly         : BL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe de ponte entre a apresentação da aplicação "Main" e o datalayer.
//		Implementa a gravação  e a leitura de um ficheiro"
// ***********************************************************************
using BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class PessoasBL
    {

        public static bool SavePessoa(Pessoa pessoa)
        {
            try
            {
                return DL.PessoasDataReadWritter.SavePessoaToFile(pessoa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public static List<Pessoa> GetPessoas()
        {
            try
            {
                return DL.PessoasDataReadWritter.GetPessoas();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}