using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public class DALProduto
    {
        private DALConexao conexao;

        public DALProduto(DALConexao cx) 
        {
            this.conexao = cx;
        }

        //Metódo incluir 
        public void Incluir(ModeloProduto obj) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "insert into Produto (pro_nome, pro_descricao, pro_foto, pro_valorpago, pro_valorvenda+" +
            "pro_qtde, undmed_cod, cat_cod, scat_cod) values (@nome, @descricao, @foto, @valorpago, @valorvenda, @qtde, @undmedcod, @catcod, @scatcod); select @@IDENTITY;";
            cmd.Parameters.AddWithValue("@nome", obj.ProNome);
            cmd.Parameters.AddWithValue("@descricao", obj.ProDescricao);
            cmd.Parameters.Add("@foto", System.Data.SqlDbType.Image);
            if (obj.ProFoto == null) 
            {
                //cmd.Parameters.AddWithValue("@pro_foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else 
            {
                cmd.Parameters.AddWithValue("@pro_foto", obj.ProFoto);
                cmd.Parameters["@fato"].Value = obj.ProFoto;
            }
            cmd.Parameters.AddWithValue("@valorpago", obj.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", obj.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", obj.ProQtde);
            cmd.Parameters.AddWithValue("@undmedcod", obj.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", obj.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", obj.ScatCod);
            conexao.Conectar();
            obj.ProCod = Convert.ToInt32(cmd.ExecuteScalar());
            conexao.Desconectar();
        }

        //Metódo Excluir
        public void Excluir(int codigo) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "delete from Produto where (pro_cod) = (@codigo)";
            cmd.Parameters.AddWithValue("@codigo", codigo);
            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        //Metódo Alterar
        public void Alterar(ModeloProduto obj) 
        {
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "updade produto set pro_nome = (@nome), pro_descricao = (@descricao), pro_foto = (@foto)," +
                " pro_valorpago = (@valorpago), pro_valorvenda = (@valorvenda), pro_qtde = (@qtde), undmed_cod = (@undmedcod), cat_cod = (@catcod), scat_cod = (@scatcod)" +
                "where pro_cod = (@codigo)";
            cmd.Parameters.AddWithValue("nome", obj.ProNome);
            cmd.Parameters.AddWithValue("descricao", obj.ProDescricao);
            cmd.Parameters.Add("foto", System.Data.SqlDbType.Image);
            if (obj.ProFoto == null) 
            {
                //cmd.Parameters.AddWithValue("foto", DBNull.Value);
                cmd.Parameters["@foto"].Value = DBNull.Value;
            }
            else 
            {
                //cmd.Parameters.AddWithValue("@foto", obj.ProFoto);
                cmd.Parameters["@foto"].Value = obj.ProFoto;
            }
            cmd.Parameters.AddWithValue("@valorpago", obj.ProValorPago);
            cmd.Parameters.AddWithValue("@valorvenda", obj.ProValorVenda);
            cmd.Parameters.AddWithValue("@qtde", obj.ProQtde);
            cmd.Parameters.AddWithValue("@undmedcod", obj.UmedCod);
            cmd.Parameters.AddWithValue("@catcod", obj.CatCod);
            cmd.Parameters.AddWithValue("@scatcod", obj.ScatCod);
            cmd.Parameters.AddWithValue("@codigo", obj.ProCod);

            conexao.Conectar();
            cmd.ExecuteNonQuery();
            conexao.Desconectar();
        }

        //Metódo Localizar
        public DataTable Localizar(String valor) 
        {
            DataTable tabela = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from produto where pro_nome like '%" + valor + "%'", conexao.StringConexao);
            da.Fill(tabela);
            return tabela;
        }

        public ModeloProduto CarregaModeloProduto(int codigo) 
        {
            ModeloProduto modelo = new ModeloProduto();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conexao.ObjetoConexao;
            cmd.CommandText = "select * from produto where (pro_cod) = " + codigo.ToString();
            conexao.Conectar();
            SqlDataReader registro = cmd.ExecuteReader();
            if (registro.HasRows) 
            {
                registro.Read();
                modelo.ProCod = Convert.ToInt32(registro["pro_cod"]);
                modelo.ProNome = Convert.ToString(registro["pro_nome"]);
                modelo.ProDescricao = Convert.ToString(registro["pro_descricao"]);
                try
                {
                    modelo.ProFoto = (byte[])registro["pro_foto"];
                }
                catch { }
                modelo.ProValorPago = Convert.ToDouble(registro["pro_valorpago"]);
                modelo.ProValorVenda = Convert.ToDouble(registro["pro_valorvenda"]);
                modelo.ProQtde = Convert.ToInt32(registro["pro_qtde"]);
                modelo.UmedCod = Convert.ToInt32(registro["undmed_cod"]);
                modelo.CatCod = Convert.ToInt32(registro["cat_cod"]);
                modelo.ScatCod = Convert.ToInt32(registro["scat_cod"]);
            }
            return modelo;
        }




    }
}
