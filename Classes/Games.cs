using System;

namespace DesafioDIO
{
    public class Games : EntidadeBase //Entidade Games HERDA da EntidadeBase o ID
    {
        //Atributos
        //Enum - Plataforma e Gênero

        private string Nome {get; set;}
        private string Descricao {get; set;}
        private Plataforma Plataforma {get; set;}
        private Genero Genero {get; set;}
        private DateTime Data_Lancamento {get; set;}
        private string Estudio {get; set;}
        private bool Excluido {get; set;}


        // Método construtor

        public Games(int id, Genero genero, string nome, string descricao, DateTime data_lancamento, string estudio, Plataforma plataforma) {
            this.Id = id;
            this.Nome = nome;
            this.Descricao = descricao;
            this.Plataforma = plataforma;
            this.Genero = genero;
            this.Data_Lancamento = data_lancamento;
            this.Estudio = estudio;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno ="";
            retorno += "Nome: " + this.Nome + Environment.NewLine;

            retorno += "Descrição: " + this.Descricao + Environment.NewLine;

            retorno += "Plataforma: " + this.Plataforma + Environment.NewLine;

            retorno += "Gênero: " + this.Genero + Environment.NewLine;

            retorno += "Data de lançamento: " + this.Data_Lancamento + Environment.NewLine;

            retorno += "Estúdio: " + this.Estudio + Environment.NewLine;
            
            retorno += "Excluído: " + this.Excluido;


            return retorno;
        }

        public string retornaNome(){
            return this.Nome;
        }

        public int retornaId() {
            return this.Id;
        }

        public bool retornaExcluido() {
            return this.Excluido;
        }
        public void Excluir() {
            this.Excluido = true;
        }
    }

}