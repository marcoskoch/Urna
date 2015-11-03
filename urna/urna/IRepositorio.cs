using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace urna
{
    public interface IRepositorio<T>
    {
        T BuscarPorId(int id);

        void Cadastrar(T tipo);

        void Atualizar(T tipo);

        void AtualizarPorId(int id, T tipo);

    }
}
