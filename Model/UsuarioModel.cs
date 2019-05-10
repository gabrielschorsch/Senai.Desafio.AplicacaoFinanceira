using System;

namespace Senai.Desafio.AplicacaoFinanceira.Model {
    public class UsuarioModel {
        public int Id   {get;set;}
        public string Nome {get;set;}
        public string Email {get;set;}
        public string Senha {get;set;}
        public DateTime DataNascimento {get;set;}
    }
}