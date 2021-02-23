using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DALUnidadeMedida
    {
        private DALConexao conexao;

        //Construtor que recebe uma conexão
        public DALUnidadeMedida(DALConexao cx)
        {
            this.conexao = cx;
        }

        //Metodo para incluir um dado no banco de dados
        public void Incluir (ModeloUnidadeMedida modelo) 
        {
            try 
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conexao.ObjetoConexao;
                cmd.CommandText = "insert into undmedida(umed_nome) values (@nome); select @@IDENTITY";
                cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
                conexao.Conectar();
                modelo.UmedCod = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch(Exception erro) 
            {
                throw new Exception(erro.Message);
            }
            finally 
            {
                conexao.Desconectar();
            }
            
        }
        //Metodo para Alterar um dado no banco de dados 
        public void Alterar(ModeloUnidadeMedida modelo) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "update undmedida set umed_nome = @nome where umed_cod = @codigo;";
            cmd.Parameters.AddWithValue("@nome", modelo.UmedNome);
            cmd.Parameters.AddWithValue("@codigo", modelo.UmedCod);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        //Medoto para Excluir um dado no banco de dados 
        public void Excluir (int codigo) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from undmedida where umed_cod = @codigo;";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }
        //Medoto para localizar um dado no banco de dados 
        public DataTable Localizar (String valor) 
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from undmedida where umed_nome like '%" +
                valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public int VerificaUnidadeDeMedida(String valor) // se o valor for 0 - não existe o valor no banco
        {
            int r = 0; // 0- não existe
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undmedida where umed_nome = @nome";
            cmd.Parameters.AddWithValue("@nome", valor);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows)
            {
                registro.Read();
                r = Convert.ToInt32(registro["umed_cod"]);
                
            }
            conexao.Desconectar();
            return r;
        }

        /**Metodo para pegar as informações de um regustro especifico no banco da tabela Unidade de Medida.
         e preencher um objeto do tipo Unidade de Medida* */
        public ModeloUnidadeMedida CarregaModeloUnidadeMedida(int codigo) 
        {
            ModeloUnidadeMedida modelo = new ModeloUnidadeMedida();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from undmedida where umed_cod = @codigo";
            cmd.Parameters.AddWithValue("codigo", codigo);
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows) 
            {
                registro.Read();
                modelo.UmedCod = Convert.ToInt32(registro["umed_cod"]);
                modelo.UmedNome = Convert.ToString(registro["umed_nome"]);
            }
            conexao.Desconectar();
            return modelo;
        }

    }
}
