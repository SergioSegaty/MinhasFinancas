using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;


namespace Repository
{
    interface IRepositoryContasReceber
    {
        int Inserir(ContaReceber conta);

        List<ContaReceber> ObterTodos(string busca);

        bool Apagar(int id);

        bool Atualizar(ContaReceber conta);

        ContaReceber ObterPeloId(int id);
    }
}
