using System;
using System.Collections.Generic;
using System.IO;
using Senai.Desafio.AplicacaoFinanceira.Model;

namespace Senai.Desafio.AplicacaoFinanceira.Repositorio {
    public class TransacaoRepositorio {

        public void Inserir (TransacaoModel tm) {

            StreamWriter sw = new StreamWriter ("transacoes.csv", true);
            sw.WriteLine ($"{tm.TipoTransacao}; {tm.Descricao}; {tm.Valor}; {tm.DataTransacao}");
            sw.Close ();

        }

        public List<TransacaoModel> ListarTransacoes () {
            var listaTransacoes = new List<TransacaoModel> ();
            TransacaoModel TransacaoListado;

            if (!File.Exists ("transacoes.csv")) {
                return null;
            }

            string[] linhasTransicoes = File.ReadAllLines ("transacoes.csv");
            foreach (var item in linhasTransicoes) {
                if (item == null) {
                    return null;
                }

                TransacaoListado = new TransacaoModel ();
                string[] dadosTransacao = item.Split (";");
                for (int i = 0; i < dadosTransacao.Length; i++) {
                    TransacaoListado.TipoTransacao = dadosTransacao[0];
                    TransacaoListado.Descricao = dadosTransacao[1];
                    TransacaoListado.Valor = float.Parse (dadosTransacao[2]);
                    TransacaoListado.DataTransacao = DateTime.Parse (dadosTransacao[3]);
                }
                listaTransacoes.Add (TransacaoListado);
            }
            return listaTransacoes;
        }
    }
}