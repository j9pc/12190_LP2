// ***********************************************************************
// Assembly         : DL
// Author           : João Gomes - 12190@alunos.ipca.pt
// Created          : 01-04-2020
// Description      : "Classe PessoasDataReadWritter que implementa a gravação dos dados das pessoas colocadas para um ficheiro json."
// ***********************************************************************
using BO;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace DL
{
    public class PessoasDataReadWritter
    {

        static string filePath = @"C:\Users\JPC\Desktop\pessoas_data.json";

        public static bool SavePessoaToFile(Pessoa pessoa)
        {
            try
            {
                List<Pessoa> pessoas = new List<Pessoa>();

                if (!System.IO.File.Exists(filePath))
                {
                    var myJsonFile = System.IO.File.Create(filePath);
                    myJsonFile.Close();
                }

                var pessoasJSON = System.IO.File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(pessoasJSON))
                {
                    pessoas.Add(pessoa);
                }
                else
                {
                    pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(pessoasJSON);
                    pessoas.Add(pessoa);
                }

                var convertToJson = JsonConvert.SerializeObject(pessoas, Formatting.Indented);

                System.IO.File.WriteAllText(filePath, convertToJson);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        public static List<Pessoa> GetPessoas()
        {
            try
            {
                List<Pessoa> pessoas = new List<Pessoa>();

                if (!System.IO.File.Exists(filePath))
                {
                    // returns empty list
                    return pessoas;
                }

                var pessoasJSON = System.IO.File.ReadAllText(filePath);

                if (string.IsNullOrEmpty(pessoasJSON))
                {
                    return pessoas;
                }

                pessoas = JsonConvert.DeserializeObject<List<Pessoa>>(pessoasJSON);

                return pessoas;

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

    }
}