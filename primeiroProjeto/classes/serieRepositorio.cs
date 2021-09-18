using System;
using System.Collections.Generic;
using primeiroProjeto.interfaces;

namespace primeiroProjeto
{
    public class serieRepositorio : iRepositorio<serie>
    {
        private List<serie> listaSerie = new List<serie>();
        public void atualiza(int id, serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void exclui(int id)
        {
            listaSerie[id].exclui();
        }

        public void insere(serie objeto)
        {
           listaSerie.Add(objeto);
        }

        public List<serie> lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public serie retornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}