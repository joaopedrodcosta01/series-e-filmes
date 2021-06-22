using System;

namespace Serie_e_Filme
{
    public class Serie : EntidadeBase
    {
        // ATRIBUTOS

        private Genero Genero {get; set;}
        private string SerieOuFilme {get; set;}
        private float Tempo {get; set;}
        private string Titulo {get; set;}
        private string Descricao {get; set;}
        private int Ano {get; set;}
        private bool Excluido {get; set;}

        // MÉTODOS

        public Serie(int id, Genero genero, string SerieOuFilme, string titulo, float Tempo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.SerieOuFilme = SerieOuFilme;
            this.Titulo = titulo;
            this.Tempo = Tempo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Série ou Filme: " + this.SerieOuFilme + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Tempo: " + this.Tempo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de inicio: " + this.Ano + Environment.NewLine;
            retorno += "Excluido: " + this.Excluido;
            return retorno;
        }

        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        
        public bool retornaExcluido()
        {
            return this.Excluido;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}