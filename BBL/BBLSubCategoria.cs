using DAL;
using Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BBL
{
    public class BBLSubCategoria
    {
        private DALConexao conexao;

        public BBLSubCategoria(DALConexao cx)
        {
            this.conexao = cx;
        }

        public void incluir (ModeloSubCategoria modelo)
        {
            if(modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatório");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Incluir(modelo);
        }

        public void alterar (ModeloSubCategoria modelo)
        {
            if (modelo.ScatNome.Trim().Length == 0)
            {
                throw new Exception("O nome da subcategoria é obrigatorio");
            }
            if (modelo.CatCod <= 0)
            {
                throw new Exception("O codigo da categoria é obrigatorio");
            }
            if (modelo.ScatCod <= 0)
            {
                throw new Exception("O codigo da subcategoria é obrigatorio");
            }

            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Alterar(modelo);
        }

        public void Excluir(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            DALobj.Excluir(codigo);
        }

        public DataTable Localizar(String valor)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.Localizar(valor);
        }

        public DataTable LocalizaPorCategoria(int categoria) 
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.LocalizaPorCategoria(categoria);
        }

        public ModeloSubCategoria CarregaModeloSubCategoria(int codigo)
        {
            DALSubCategoria DALobj = new DALSubCategoria(conexao);
            return DALobj.CarregaModeloSubCategoria(codigo);
        }


        
    }
}
