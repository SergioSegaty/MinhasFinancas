using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Repository
{
    public class EnderecoRepositorio : IRepositoryEnderecos
    {
        Conexao conexao;

        public EnderecoRepositorio()
        {
            conexao = new Conexao();
        }

        public List<Endereco> ObterTodos(string busca)
        {
            List<Endereco> enderecos = new List<Endereco>();

            SqlCommand comando = conexao.Conectar();

            comando.CommandText = @"SELECT * FROM enderecos WHERE cep like @NOME";

            busca = $"%{busca}%";

            comando.Parameters.AddWithValue("@NOME", busca);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            for (int i = 0; i < tabela.Rows.Count; i++)
            {
                DataRow linha = tabela.Rows[i];
                Endereco endereco = new Endereco();
                endereco.Cep = linha["cep"].ToString();
                endereco.Lagradouro = linha["lagradouro"].ToString();
                endereco.Numero = linha["numero"].ToString();
                endereco.Uf = linha["uf"].ToString();
                endereco.Complemento = linha["complemento"].ToString();
                endereco.Cidade = linha["cidade"].ToString();
                endereco.Id = Convert.ToInt32(linha["id"]);

                enderecos.Add(endereco);

            }

            return enderecos;
        }

        public int Inserir(Endereco endereco)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"INSERT INTO enderecos
            (uf, cidade, lagradouro, cep , numero , complemento)
            VALUES
            (@UF, @CIDADE, @LAGRADOURO, @CEP, @NUMERO, @COMPLEMENTO)";

            comando.Parameters.AddWithValue("@UF", endereco.Uf);
            comando.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            comando.Parameters.AddWithValue("@LAGRADOURO", endereco.Lagradouro);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();

            return id;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = conexao.Conectar();

            comando.CommandText = @"DELETE from enderecos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            int quantidadeAfetada = comando.ExecuteNonQuery();
            comando.Connection.Close();

            return quantidadeAfetada == 1;

        }
        
        public bool Atualizar(Endereco endereco)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"UPDATE enderecos SET
            uf = @UF,
            cidade = @CIDADE,
            lagradouro = @LAGRADOURO,
            cep = @CEP,
            numero = @NUMERO,
            complemento = @COMPLEMENTO
            WHERE id = @ID";

            comando.Parameters.AddWithValue("@UF", endereco.Uf);
            comando.Parameters.AddWithValue("@CIDADE", endereco.Cidade);
            comando.Parameters.AddWithValue("@LAGRADOURO", endereco.Lagradouro);
            comando.Parameters.AddWithValue("@CEP", endereco.Cep);
            comando.Parameters.AddWithValue("@NUMERO", endereco.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", endereco.Complemento);
            comando.Parameters.AddWithValue("@ID", endereco.Id);

            comando.Connection.Close();
            int quantidadeAfetada = comando.ExecuteNonQuery();
            return quantidadeAfetada == 1;
        }

        public Endereco ObterPeloId(int id)
        {
            SqlCommand comando = conexao.Conectar();
            comando.CommandText = @"SELECT * FROM enderecos WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable tabela = new DataTable();
            tabela.Load(comando.ExecuteReader());
            if (tabela.Rows.Count == 1)
            {
                Endereco endereco = new Endereco();
                DataRow linha = tabela.Rows[0];

                endereco.Cep = linha["cep"].ToString();
                endereco.Lagradouro = linha["lagradouro"].ToString();
                endereco.Numero = linha["numero"].ToString();
                endereco.Uf = linha["uf"].ToString();
                endereco.Complemento = linha["complemento"].ToString();
                endereco.Cidade = linha["cidade"].ToString();

                return endereco;
            }

            return null;
        }

    }
}
