using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BBL
{
    public class BBLProduto
    {
        private DALConexao conexao;
        public BBLProduto(DALConexao cx)
        {
            this.conexao = cx;
        }

        //metódo incluir
        public void Incluir(ModeloProduto modelo) 
        {
            if (modelo.ProNome.Trim().Length == 0) 
            {
                throw new Exception("O Nome do Produto é Obrigatorio");
            }
            if (modelo.ProDescricao.Trim().Length == 0) 
            {
                throw new Exception("O Nome da Descrição do Produto é Obrigatoria");
            }
            if (modelo.ProValorVenda <= 0) 
            {
                throw new Exception("O Valor de Venda do Produto é Obrigatorio");
            }
            if (modelo.ProQtde < 0) 
            {
                throw new Exception("A Qantidade do Produto deve ser maior ou igual a Zero");
            }
            if (modelo.ScatCod <=0)
            {
                throw new Exception("O Codigo da SubCategoria é Obrigatori");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O Codigo da Categoria é Obrigatori");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O Codigo da Unidade de Medida é Obrigatori");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Incluir(modelo);
        } 
        //Metódo Excluir
        public void Excluir (int codigo) 
        {
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Excluir(codigo);
        }

        //Metódo Alterar
        public void Alteraer(ModeloProduto obj) 
        {
            if (obj.ProNome.Trim().Length == 0)
            {
                throw new Exception("O Nome do Produto é Obrigatorio");
            }
            if (obj.ProDescricao.Trim().Length == 0)
            {
                throw new Exception("O Nome da Descrição do Produto é Obrigatoria");
            }
            if (obj.ProValorVenda <= 0)
            {
                throw new Exception("O Valor de Venda do Produto é Obrigatorio");
            }
            if (obj.ProQtde < 0)
            {
                throw new Exception("A Qantidade do Produto deve ser maior ou igual a Zero");
            }
            if (obj.ScatCod <= 0)
            {
                throw new Exception("O Codigo da SubCategoria é Obrigatori");
            }
            if (obj.CatCod <= 0)
            {
                throw new Exception("O Codigo da Categoria é Obrigatori");
            }
            if (obj.ScatCod <= 0)
            {
                throw new Exception("O Codigo da Unidade de Medida é Obrigatori");
            }
            if (obj.ProCod <= 0)
            {
                throw new Exception("O Codigo do Produto é Obrigatori");
            }
            DALProduto DALobj = new DALProduto(conexao);
            DALobj.Alterar(obj);
        }
        //Metódo Localizar
        public DataTable Localizar(String valor)
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.Localizar(valor);
        }
        //Metódo para carregar o modelo do produto
        public ModeloProduto CarregaModeloProduto(int codigo) 
        {
            DALProduto DALobj = new DALProduto(conexao);
            return DALobj.CarregaModeloProduto(codigo);
        }


    }
}
