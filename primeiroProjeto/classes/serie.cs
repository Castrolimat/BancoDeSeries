namespace primeiroProjeto
{
    public class serie : entidadeBase
    {
        //atributos
        private genero genero {get; set; }
        private string titulo {get; set; }

        private string descricao {get; set; }
        private int ano {get; set; }
        
        private bool excluido {get; set; }
        //metodos
        public serie(int id, genero genero, string titulo, string descricao, int ano)
        {
            this.id = id;
            this.genero = genero;
            this.titulo = titulo;
            this.descricao = descricao;
            this.ano = ano;
            this.excluido = false;
        }

        public override string ToString()
        {
            
            string retorno = "";
            retorno += "Gênero: " + this.genero;
            retorno += "\nTítulo: " + this.titulo;
            retorno += "\nDescrição: " + this.descricao;
            retorno += "\nAno de início: " + this.ano;
            retorno += "\nExcluido: " + this.excluido;
            return retorno;


        }

        public string retornaTitulo()
        {
            return this.titulo;
        }

        public int retornaId()
        {
            return this.id;
        }

        public bool retornaExcluido()
        {
            return this.excluido;
        }

        public void exclui ()
        {
            this.excluido = true;
        }

    }
}