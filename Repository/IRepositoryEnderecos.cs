using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    interface IRepositoryEnderecos
    {
        List<Endereco> ObterTodos(string busca);

        bool Apagar(int id);

        bool Atualizar(Endereco endereco);

        Endereco ObterPeloId(int id);

        int Inserir(Endereco endereco);


    }
}
