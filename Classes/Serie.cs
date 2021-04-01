using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        // Variáveis
        private Genero Genero { get; set; }
        private string Nome { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }

        // Construtor
        public Serie(int id, Genero genero, string nome, string descricao, int ano)
        {
            this.id = id;
            this.Genero = genero;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Ano = ano;
        }

        // Métodos
        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine; 
            retorno += "Título: " + this.Nome + Environment.NewLine; 
            retorno += "Descrição: " + this.Descricao + Environment.NewLine; 
            retorno += "Ano de ínicio: " + this.Ano;
            return retorno; 
        }

        public string RetornaTitulo() 
        {
            return this.Nome;
        }

        public int RetornaId() 
        {
            return this.id;
        }
    }
}