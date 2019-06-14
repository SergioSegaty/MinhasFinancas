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
    class IRepository
    {
        private Conexao conexao;


        public int Inserir(ContaPagar conta)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO contas_pagar
            (nome, valor, tipo, descricao, status)
            VALEUS
            (@NOME, @VALOR, @TIPO, @DESCRICAO, @STATUS)";

            comando.Parameters.AddWithValue("@NOME", conta.Nome);
            comando.Parameters.AddWithValue("@VALOR", conta.Valor);
            comando.Parameters.AddWithValue("@TIPO", conta.Tipo);
            comando.Parameters.AddWithValue("@DESCRICAO", conta.Descricao);
            comando.Parameters.AddWithValue("@STATUS", conta.Status);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public List<ContaPagar> ObterTodos(string busca)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM contas_pagar
            WHERE nome like @NOME";

            busca = $"%{busca}%";
            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            List<ContaPagar> contas = new List<ContaPagar>();
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                ContaPagar conta = new ContaPagar();
                conta.Id = Convert.ToInt32(linha["id"]);
                conta.Nome = linha["nome"].ToString();
                conta.Valor = Convert.ToDecimal(linha["valor"]);
                conta.Tipo = linha["tipo"].ToString();
                conta.Status = Convert.ToBoolean(linha["status"]);
                conta.Descricao = linha["descricao"].ToString();

                contas.Add(conta);
            }
            return contas;

        }

        public ContaPagar ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM contas_pagar WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);
            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            comando.Connection.Close();
            if (tabela.Rows.Count == 0)
            {

            }

        }

    }
}
