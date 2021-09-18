using System.Collections.Generic;

namespace primeiroProjeto.interfaces
{
    public interface iRepositorio<T>
    {
        List <T>  lista();
        T retornaPorId(int id);
        
        void insere(T entidade);
        void exclui (int id);

        void atualiza(int id, T entidade);

        int proximoId();

    }
}