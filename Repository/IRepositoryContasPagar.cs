using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
   interface IRepositoryContasPagar
    {
        int Inserir(ContaPagar conta);

        List<ContaPagar> ObterTodos(string busca);

        bool Apagar(int id);

        bool Atualizar(ContaPagar conta);

        ContaPagar ObterPeloId(int id);

    }
}
